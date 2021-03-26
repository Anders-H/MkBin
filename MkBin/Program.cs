using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MkBin
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const string Arguments = @"Arguments:

-source ""[Source filename]""
-target ""[Target filename]""

The source file is a text file containing the numbers or strings,
separated by space, to be written in binary format. The target file
is a binary file created from the content in the source file.
An existing target file will be overwritten, if possible.

Use the following words to change datatype:
byte (default), short, ushort, int, uint, long, ulong

Example: 1 2 int 3 byte 4
Result: 01 02 03 00 00 00 04 05

Example: ""Hello 7"" 7 6
Result: 48 65 6C 6C 6F 20 37 07 06

The following text cannot be compiled to a binary file because
the number 300 cannot be written as a byte: 100 200 300

The following text will create three 16-bit numbers: short 100 200 300
Result: 64 00 C8 00 2C 01

Example: long 1099226410751
Result: FF EE FF EE FF 00 00 00";

        [STAThread]
        private static int Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                var handle = GetConsoleWindow();
                ShowWindow(handle, 0);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());

                ShowWindow(handle, 5);
                return 0;
            }

            var argumentParser = new ArgumentParser(args);
            var sourceFilename = argumentParser.GetArgumentParameter("-source");
            var targetFilename = argumentParser.GetArgumentParameter("-target");
            var prompt = argumentParser.GetArgument("-prompt");
            var help = argumentParser.GetArgument("/?", "-?", "?", "help", "-help", "/help");
            if (!string.IsNullOrWhiteSpace(help))
            {
                Console.WriteLine(Arguments);
                return 0;
            }
            if (!string.IsNullOrWhiteSpace(prompt))
            {
                if (argumentParser.HasParameter("-source") || argumentParser.HasParameter("-target"))
                {
                    Console.WriteLine("Conflicting arguments.");
                    return 1;
                }

                do
                {
                    Console.Write("Text to bin: ");
                    var s = (Console.ReadLine() ?? "").Trim();
                    if (string.IsNullOrWhiteSpace(s))
                        return 0;
                    try
                    {
                        var comp = new BinCompiler(s);
                        var b = comp.Compile();
                        for (var i = 0; i < b.Length; i++)
                        {
                            Console.Write(b[i].ToString("X2"));
                            Console.Write(i >= b.Length - 1 ? "\n" : " ");
                        }
                        Console.WriteLine("Ok.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Failed. {e.Message}");
                    }
                } while (true);
            }
            if (string.IsNullOrWhiteSpace(sourceFilename))
            {
                Console.WriteLine(@"Missing argument: -source ""Filename""");
                return 1;
            }
            FileInfo sourceInfo;
            try
            {
                sourceInfo = new FileInfo(sourceFilename);
                if (!sourceInfo.Exists)
                {
                    Console.WriteLine("Source file does not exist.");
                    return 2;
                }
            }
            catch
            {
                Console.WriteLine($"Invalid source file: {sourceFilename}");
                return 3;
            }
            if (string.IsNullOrWhiteSpace(targetFilename))
            {
                Console.WriteLine(@"Missing argument: -target ""Filename""");
                return 4;
            }
            FileInfo targetInfo;
            try
            {
                targetInfo = new FileInfo(targetFilename);
            }
            catch
            {
                Console.WriteLine($"Invalid target file: {targetFilename}");
                return 7;
            }

            if (argumentParser.HasParameter("-totext"))
            {
                byte[] source;
                try
                {
                    source = File.ReadAllBytes(sourceFilename);
                }
                catch
                {
                    Console.WriteLine($"Failed to load: {sourceInfo.FullName}");
                    return 8;
                }
                var textGenerator = new TextGenerator(source);
                string result;
                try
                {
                    result = textGenerator.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 8;
                }
                try
                {
                    if (targetInfo.Exists)
                        targetInfo.Delete();
                }
                catch
                {
                    Console.WriteLine($"Failed to delete existing target file: {targetInfo.FullName}");
                    return 9;
                }
                try
                {
                    using (var sw = new StreamWriter(targetFilename, false, Encoding.UTF8))
                    {
                        sw.Write(result);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch
                {
                    Console.WriteLine($"Failed to write file: {targetInfo.FullName}");
                    return 10;
                }
            }
            else
            {
                string source;
                try
                {
                    using (var sw = new StreamReader(sourceInfo.FullName))
                    {
                        source = sw.ReadToEnd();
                        sw.Close();
                    }
                }
                catch
                {
                    Console.WriteLine($"Failed to load: {sourceInfo.FullName}");
                    return 8;
                }
                var compiler = new BinCompiler(source);
                byte[] bytes;
                try
                {
                    bytes = compiler.Compile();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 8;
                }
                try
                {
                    if (targetInfo.Exists)
                        targetInfo.Delete();
                }
                catch
                {
                    Console.WriteLine($"Failed to delete existing target file: {targetInfo.FullName}");
                    return 9;
                }
                try
                {
                    using (var bw = new BinaryWriter(targetInfo.OpenWrite()))
                    {
                        bw.Write(bytes);
                        bw.Flush();
                        bw.Close();
                    }
                }
                catch
                {
                    Console.WriteLine($"Failed to write file: {targetInfo.FullName}");
                    return 10;
                }
            }

            Console.WriteLine("Ok.");
            return 0;
        }
    }
}