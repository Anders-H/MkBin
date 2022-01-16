namespace MkBin;

public class Alias : EntityBase
{
    public string Value { get; }

    public Alias(string name, string value) : base(name)
    {
        Value = value;
    }
}