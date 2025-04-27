using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using MkBin.CompilerParts;

namespace MkBin.CompilerService;

public class StringSplitter
{
    private readonly string _source;

    public StringSplitter(string source)
    {
        _source = source;
    }

    public List<string> GetParts()
    {
        var rows = _source.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        var aliases = new AliasList();
        var result = new List<string>();

        foreach (var row in rows)
        {
            var r = row.Trim();

            if (r.StartsWith('#'))
                continue;

            if (r.IndexOf('#') > -1)
                r = r.Substring(0, r.IndexOf('#')).Trim();

            var alias = AliasCompiler.Compile(r);
            if (alias != null)
            {
                aliases.Add(alias);
                continue;
            }

            var parts = Regex.Matches(r, @"[\""].+?[\""]|[^\s]+");

            foreach (Match part in parts)
                result.Add(part.Value);
        }

        var newList = new List<string>();

        foreach (var t in result)
        {
            var toEvaluate = new List<string>();

            if (aliases.Has(t))
            {
                var v = aliases.Get(t)!.Value;
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
                        throw new SystemException($"Failed to parse: {t}");

                    p = valueString;
                }

                var isString = p.StartsWith("\"") && p.EndsWith("\"");

                for (var j = 0; j < times; j++)
                    newList.Add(
                        (isString ? "\"" : "") + Regex.Replace(p, @"[^\w:/ ]", string.Empty) + (isString ? "\"" : "")
                    );
            }
        }

        return newList;
    }
}