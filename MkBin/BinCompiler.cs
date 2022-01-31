﻿using MkBin.CompilerParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MkBin.CompilerService;
using MkBin.Tokens;

namespace MkBin;

public class BinCompiler
{
    private readonly List<string> _parts;
    private StringBuilder? _disassembly;

    public BinCompiler(string source)
    {
        _parts = new StringSplitter(source)
            .GetParts();
    }

    public byte[] Compile()
    {
        _disassembly = new StringBuilder();

        var currentType = NumberType.ByteType;
        var addressType = NumberType.UShortType;

        // Pass 1: Create the tokens.
        var tokens = new TokenList();
        foreach (var p in _parts.Select(part => part.Trim()))
        {
            if (string.IsNullOrWhiteSpace(p))
                continue;

            var st = StringCompiler.GetToken(p);
            if (st != null)
            {
                tokens.Add(st);
                continue;
            }

            var nu = NumberCompiler.GetToken(p, currentType);
            if (nu != null)
            {
                tokens.Add(nu);
                continue;
            }

            var cw = ControlWordCompiler.GetToken(p);
            if (cw != null)
            {
                tokens.Add(cw);
                continue;
            }

            var setAdr = AddressCompiler.GetSetToken(p, currentType);
            if (setAdr != null)
            {
                tokens.Add(setAdr);
                continue;
            }

            var getAdr = AddressCompiler.GetGetToken(p, addressType);
            if (getAdr != null)
            {
                tokens.Add(getAdr);
                continue;
            }

            var setLbl = LabelCompiler.GetSetToken(p);
            if (setLbl != null)
            {
                tokens.Add(setLbl);
                continue;
            }

            var getLbl = LabelCompiler.GetGetToken(p, addressType);
            if (getLbl != null)
            {
                tokens.Add(getLbl);
                continue;
            }

            throw new SystemException($@"Failed to parse: {p}");
        }

        // Pass 2: Evaluate the addresses.
        var startAddress = tokens.GetStartAddress();

        if (startAddress is byte b)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = b;
                b += (byte)token.ByteLength;
            }
        }
        else if (startAddress is short s)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = s;
                s += (byte)token.ByteLength;
            }
        }
        else if (startAddress is ushort us)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = us;
                us += (byte)token.ByteLength;
            }
        }
        else if (startAddress is int i)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = i;
                i += (byte)token.ByteLength;
            }
        }
        else if (startAddress is uint ui)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = ui;
                ui += (byte)token.ByteLength;
            }
        }
        else if (startAddress is long l)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = l;
                l += (byte)token.ByteLength;
            }
        }
        else if (startAddress is ulong ul)
        {
            foreach (var token in tokens)
            {
                token.StartAddress = ul;
                ul += (byte)token.ByteLength;
            }
        }
        else
        {
            throw new SystemException($@"Unknown address type: {startAddress.GetType().Name}");
        }

        // Pass 3: Evaluate the labels.
        foreach (var token in tokens)
        {
            if (token is SetLabelToken slt && tokens.GetLabelCount(slt.LabelName) > 1)
                throw new SystemException($@"Label declared more than once: {slt.LabelName}");
            if (token is GetLabelToken glt && tokens.GetLabelCount(glt.LabelName) < 1)
                throw new SystemException($@"Label not found: {glt.LabelName}");
        }

        foreach (var token in tokens)
            if (token is GetLabelToken glt)
                glt.Value = tokens.GetAddressFromLabel(glt.LabelName);

        // Pass 4: Generate the bytes.
        var bytes = new List<byte>();

        var currentNumberFormat = NumberType.ByteType;

        foreach (var token in tokens)
        {
            if (token is ControlWordToken cwt)
                currentNumberFormat = cwt.Value;
            else if (token is NumberToken nt)
                nt.NumberType = currentNumberFormat;

            _disassembly.AppendLine(token.Disassembly);

            bytes.AddRange(token.GetBytes());
        }

        return bytes.ToArray();
    }

    public string Disassembly =>
        _disassembly.ToString().Trim();
}