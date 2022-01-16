using System.Collections.Generic;
using System.Linq;

namespace MkBin;

public class BitDecompiler
{
    private readonly byte[]? _bytes;

    public BitDecompiler(byte[]? bytes)
    {
        _bytes = bytes;
    }

    public string Decompile()
    {
        if (_bytes == null || _bytes.Length <= 0)
            return "";

        var strings = new List<string>();

        if (_bytes.Length <= 8)
        {
            strings.AddRange(_bytes.Select(b => b.ToString("00")));
            return string.Join(' ', strings);
        }

        var pointer = 0;
        do
        {
            var sameCount = 0;
            var startByte = _bytes[pointer];

            if (pointer >= _bytes.Length - 1)
            {
                strings.Add(startByte.ToString());
                pointer++;
            }
            else
            {
                for (var i = pointer; i < _bytes.Length; i++)
                {
                    if (_bytes[i] == startByte)
                    {
                        sameCount++;
                        pointer++;
                        if (pointer >= _bytes.Length)
                        {
                            strings.Add(
                                sameCount > 1
                                    ? $"{startByte}*{sameCount}"
                                    : startByte.ToString()
                            );
                        }
                    }
                    else
                    {
                        strings.Add(
                            sameCount > 1
                                ? $"{startByte}*{sameCount}"
                                : startByte.ToString()
                        );
                        break;
                    }
                }
            }
        } while (pointer < _bytes.Length);

        return string.Join(' ', strings);
    }
}