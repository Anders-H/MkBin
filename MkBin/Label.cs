using System.Numerics;

namespace MkBin;

public class Label : EntityBase
{
    public BigInteger Address { get; }

    public Label(string name, BigInteger address) : base(name)
    {
        Address = address;
    }
}