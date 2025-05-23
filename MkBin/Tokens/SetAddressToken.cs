﻿using System.Numerics;

namespace MkBin.Tokens;

public class SetAddressToken : TokenBase
{
    public BigInteger Value { get; }
    public NumberType NumberType { set; get; }

    public SetAddressToken(string source, BigInteger value, NumberType numberType) : base(source)
    {
        Value = value;
        NumberType = numberType;
    }

    public override int ByteLength =>
        0;

    public override byte[] GetBytes() =>
        [];

    public override string Disassembly =>
        $@"{DisassemblyAddressAsString}set start address to {Value} in {NumberType} format.";
}