using System.Text.RegularExpressions;

namespace MkBin.CompilerParts;

public class AliasCompiler
{
    public static Alias? Compile(string raw)
    {
        var match = Regex.Match(raw, @"(?i)^alias:([a-z0-9]+)\s+(.+)$");

        if (!match.Success)
            return null;

        return new Alias(
            match.Groups[1].Value.Trim(),
            match.Groups[2].Value.Trim()
        );
    }
}