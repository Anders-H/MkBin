using System;
using System.Collections.Generic;
using System.Globalization;

namespace MkBin;

internal class NumberCompiler
{
    public static bool Compile(string input, NumberType currentType, ref List<byte> output)
    {
        if (IsNumeric(input))
        {
            WriteNumeric(input, currentType, ref output);
            return true;
        }

        return false;
    }

    private static bool IsNumeric(string s) =>
        s.StartsWith("-")
            ? long.TryParse(s, out _)
            : ulong.TryParse(s, out _);

    internal static void WriteNumeric(string n, NumberType type, ref List<byte> bytes)
    {
        try
        {
            switch (type)
            {
                case NumberType.ByteType:
                    bytes.Add(byte.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture));
                    break;
                case NumberType.ShortType:
                    bytes.AddRange(BitConverter.GetBytes(short.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture)));
                    break;
                case NumberType.UShortType:
                    bytes.AddRange(BitConverter.GetBytes(ushort.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture)));
                    break;
                case NumberType.IntType:
                    bytes.AddRange(BitConverter.GetBytes(int.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture)));
                    break;
                case NumberType.UIntType:
                    bytes.AddRange(BitConverter.GetBytes(uint.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture)));
                    break;
                case NumberType.LongType:
                    bytes.AddRange(BitConverter.GetBytes(long.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture)));
                    break;
                case NumberType.ULongType:
                    bytes.AddRange(BitConverter.GetBytes(ulong.Parse(n, NumberStyles.Any, CultureInfo.CurrentCulture)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            throw ex;
        }
        catch
        {
            throw new Exception($"Failed to fit the value {n} into type {type}");
        }
    }
}