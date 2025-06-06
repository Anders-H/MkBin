﻿using System;
using System.IO;
using System.Windows.Forms;

namespace MkBin;

public partial class SaveBinaryFile : Form
{
    private readonly string _source;
    private byte[]? _bytes;
    private static string TargetFile { get; set; }
    private static string RunIfSuccessful { get; set; }
    private static bool RunIfSuccessfulEnabled { get; set; }

    static SaveBinaryFile()
    {
        TargetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "target.bin");
        RunIfSuccessful = "notepad.exe {filename}";
        RunIfSuccessfulEnabled = false;
    }

    public SaveBinaryFile(string source)
    {
        _source = source;
        InitializeComponent();
    }

    private void SaveBinaryFile_Load(object sender, EventArgs e)
    {
        txtTargetFile.Text = TargetFile;
        txtRunIfSuccessful.Text = RunIfSuccessful;
        chkRunIfSuccessful.Checked = RunIfSuccessfulEnabled;
    }

    private void chkRunIfSuccessful_CheckedChanged(object sender, EventArgs e)
    {
        txtRunIfSuccessful.Enabled = chkRunIfSuccessful.Checked;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (_bytes is not { Length: > 0 })
        {
            MessageBox.Show(this, @"You have nothing to save.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var success = false;

        try
        {
            Storage.SaveBytes(txtTargetFile.Text, _bytes);
            success = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, @"Save failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        TargetFile = txtTargetFile.Text;
        RunIfSuccessful = txtRunIfSuccessful.Text;
        RunIfSuccessfulEnabled = chkRunIfSuccessful.Checked;

        if (success)
            DialogResult = DialogResult.OK;
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        using var x = new SaveFileDialog();
        x.Title = @"Binary output file";
        x.FileName = txtTargetFile.Text;
        x.Filter = @"*.*|*.*";

        if (x.ShowDialog(this) == DialogResult.OK)
            txtTargetFile.Text = x.FileName;
    }

    private void SaveBinaryFile_Shown(object sender, EventArgs e)
    {
        btnOk.Enabled = false;
        Cursor = Cursors.WaitCursor;
        txtCompile.Text = "";
        Refresh();
        Application.DoEvents();
        _bytes = null;
        var x = new BinCompiler(_source);
        var success = false;

        try
        {
            _bytes = x.Compile();
            txtCompile.Text = @"Ok.";
            success = true;
        }
        catch (Exception ex)
        {
            txtCompile.Text = ex.Message;
        }

        btnOk.Enabled = success;
        Cursor = Cursors.Default;
    }
}