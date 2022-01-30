using System.Collections.Generic;
using System.Numerics;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class GetLabelToken : TokenBase
{
    public string LabelName { get; }
    public NumberType NumberType { get; }
    public BigInteger Value { get; set; }

    public GetLabelToken(string source, string labelName, NumberType numberType) : base(source)
    {
        LabelName = labelName;
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