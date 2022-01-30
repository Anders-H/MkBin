using System.Collections.Generic;
using System.Numerics;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class GetAddressToken : TokenBase
{
    public BigInteger Value { get; set; }
    public NumberType NumberType { get; set; }

    public GetAddressToken(string source, NumberType numberType) : base(source)
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

    public override byte[] GetBytes()
    {
        var result = new List<byte>();
        NumberCompiler.WriteNumeric(Value, NumberType, ref result);
        return result.ToArray();
    }
}