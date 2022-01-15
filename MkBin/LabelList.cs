using System.Collections.Generic;
using System.Linq;

namespace MkBin;

public class LabelList : List<Label>
{
    public bool Has(string v) =>
        this.Any(l => l.Is(v));

    public Label? Get(string v) =>
        this.FirstOrDefault(l => l.Is(v));
}