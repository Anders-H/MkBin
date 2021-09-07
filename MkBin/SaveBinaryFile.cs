using System.Windows.Forms;

namespace MkBin
{
    public partial class SaveBinaryFile : Form
    {
        private string _source;

        public string Filename =>
            txtTargetFile.Text;

        public SaveBinaryFile(string source)
        {
            _source = source;
            InitializeComponent();
        }

        private void SaveBinaryFile_Load(object sender, EventArgs e)
        {

        }

        private void chkRunIfSuccessful_CheckedChanged(object sender, EventArgs e)
        {
            txtRunIfSuccessful.Enabled = chkRunIfSuccessful.Checked;
        }
    }
}