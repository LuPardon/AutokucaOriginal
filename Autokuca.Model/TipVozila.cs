using System;
using System.Collections.Generic;

namespace Autokuca.Model;

public partial class TipVozila
{
    public int TipVozilaId { get; set; }

    public string? TipVozila1 { get; set; }

    public virtual ICollection<Vozilo> Vozilas { get; set; } = new List<Vozilo>();
}
