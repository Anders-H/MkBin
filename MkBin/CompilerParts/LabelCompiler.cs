using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace MkBin.CompilerParts
{
    public class LabelCompiler
    {
        public static bool CompileSet(string input, ref LabelList labels, BigInteger currentAddress)
        {
            var i = input.ToLower();
            var match = Regex.Match(i, @"^setlbl:([a-z0-9]+)$");

            if (match.Success)
            {
                var v = match.Groups[1].Value.Trim();
                
                if (string.IsNullOrEmpty(v))
                    throw new Exception("Empty label name.");

                if (labels.Has(v))
                    throw new Exception($"Duplicate label: {v}");

                labels.Add(new Label(v, currentAddress));
                return true;
            }

            return false;
        }

        public static bool CompileGet(string input, ref LabelList labels, NumberType addressType, ref List<byte> output)
        {
            var i = input.ToLower();
            var match = Regex.Match(i, @"^lbl:([a-z0-9]+)$");

            if (match.Success)
            {
                var v = match.Groups[1].Value;
                if (!labels.Has(v))
                    throw new Exception($"Missing label: {v}");

                var result = labels.Get(v)!.Address;
                NumberCompiler.WriteNumeric(result.ToString(), addressType, ref output);
                return true;
            }

            return false;
        }
    }
}