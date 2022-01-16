using System.Collections.Generic;
using System.Linq;

namespace MkBin;

internal class AliasList : List<Alias>
{
    public bool Has(string v) =>
        this.Any(l => l.Is(v));

    public Alias? Get(string v) =>
        this.FirstOrDefault(l => l.Is(v));
}