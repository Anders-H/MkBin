using System.Collections.Generic;
using System.Numerics;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class GetLabelToken : TokenBase
{
    public string LabelName { get; }
    public NumberType NumberType { get; set; }
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

    public override byte[] GetBytes()
    {
        var result = new List<byte>();
        NumberCompiler.WriteNumeric(Value, NumberType, ref result);
        return result.ToArray();
    }

    public override string Disassembly =>
        $@"{DisassemblyAddressAsString}read out address of label ""{LabelName}"", which is {Value} ({NumberType}).";
}