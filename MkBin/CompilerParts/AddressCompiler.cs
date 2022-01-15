using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace MkBin.CompilerParts;

public static class AddressCompiler
{
    public static bool CompileSet(string input, ref BigInteger currentAddress)
    {
        var i = input.ToLower();
        var match = Regex.Match(i, @"^setadr:([0-9]+)$");
        
        if (match.Success)
        {
            var v = match.Groups[1].Value;
            try
            {
                var parsed = BigInteger.Parse(v);
                currentAddress = parsed;
                return true;
            }
            catch
            {
                throw new Exception($"SetAdr with value {v} failed.");
            }
        }

        return false;
    }

    public static bool CompileGet(string input, NumberType currentType, BigInteger currentValue, ref List<byte> output)
    {
        if (string.Compare(input, "adr", StringComparison.CurrentCultureIgnoreCase) != 0)
            return false;

        NumberCompiler.WriteNumeric(currentValue.ToString(), currentType, ref output);
        return true;
    }
}