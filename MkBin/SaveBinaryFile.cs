using System.Windows.Forms;

namespace MkBin
{
    public partial class SaveBinaryFile : Form
    {
        private string _source;

        private static string TargetFile { get; set; }
        private static string RunIfSuccessful { get; set; }
        private static bool RunIfSuccessfulEnabled { get; set; }

        public string Filename =>
            txtTargetFile.Text;

        static SaveBinaryFile()
        {
            TargetFile = "";
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
            txtTargetFile.Text = string.IsNullOrWhiteSpace(TargetFile)
                ? txtTargetFile.Text
                : $"{_source}.bin";

            txtRunIfSuccessful.Text = RunIfSuccessful;
            chkRunIfSuccessful.Checked = RunIfSuccessfulEnabled;
        }

        private void chkRunIfSuccessful_CheckedChanged(object sender, EventArgs e)
        {
            txtRunIfSuccessful.Enabled = chkRunIfSuccessful.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TargetFile = txtTargetFile.Text;
            RunIfSuccessful = txtRunIfSuccessful.Text;
            RunIfSuccessfulEnabled = chkRunIfSuccessful.Checked;
        }
    }
}