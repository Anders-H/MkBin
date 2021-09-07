using System.Globalization;
using System.Text.RegularExpressions;

namespace MkBin
{
    public class BinCompiler
    {
        private List<string> _parts = new List<string>();

        public BinCompiler(string source)
        {
            _parts.Clear();
            var parts = Regex.Matches(source, @"[\""].+?[\""]|[^\s]+");
            
            foreach (Match part in parts)
                _parts.Add(part.Value);

            var newList = new List<string>();

            foreach (var t in _parts)
            {
                var p = t;
                var times = 1;

                var match = Regex.Match(p, @"\*[0-9]+$");

                if (match.Success)
                {
                    var lastIndex = p.LastIndexOf("*", StringComparison.Ordinal);
                    var timesString = p.Substring(lastIndex + 1);
                    var valueString = p.Substring(0, lastIndex);

                    if (!int.TryParse(timesString, out times))
                    {
                        throw new SystemException($"Failed to parse: {t}");
                    }

                    p = valueString;
                }

                var isString = p.StartsWith("\"") && p.EndsWith("\"");
                
                for (var j = 0; j < times; j++)
                    newList.Add(
                        (isString ? "\"" : "") + Regex.Replace(p, @"[^\w:/ ]", string.Empty) + (isString ? "\"" : "")
                    );
            }

            _parts = newList;
        }

        public byte[] Compile()
        {
            var currentType = NumberType.ByteType;
            var bytes = new List<byte>();
            foreach (var p in _parts.Select(part => part.Trim()))
            {
                if (p.StartsWith("\"") && p.EndsWith("\""))
                    bytes.AddRange(System.Text.Encoding.UTF8.GetBytes(p.Substring(1, p.Length - 2)));
                else if (IsNumeric(p))
                    WriteNumeric(p, currentType, ref bytes);
                else
                {
                    var c = GetNumberTypeFromControlWord(p);

                    if (c == null)
                        throw new Exception($"Unknown token: {p}");

                    currentType = c.Value;
                }
            }
            return bytes.ToArray();
        }

        private bool IsNumeric(string s) =>
            s.StartsWith("-")
                ? long.TryParse(s, out _)
                : ulong.TryParse(s, out _);

        private static void WriteNumeric(string n, NumberType type, ref List<byte> bytes)
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
}