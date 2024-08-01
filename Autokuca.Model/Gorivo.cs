using System;
using System.Collections.Generic;

namespace Autokuca.Model;

public partial class Gorivo
{
    public int GorivoId { get; set; }

    public string? TipGoriva { get; set; }

    public virtual ICollection<Vozilo> Vozilas { get; set; } = new List<Vozilo>();
}
