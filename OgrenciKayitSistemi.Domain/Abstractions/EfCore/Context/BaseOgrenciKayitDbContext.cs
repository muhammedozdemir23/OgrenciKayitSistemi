using Microsoft.EntityFrameworkCore;
using OgrenciKayitSistemi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciKayitSistemi.Domain.Abstractions.EfCore.Context
{
    public abstract class BaseOgrenciKayitDbContext : DbContext
    {
        protected BaseOgrenciKayitDbContext(DbContextOptions<BaseOgrenciKayitDbContext> options) : base(options) { }

        public DbSet<DersTablo> DersTablos { get; set; }

        public DbSet<OgrenciDersTablo> OgrenciDersTablos { get; set; }

        public DbSet<OgrenciTablo> OgrenciTablos { get; set; }

        public DbSet<SinifTablo> SinifTablos { get; set; }
    }
}
