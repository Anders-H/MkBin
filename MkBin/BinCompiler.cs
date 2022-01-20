using MkBin.CompilerParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using MkBin.Tokens;

namespace MkBin;

public class BinCompiler
{
    private readonly List<string> _parts = new();
    private readonly AliasList _aliases = new();

    public BinCompiler(string source)
    {
        _parts.Clear();
        _aliases.Clear();

        var rows = source.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        foreach (var row in rows)
        {
            var r = (row ?? "").Trim();

            if (r.StartsWith('#'))
                continue;

            if (r.IndexOf('#') > -1)
                r = r.Substring(0, r.IndexOf('#')).Trim();

            var alias = AliasCompiler.Compile(r);
            if (alias != null)
            {
                _aliases.Add(alias);
                continue;
            }

            var parts = Regex.Matches(r, @"[\""].+?[\""]|[^\s]+");

            foreach (Match part in parts)
                _parts.Add(part.Value);
        }

        var newList = new List<string>();

        foreach (var t in _parts)
        {
            var toEvaluate = new List<string>();

            if (_aliases.Has(t))
            {
                var v = _aliases.Get(t)!.Value;
                var parts = Regex.Matches(v, @"[\""].+?[\""]|[^\s]+");

                foreach (Match part in parts)
                    toEvaluate.Add(part.Value);
            }
            else
            {
                toEvaluate.Add(t);
            }

            foreach (var iterator in toEvaluate)
            {
                var p = iterator;
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
        }

        _parts = newList;
    }

    public byte[] Compile()
    {
        var currentType = NumberType.ByteType;
        var addressType = currentType;
        BigInteger currentAddress = 0;
        var labels = new LabelList();
        var bytes = new List<byte>();

        // Pass 1: Create the tokens.
        var tokens = new TokenList();
        foreach (var p in _parts.Select(part => part.Trim()))
        {
            if (string.IsNullOrWhiteSpace(p))
                continue;

            var st = StringCompiler.GetToken(p);
            if (st != null)
            {
                tokens.Add(st);
                continue;
            }

            var nu = NumberCompiler.GetToken(p, currentType);
            if (nu != null)
            {
                tokens.Add(nu);
                continue;
            }

            var cw = ControlWordCompiler.GetToken(p);
            if (cw != null)
            {
                tokens.Add(cw);
                continue;
            }

            var setAdr = AddressCompiler.GetSetToken(p, currentType);
            if (setAdr != null)
            {
                tokens.Add(setAdr);
                continue;
            }

            var getAdr = AddressCompiler.GetGetToken(p, addressType);
            if (getAdr != null)
            {
                tokens.Add(getAdr);
                continue;
            }

            var setLbl = LabelCompiler.GetSetToken(p, ref labels);
            if (setLbl != null)
            {
                tokens.Add(setLbl);
                continue;
            }

            var getLbl = LabelCompiler.GetGetToken(p, ref labels, addressType);
            if (getLbl != null)
            {
                tokens.Add(getLbl);
                continue;
            }
        }

        // Pass 2: Normalize the addresses.

        // Pass 3: Calculate the byte lengths.


        // Pass 4: Generate the bytes.
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

            if (AddressCompiler.CompileSet(p, currentType, ref currentAddress))
            {
                addressType = currentType;
                continue;
            }

            if (AddressCompiler.CompileGet(p, addressType, currentAddress + bytes.Count - 1, ref bytes))
                continue;

            if (LabelCompiler.CompileSet(p, ref labels, currentAddress + bytes.Count - 1))
                continue;

            if (LabelCompiler.CompileGet(p, ref labels, addressType, ref bytes))
                continue;

            throw new Exception($"Unknown token: {p}");
        }
        return bytes.ToArray();
    }
}