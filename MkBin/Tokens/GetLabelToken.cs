using System.Collections.Generic;
using System.Numerics;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class GetLabelToken : TokenBase
{
    public BigInteger Value { get; set; }
    public NumberType NumberType { get; }

    public GetLabelToken(string source, NumberType numberType) : base(source)
    {
        Value = 0;
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