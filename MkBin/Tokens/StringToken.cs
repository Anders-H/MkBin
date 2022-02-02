using System.Collections.Generic;
using System.Text;

namespace MkBin.Tokens;

public class StringToken : TokenBase
{
    public string Value { get; }

    public override int ByteLength =>
        Value.Length;

    public StringToken(string source, string value) : base(source)
    {
        Value = value;
    }

    public override byte[] GetBytes()
    {
        var result = new List<byte>();
        result.AddRange(Encoding.UTF8.GetBytes(Value));
        return result.ToArray();
    }

    public override string Disassembly =>
        $@"{DisassemblyAddressAsString}in string format.";
}