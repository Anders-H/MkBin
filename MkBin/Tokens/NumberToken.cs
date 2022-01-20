using System.Collections.Generic;
using System.Numerics;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class NumberToken : TokenBase
{
    public BigInteger Value { get; }
    public NumberType NumberType { get; }

    public NumberToken(string source, BigInteger value, NumberType numberType) :  base(source)
    {
        Value = value;
        NumberType = numberType;
    }

    public override int ByteLength
    {
        get
        {
            var bytes = new List<byte>();
            NumberCompiler.WriteNumeric(Value.ToString(), NumberType, ref bytes);
            return bytes.Count;
        }
    }
}