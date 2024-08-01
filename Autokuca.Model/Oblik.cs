using System;
using System.Collections.Generic;

namespace Autokuca.Model;

public partial class Oblik
{
    public int OblikId { get; set; }

    public string? TipOblika { get; set; }

    public virtual ICollection<Vozilo> Vozilas { get; set; } = new List<Vozilo>();
}
