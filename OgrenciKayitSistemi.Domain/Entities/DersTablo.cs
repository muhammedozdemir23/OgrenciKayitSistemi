using System;
using System.Collections.Generic;

namespace OgrenciKayitSistemi.Domain.Entities;

public partial class DersTablo : BaseEntity
{
    public long Id { get; set; }

    public string? Ad { get; set; }

    public DateTime Taktif { get; set; }

    public DateTime? Tpasif { get; set; }

    public virtual ICollection<OgrenciDersTablo> OgrenciDersTablos { get; set; } = new List<OgrenciDersTablo>();
}
