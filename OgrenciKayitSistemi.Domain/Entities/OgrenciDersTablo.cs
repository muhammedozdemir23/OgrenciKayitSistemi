using OgrenciKayitSistemi.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OgrenciKayitSistemi.Domain.Entities;

public partial class OgrenciDersTablo : BaseEntity
{
    public long Id { get; set; }

    public long? OgrenciId { get; set; }

    public long? DersId { get; set; }

    public virtual DersTablo? Ders { get; set; }

    public virtual OgrenciTablo? Ogrenci { get; set; }
}
