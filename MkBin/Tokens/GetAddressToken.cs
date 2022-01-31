using System.Collections.Generic;
using MkBin.CompilerParts;

namespace MkBin.Tokens;

public class GetAddressToken : TokenBase
{
    public NumberType NumberType { get; set; }

    public GetAddressToken(string source, NumberType numberType) : base(source)
    {
        NumberType = numberType;
    }

    public override int ByteLength
    {
        get
        {
            var bytes = new List<byte>();
            NumberCompiler.WriteNumeric(StartAddress, NumberType, ref bytes);
            return bytes.Count;
        }
    }

    public override byte[] GetBytes()
    {
        var result = new List<byte>();
        NumberCompiler.WriteNumeric(StartAddress, NumberType, ref result);
        return result.ToArray();
    }

    public override string Disassembly =>
        $@"{DisassemblyAddressAsString}read out current address: {StartAddress} ({NumberType}).";
}