using System.Collections.Generic;
using System.Text;

namespace MkBin.CompilerParts;

public class StringCompiler
{
    public static bool Compile(string input, ref List<byte> output)
    {
        if (input.StartsWith("\"") && input.EndsWith("\""))
        {
            output.AddRange(
                Encoding.UTF8.GetBytes(input[1..^1])
            );
            return true;
        }

        return false;
    }
}