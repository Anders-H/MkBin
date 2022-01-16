using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace MkBin.CompilerParts;

public static class AddressCompiler
{
    public static bool CompileSet(string input, NumberType currentType, ref BigInteger currentAddress)
    {
        var i = input.ToLower();
        var match = Regex.Match(i, @"^setadr:([0-9]+)$");
        
        if (match.Success)
        {
            var v = match.Groups[1].Value;
            try
            {
                var parsed = BigInteger.Parse(v);

                try
                {
                    var temp = new List<byte>();
                    NumberCompiler.WriteNumeric(v, currentType, ref temp);
                }
                catch
                {
                    throw new Exception($"Address {v} cannot fit in type {currentType}.");
                }

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