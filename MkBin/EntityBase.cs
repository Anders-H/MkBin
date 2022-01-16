using System;

namespace MkBin;

public abstract class EntityBase
{
    public string Name { get; }

    protected EntityBase(string name)
    {
        Name = name;
    }

    public bool Is(string name) =>
        string.Compare(Name, name, StringComparison.CurrentCultureIgnoreCase) == 0;
}