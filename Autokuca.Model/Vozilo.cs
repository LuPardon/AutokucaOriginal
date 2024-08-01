using System;
using System.Collections.Generic;

namespace Autokuca.Model;

public partial class Vozilo
{
    public int VoziloId { get; set; }

    public int? SalonId { get; set; }

    public string? Proizvodac { get; set; }

    public string? Model { get; set; }

    public string? Vin { get; set; }

    public short? Godina { get; set; }

    public short? SnagaMotora { get; set; }

    public int? TipVozilaId { get; set; }

    public int? GorivoId { get; set; }

    public int? MjenjacId { get; set; }

    public int? OblikId { get; set; }

    public string? Opis { get; set; }

    public virtual Gorivo? Gorivo { get; set; }

    public virtual Mjenjac? Mjenjac { get; set; }

    public virtual Oblik? Oblik { get; set; }

    public virtual Salon? Salon { get; set; }

    public virtual TipVozila? TipVozila { get; set; }
}
