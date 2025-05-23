﻿using MkBin.Gui;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkBin;

[SupportedOSPlatform("windows")]
public partial class MainWindow : Form
{
    private string? _text;
    private bool _dirtyFlag;
    private bool _unsaved;
    private string _lastResult = "";
    private string _lastDisassembly = "";

    private string _lastMessage = "";
    private Task? _task;
    private string _lastDocumentFilename = "";
    private bool _hex = true;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void loadTextDescriptionOfBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_unsaved && !MsgBox.AskOpen(this))
            return;

        using var x = FileDialogs
            .GetOpenTextFileDialog(_lastDocumentFilename);

        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            txtInput.Text = Storage.LoadText(x.FileName);
            _lastDocumentFilename = x.FileName;
            Text = $@"{_text} - {_lastDocumentFilename}";
            _unsaved = false;
        }
        catch (Exception ex)
        {
            MsgBox.OpenFailed(this, ex.Message);
        }
    }

    private void loadBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_unsaved && !MsgBox.AskOpen(this))
            return;

        using var x = new OpenFileDialog();
        x.Title = @"Open binary file";
        x.Filter = @"*.*|*.*";

        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        Cursor = Cursors.WaitCursor;
        try
        {
            txtInput.Text = Storage.LoadBinAsText(x.FileName);
            Cursor = Cursors.Default;
            _unsaved = true;
            _lastDocumentFilename = "";
            Text = _text;
        }
        catch (Exception ex)
        {
            Cursor = Cursors.Default;
            MsgBox.OpenFailed(this, ex.Message);
        }
    }

    private void saveTextDescriptionOfBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = FileDialogs
            .GetSaveTextFileDialog(_lastDocumentFilename);

        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            Storage.SaveText(x.FileName, txtInput.Text);
            _lastDocumentFilename = x.FileName;
            Text = $@"{_text} - {_lastDocumentFilename}";
            _unsaved = false;
        }
        catch (Exception ex)
        {
            MsgBox.SaveFailed(this, ex.Message);
        }
    }

    private void saveBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new SaveBinaryFile(txtInput.Text);
        x.ShowDialog(this);
    }

    private void quitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        if (!_dirtyFlag)
            return;

        if (_task == null)
            _task = Task.Run(ProcessText);

        if (_task.IsCompletedSuccessfully)
        {
            txtOutput.Text = @"# Result:" + Environment.NewLine + Environment.NewLine + _lastResult;
            txtDisassembly.Text = @"# Disassembly:" + Environment.NewLine + Environment.NewLine + _lastDisassembly;
            lblStatus.Text = _lastMessage;
            _task.Dispose();
            _task = Task.Run(ProcessText);
        }
    }

    private bool ProcessText()
    {
        var success = false;
        var binCompiler = new BinCompiler(txtInput.Text);
        try
        {
            var result = binCompiler.Compile();
            var s = new StringBuilder();
            _lastMessage = $"{result.Length} bytes";
            var format = _hex ? "X2" : "";
            for (var i = 0; i < result.Length; i++)
            {
                s.Append(result[i].ToString(format));
                s.Append(i >= result.Length - 1 || i % 8 == 7 ? Environment.NewLine : " ");
            }

            _lastResult = s.ToString();
            success = true;
        }
        catch (Exception e)
        {
            _lastResult = $"Failed to compile string!{Environment.NewLine}{e.Message}";
            _lastMessage = e.Message;
        }

        _lastDisassembly = binCompiler.Disassembly;
        return success;
    }

    private void MainWindow_Shown(object sender, EventArgs e)
    {
        txtInput.SelectionStart = txtInput.Text.Length;
        timer1.Enabled = true;
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
        _dirtyFlag = true;
        _unsaved = true;
    }

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) =>
        e.Cancel = _unsaved && MsgBox.AskQuit(this);

    private void MainWindow_Load(object sender, EventArgs e)
    {
        _text = Text;
    }

    private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_unsaved && !MsgBox.AskNew(this))
            return;

        _lastDocumentFilename = "";
        txtInput.Text = "";
        Text = _text;
        _unsaved = false;
    }

    private void txtOutput_DragOver(object sender, DragEventArgs e)
    {
        var dataPresent = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false;
        e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;

        if (dataPresent)
            lblStatus.Text = @"Drop binary file here.";
    }

    private void txtOutput_DragDrop(object sender, DragEventArgs e)
    {
        var dataPresent = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false;

        if (!dataPresent)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {

            var files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;

            if (files.Length <= 0)
                return;

            txtInput.Text = Storage.LoadBinAsText(files[0]);
            Cursor = Cursors.Default;
            _unsaved = true;
            _lastDocumentFilename = "";
            Text = _text;
        }
        catch (Exception ex)
        {
            Cursor = Cursors.Default;
            MsgBox.OpenFailed(this, ex.Message);
        }
    }

    private void txtInput_DragOver(object sender, DragEventArgs e)
    {
        var dataPresent = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false;
        e.Effect = dataPresent ? DragDropEffects.Copy : DragDropEffects.None;

        if (dataPresent)
            lblStatus.Text = @"Drop text file here.";
    }

    private void txtInput_DragDrop(object sender, DragEventArgs e)
    {
        var dataPresent = e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false;

        if (!dataPresent)
            return;

        try
        {
            var files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;
            if (files.Length <= 0)
                return;

            txtInput.Text = Storage.LoadText(files[0]);
            _lastDocumentFilename = files[0];
            Text = $@"{_text} - {_lastDocumentFilename}";
            _unsaved = false;
        }
        catch (Exception ex)
        {
            MsgBox.OpenFailed(this, ex.Message);
        }
    }

    private void hexToolStripMenuItem_Click(object sender, EventArgs e)
    {
        hexToolStripMenuItem.Checked = true;
        decToolStripMenuItem.Checked = false;
        _hex = true;
        _dirtyFlag = true;
    }

    private void decToolStripMenuItem_Click(object sender, EventArgs e)
    {
        decToolStripMenuItem.Checked = true;
        hexToolStripMenuItem.Checked = false;
        _hex = false;
        _dirtyFlag = true;
    }

    private void autoUpdateToolStripMenuItem_Click(object sender, EventArgs e)
    {
        autoUpdateToolStripMenuItem.Checked = !autoUpdateToolStripMenuItem.Checked;
        updateNowToolStripMenuItem.Enabled = !autoUpdateToolStripMenuItem.Checked;
        timer1.Enabled = autoUpdateToolStripMenuItem.Checked;
    }

    private void updateNowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        _ = ProcessText();
        txtOutput.Text = @"# Result:" + Environment.NewLine + Environment.NewLine + _lastResult;
        txtDisassembly.Text = @"# Disassembly:" + Environment.NewLine + Environment.NewLine + _lastDisassembly;
        lblStatus.Text = _lastMessage;
        Refresh();
        Cursor = Cursors.Default;
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;
        Refresh();

        try
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            var currentVersion = fieVersionInfo.FileVersion;

            if (currentVersion == null)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(this, @"Failed to get version information.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var httpClient = new System.Net.Http.HttpClient();

            try
            {
                var txt = httpClient.GetStringAsync("https://raw.githubusercontent.com/Anders-H/MkBin/refs/heads/master/MkBin/about.txt").Result;
                txt = txt.Replace("YOUR_VERSION_NUMBER", currentVersion);
                Cursor = Cursors.Default;
                MessageBox.Show(this, txt, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(this, $@"Failed to download the about text, but you are running version {currentVersion}.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch
        {
            // ignored
        }

        Cursor = Cursors.Default;
    }
}