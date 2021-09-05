using System.Text;
using System.Windows.Forms;

namespace MkBin
{
    public partial class MainWindow : Form
    {
        private bool _dirtyflag = true;
        private string _lastResult = "";

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

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_dirtyflag)
                return;
            
            var processText = new Action(ProcessText);
            processText.BeginInvoke(ProcessTextCompleted, null);
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

        private void ProcessTextCompleted(IAsyncResult r)
        {
            Invoke(new Action(DisplayResult));
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
    }
}