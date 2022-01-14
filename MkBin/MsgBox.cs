using System.Windows.Forms;

namespace MkBin
{
    public class MsgBox
    {
        public static bool AskNew(Form owner) =>
            MessageBox.Show(
                owner,
                @"You have unsaved work. Are you sure you want to start working on a new document?",
                owner.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            ) == DialogResult.Yes;

        public static bool AskQuit(Form owner) =>
            MessageBox.Show(
                owner,
                @"You have unsaved work. Are you sure you want to quit?",
                owner.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            ) != DialogResult.Yes;

        public static void SaveFailed(Form owner, string message) =>
            MessageBox.Show(
                owner,
                message,
                @"Save failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
    }
}