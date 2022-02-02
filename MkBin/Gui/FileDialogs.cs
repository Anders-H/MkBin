using System.Windows.Forms;

namespace MkBin.Gui
{
    public static class FileDialogs
    {
        public static SaveFileDialog GetSaveTextFileDialog(string filename) =>
            new SaveFileDialog
            {
                Title = @"Save text description of binary file",
                Filter = @"*.txt|*.txt|*.*|*.*",
                FileName = filename
            };

        public static OpenFileDialog GetOpenTextFileDialog(string filename) =>
            new OpenFileDialog()
            {
                Title = @"Load text description of binary file",
                Filter = @"*.txt|*.txt|*.*|*.*",
                FileName = filename
            };
    }
}