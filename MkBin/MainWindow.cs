using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MkBin;

public partial class MainWindow : Form
{
    private string? _text;
    private bool _dirtyflag;
    private string _lastResult = "";
    private Task? _task;
    private string _lastDocumentFilename = "";

    public MainWindow()
    {
        InitializeComponent();
    }

    private void loadTextDescriptionOfBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void loadBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void saveTextDescriptionOfBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new SaveFileDialog();
        x.Title = @"Load text description of binary file";
        x.Filter = @"*.txt|*.txt|*.*|*.*";
        x.FileName = _lastDocumentFilename;
        if (x.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var options = new FileStreamOptions
                {
                    Mode = FileMode.Create
                };
                using var sw = new StreamWriter(x.FileName, Encoding.UTF8, options);
                sw.Write(txtInput.Text);
                sw.Flush();
                sw.Close();
                _lastDocumentFilename = x.FileName;
                Text = $@"{Text} - {_lastDocumentFilename}";
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
        if (!_dirtyflag)
            return;

        if (_task == null)
            _task = Task.Run(ProcessText);

        if (_task.IsCompletedSuccessfully)
        {
            txtOutput.Text = _lastResult;
            _task.Dispose();
            _task = Task.Run(ProcessText);
        }
    }

    private void ProcessText()
    {
        try
        {
            var binCompiler = new BinCompiler(txtInput.Text);
            var result = binCompiler.Compile();
            var s = new StringBuilder();

            for (var i = 0; i < result.Length; i++)
            {
                s.Append(result[i].ToString("X2"));
                s.Append(i >= result.Length - 1 || i % 8 == 7 ? Environment.NewLine : " ");
            }

            _lastResult = s.ToString();
        }
        catch (Exception e)
        {
            _lastResult = $"Failed to compile string!{Environment.NewLine}{e.Message}";
        }
    }

    private void DisplayResult()
    {
        txtOutput.Text = _lastResult;
    }

    private void MainWindow_Shown(object sender, EventArgs e)
    {
        timer1.Enabled = true;
    }

    private void txtInput_TextChanged(object sender, EventArgs e)
    {
        _dirtyflag = true;
    }

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) =>
        e.Cancel = _dirtyflag && MsgBox.AskQuit(this);

    private void MainWindow_Load(object sender, EventArgs e)
    {
        _text = Text;
    }

    private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (_dirtyflag && !MsgBox.AskNew(this))
            return;

        _lastDocumentFilename = "";
        txtInput.Text = "";
        Text = _text;
        _dirtyflag = false;
    }
}