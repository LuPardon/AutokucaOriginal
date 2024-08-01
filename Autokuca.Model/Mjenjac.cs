using System;
using System.Collections.Generic;

namespace Autokuca.Model;

public partial class Mjenjac
{
    public int MjenjacId { get; set; }

    public string? TipMjenjaca { get; set; }

    public virtual ICollection<Vozilo> Vozilas { get; set; } = new List<Vozilo>();
}
