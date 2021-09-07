using System.Text;
using System.Windows.Forms;

namespace MkBin
{
    public partial class MainWindow : Form
    {
        private bool _dirtyflag = false;
        private string _lastResult = "";
        private Task? _task = null;
        private string _lastDocumentFilename = "";
        private string _lastBinaryFilename = "";

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

        }

        private void saveBinaryFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var x = new SaveBinaryFile(txtInput.Text);

            if (x.ShowDialog(this) == DialogResult.OK)
                _lastBinaryFilename = x.Filename;
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
                _task = Task.Run(() => ProcessText());

            if (_task.IsCompletedSuccessfully)
            {
                txtOutput.Text = _lastResult;
                _task.Dispose();
                _task = Task.Run(() => ProcessText());
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dirtyflag)
            {
                if (MessageBox.Show(this, @"You have unsaved work. Are you sure you want to quit?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
    }
}