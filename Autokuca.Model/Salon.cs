using System;
using System.Collections.Generic;

namespace Autokuca.Model;

public partial class Salon
{
    public int SalonId { get; set; }

    public string? Naziv { get; set; }

    public string? Adresa { get; set; }

    public string? RadnoVrijeme { get; set; }

    public string? Kontakt { get; set; }

    public string? AdminId { get; set; }

    public virtual ICollection<Vozilo> Vozilas { get; set; } = new List<Vozilo>();
}
