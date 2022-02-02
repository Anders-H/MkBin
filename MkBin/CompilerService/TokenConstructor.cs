using System;
using System.Collections.Generic;
using System.Linq;
using MkBin.CompilerParts;
using MkBin.Tokens;

namespace MkBin.CompilerService
{
    public class TokenConstructor
    {
        private readonly List<string> _parts;

        public TokenConstructor(List<string> parts)
        {
            _parts = parts;
        }

        public TokenList GetTokens()
        {
            var currentType = NumberType.ByteType;
            var addressType = NumberType.UShortType;

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
                    currentType = cw.Value;
                    addressType = cw.Value;
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

                var setLbl = LabelCompiler.GetSetToken(p);
                if (setLbl != null)
                {
                    tokens.Add(setLbl);
                    continue;
                }

                var getLbl = LabelCompiler.GetGetToken(p, addressType);
                if (getLbl != null)
                {
                    tokens.Add(getLbl);
                    continue;
                }

                throw new SystemException($@"Failed to parse: {p}");
            }

            return tokens;
        }
    }
}