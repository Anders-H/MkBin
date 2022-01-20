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
}