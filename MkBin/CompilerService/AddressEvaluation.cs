using System;
using MkBin.Tokens;

namespace MkBin.CompilerService;

public class AddressEvaluation
{
    public void EvaluateAddresses(ref TokenList tokens)
    {
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
    }
}