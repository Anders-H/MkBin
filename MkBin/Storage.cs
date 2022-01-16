using System.IO;
using System.Text;

namespace MkBin;

public class Storage
{
    public static string LoadText(string filename)
    {
        using var sr = new StreamReader(filename, Encoding.UTF8);
        var t = sr.ReadToEnd();
        sr.Close();
        return t;
    }

    public static string LoadBinAsText(string filename)
    {
        var bytes = File.ReadAllBytes(filename);
        var decompiler = new BitDecompiler(bytes);
        var result = decompiler.Decompile();
        return result;
    }

    public static void SaveText(string filename, string text)
    {
        var options = new FileStreamOptions
        {
            Mode = FileMode.Create
        };
        using var sw = new StreamWriter(filename, Encoding.UTF8, options);
        sw.Write(text);
        sw.Flush();
        sw.Close();
    }

    public static void SaveBytes(string filename, byte[] bytes)
    {
        var targetInfo = new FileInfo(filename);
        using var bw = new BinaryWriter(targetInfo.OpenWrite());
        bw.Write(bytes);
        bw.Flush();
        bw.Close();
    }
}