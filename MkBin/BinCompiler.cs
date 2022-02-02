using System;
using System.Collections.Generic;
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

        // Pass 1: Create the tokens.
        var tokens = new TokenConstructor(_parts)
            .GetTokens();

        if (tokens is { Count: <= 0 })
            return Array.Empty<byte>();

        // Pass 2: Evaluate the addresses.
        new AddressEvaluation()
            .EvaluateAddresses(ref tokens);

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
        _disassembly?.ToString().Trim() ?? "";
}