using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MkBin.Tokens;

public class TokenList : List<TokenBase>
{
    public object GetStartAddress()
    {
        var found = new List<SetAddressToken>();
        var type = NumberType.UShortType;
        
        foreach (var t in this)
        {
            if (t is ControlWordToken cwt && found.Count <= 0)
            {
                type = cwt.Value;
                continue;
            }

            if (t is SetAddressToken sat)
            {
                sat.NumberType = type;
                found.Add(sat);
            }
        }

        if (found.Count == 0)
            return (byte)0;

        if (found.Count == 1)
        {
            var sat = found.First();

            foreach (var token in this)
            {
                if (token is GetAddressToken gat)
                    gat.NumberType = sat.NumberType;
                else if (token is GetLabelToken glt)
                    glt.NumberType = sat.NumberType;
            }

            if (sat.NumberType == NumberType.ByteType)
                return (byte)sat.Value;

            if (sat.NumberType == NumberType.ShortType)
                return (short)sat.Value;

            if (sat.NumberType == NumberType.UShortType)
                return (ushort)sat.Value;

            if (sat.NumberType == NumberType.IntType)
                return (int)sat.Value;

            if (sat.NumberType == NumberType.UIntType)
                return (uint)sat.Value;

            if (sat.NumberType == NumberType.LongType)
                return (long)sat.Value;

            if (sat.NumberType == NumberType.ULongType)
                return (ulong)sat.Value;

            throw new SystemException(@"Unknown address type.");
        }

        throw new SystemException("Multiple address declarations.");
    }

    public int GetLabelCount(string name)
    {
        var count = 0;

        foreach (var token in this)
            if (token is SetLabelToken slt)
                if (string.Compare(slt.LabelName, name, StringComparison.CurrentCultureIgnoreCase) == 0)
                    count++;

        return count;
    }

    public TokenBase? GetTokenFromLabel(string labelName)
    {
        foreach (var token in this)
            if (token is SetLabelToken slt && string.Compare(slt.LabelName, labelName, StringComparison.CurrentCultureIgnoreCase) == 0)
                return token;

        return null;
    }

    public BigInteger GetAddressFromLabel(string labelName) =>
        GetTokenFromLabel(labelName)?.StartAddress ?? 0;
}