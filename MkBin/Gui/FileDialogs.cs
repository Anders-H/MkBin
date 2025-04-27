using System.Windows.Forms;

namespace MkBin.Gui;

public static class FileDialogs
{
    public static SaveFileDialog GetSaveTextFileDialog(string filename) =>
        new()
        {
            Title = @"Save text description of binary file",
            Filter = @"*.txt|*.txt|*.*|*.*",
            FileName = filename
        };

    public static OpenFileDialog GetOpenTextFileDialog(string filename) =>
        new()
        {
            Title = @"Load text description of binary file",
            Filter = @"*.txt|*.txt|*.*|*.*",
            FileName = filename
        };
}