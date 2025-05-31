using System;
using System.Collections.Generic;

namespace OgrenciKayitSistemi.Domain.Entities;

public partial class SinifTablo : BaseEntity
{
    public long Id { get; set; }

    public string? Ad { get; set; }

    public DateTime Taktif { get; set; }

    public DateTime? Tpasif { get; set; }

    public virtual ICollection<OgrenciTablo> OgrenciTablos { get; set; } = new List<OgrenciTablo>();
}
