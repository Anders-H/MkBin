using MkBin.Tokens;
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

        public static SetLabelToken? GetSetToken(string input)
        {
            var i = input.ToLower();
            var match = Regex.Match(i, @"^setlbl:([a-z0-9]+)$");
            
            if (match.Success)
            {
                var v = match.Groups[1].Value.Trim();
                return new SetLabelToken(input, v);
            }

            return null;
        }

        public static bool CompileGet(string input, ref LabelList labels, NumberType addressType, ref List<byte> output)
        {
            var match = Regex.Match(input, @"^(?i)lbl:([a-z0-9]+)$");

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

        public static GetLabelToken? GetGetToken(string input, NumberType addressType)
        {
            var match = Regex.Match(input, @"^(?i)lbl:([a-z0-9]+)$");

            if (match.Success)
                return new GetLabelToken(input, match.Groups[1].Value, addressType);

            return null;
        }
    }
}