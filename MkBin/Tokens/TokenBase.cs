using System.Numerics;

namespace MkBin.Tokens;

public abstract class TokenBase
{
    public BigInteger StartAddress { get; set; }
    public abstract int ByteLength { get; }
    public string Source { get; }

    protected TokenBase(string source)
    {
        Source = source;
    }

    public abstract byte[] GetBytes();

    public abstract string Disassembly { get; }

    protected string DisassemblyAddressAsString =>
        $@"{StartAddress:00000} {StartAddress:X04}: Length: {ByteLength} bytes, source: ""{Source}"", ";
}