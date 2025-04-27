using System.Globalization;
using MkBin.Tokens;

namespace MkBin.CompilerParts;

internal class ControlWordCompiler
{
    public static bool Compile(string input, ref NumberType currentType)
    {
        var c = GetNumberTypeFromControlWord(input);

        if (c == null)
            return false;

        currentType = c.Value;
        return true;
    }

    public static ControlWordToken? GetToken(string input)
    {
        var n = GetNumberTypeFromControlWord(input);
        
        return n == null
            ? null
            : new ControlWordToken(input, n.Value);
    }

    private static NumberType? GetNumberTypeFromControlWord(string n)
    {
        switch ((n ?? "").Trim().ToLower(CultureInfo.CurrentCulture))
        {
            case "byte":
            case "8bit":
            case "8-bit":
                return NumberType.ByteType;
            case "short":
            case "16bit":
            case "16-bit":
                return NumberType.ShortType;
            case "ushort":
                return NumberType.UShortType;
            case "int":
            case "integer":
            case "32bit":
            case "32-bit":
                return NumberType.IntType;
            case "uint":
                return NumberType.UIntType;
            case "long":
            case "64bit":
            case "64-bit":
                return NumberType.LongType;
            case "ulong":
                return NumberType.ULongType;
        }
        return null;
    }
}