using System.Numerics;

namespace MkBin;

public class Label
{
    public string Name { get; }
    public BigInteger Address { get; }

    public Label(string name, BigInteger address)
    {
        Name = name;
        Address = address;
    }
}