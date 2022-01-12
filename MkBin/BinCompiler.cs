using MkBin.CompilerParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MkBin;

public class BinCompiler
{
    private List<string> _parts = new List<string>();

    public BinCompiler(string source)
    {
        _parts.Clear();

        var rows = source.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {
            var r = (row ?? "").Trim();

            if (r.StartsWith('#'))
                continue;

            if (r.IndexOf('#') > -1)
                r = r.Substring(0, r.IndexOf('#')).Trim();

            var parts = Regex.Matches(r, @"[\""].+?[\""]|[^\s]+");

            foreach (Match part in parts)
                _parts.Add(part.Value);
        }

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
        var currentAddress = 0L;
        var addressType = NumberType.UShortType;

        var bytes = new List<byte>();

        foreach (var p in _parts.Select(part => part.Trim()))
        {
            if (string.IsNullOrWhiteSpace(p))
                continue;

            if (StringCompiler.Compile(p, ref bytes))
                continue;

            if (NumberCompiler.Compile(p, currentType, ref bytes))
                continue;

            if (ControlWordCompiler.Compile(p, ref currentType))
                continue;

            if (AddressCompiler.CompileSet(p, ref currentAddress))
            {
                addressType = currentType;
                continue;
            }

            if (AddressCompiler.CompileGet(p, addressType, currentAddress + bytes.Count, ref bytes))
                continue;

            throw new Exception($"Unknown token: {p}");
        }
        return bytes.ToArray();
    }
}