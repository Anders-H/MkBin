using System.Collections.Generic;
using System.Numerics;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class NumberToken : TokenBase
{
    public BigInteger Value { get; }
    public NumberType NumberType { get; set; }

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

    public override byte[] GetBytes()
    {
        var result = new List<byte>();
        NumberCompiler.WriteNumeric(Value, NumberType, ref result);
        return result.ToArray();
    }

    public override string Disassembly =>
        $@"{DisassemblyAddressAsString}number {Value} as {NumberType}.";
}