using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkBin;

public partial class MainWindow : Form
{
    private string? _text;
    private bool _dirtyFlag;
    private bool _unsaved;
    private string _lastResult = "";
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

        using var x = new OpenFileDialog();
        x.Title = @"Load text description of binary file";
        x.Filter = @"*.txt|*.txt|*.*|*.*";
        x.FileName = _lastDocumentFilename;
        
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
        using var x = new SaveFileDialog();
        x.Title = @"Save text description of binary file";
        x.Filter = @"*.txt|*.txt|*.*|*.*";
        x.FileName = _lastDocumentFilename;
        if (x.ShowDialog(this) == DialogResult.OK)
        {
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
            txtOutput.Text = _lastResult;
            lblStatus.Text = _lastMessage;
            _task.Dispose();
            _task = Task.Run(ProcessText);
        }
    }

    private bool ProcessText()
    {
        try
        {
            var binCompiler = new BinCompiler(txtInput.Text);
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
            return true;
        }
        catch (Exception e)
        {
            _lastResult = $"Failed to compile string!{Environment.NewLine}{e.Message}";
            _lastMessage = e.Message;
            return false;
        }
    }

    private void MainWindow_Shown(object sender, EventArgs e)
    {
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

            var files = (string[])e.Data!.GetData(DataFormats.FileDrop);
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
            var files = (string[])e.Data!.GetData(DataFormats.FileDrop);
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
        var result = ProcessText();
        txtOutput.Text = _lastResult;
        lblStatus.Text = _lastMessage;
        Refresh();
        Cursor = Cursors.Default;
    }
}