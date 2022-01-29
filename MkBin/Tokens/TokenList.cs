using System;
using System.Collections.Generic;
using System.Linq;

namespace MkBin.Tokens;

public class TokenList : List<TokenBase>
{
    public object GetStartAddress()
    {
        var found = new List<SetAddressToken>();
        var type = NumberType.UShortType;

        foreach (var t in this)
        {
            if (t is ControlWordToken cwt)
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

            if (sat.NumberType == NumberType.ByteType)
                return (byte)sat.StartAddress;
            
            if (sat.NumberType == NumberType.ShortType)
                return (short)sat.StartAddress;

            if (sat.NumberType == NumberType.UShortType)
                return (ushort)sat.StartAddress;

            if (sat.NumberType == NumberType.IntType)
                return (int)sat.StartAddress;

            if (sat.NumberType == NumberType.UIntType)
                return (uint)sat.StartAddress;

            if (sat.NumberType == NumberType.LongType)
                return (long)sat.StartAddress;

            if (sat.NumberType == NumberType.ULongType)
                return (ulong)sat.StartAddress;

            throw new SystemException(@"Unknown address type.");
        }

        throw new SystemException("Multiple address declarations.");
    }
}