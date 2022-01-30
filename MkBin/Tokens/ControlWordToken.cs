using System;

namespace MkBin.Tokens;

internal class ControlWordToken : TokenBase
{
    public override int ByteLength =>
        0;

    public NumberType Value { get; }

    public ControlWordToken(string source, NumberType value) : base(source)
    {
        Value = value;
    }

    public override byte[] GetBytes() =>
        Array.Empty<byte>();
}