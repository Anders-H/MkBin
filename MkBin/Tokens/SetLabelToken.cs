﻿using System;
using System.Numerics;

namespace MkBin.Tokens;

public class SetLabelToken : TokenBase
{
    public string LabelName { get; }

    public SetLabelToken(string source, string labelName) : base(source)
    {
        LabelName = labelName;
    }

    public override int ByteLength =>
        0;

    public override byte[] GetBytes() =>
        Array.Empty<byte>();


    public override string Disassembly =>
        $@"{DisassemblyAddressAsString}label ""{LabelName}"" points here.";
}