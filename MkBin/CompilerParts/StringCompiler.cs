using System.Collections.Generic;
using System.Text;
using MkBin.Tokens;

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

    public static StringToken? GetToken(string input)
    {
        if (input.StartsWith("\"") && input.EndsWith("\""))
        {
            var value = Encoding.UTF8.GetString(
                Encoding.UTF8.GetBytes(input[1..^1])
            );

            return new StringToken(value);
        }

        return null;
    }
}