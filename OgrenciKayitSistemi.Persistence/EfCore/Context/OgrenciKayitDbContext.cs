using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OgrenciKayitSistemi.Domain.Entities;

namespace OgrenciKayitSistemi.Persistence.EfCore.Context;

public partial class OgrenciKayitDbContext : DbContext
{
    public OgrenciKayitDbContext()
    {
    }

    public OgrenciKayitDbContext(DbContextOptions<OgrenciKayitDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DersTablo> DersTablos { get; set; }

    public virtual DbSet<OgrenciDersTablo> OgrenciDersTablos { get; set; }

    public virtual DbSet<OgrenciTablo> OgrenciTablos { get; set; }

    public virtual DbSet<SinifTablo> SinifTablos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TOIMBIO\\SQLEXPRESS01;Database=OgrenciKayitSistemi;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DersTablo>(entity =>
        {
            entity.ToTable("DersTablo");

            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Taktif)
                .HasColumnType("datetime")
                .HasColumnName("TAktif");
            entity.Property(e => e.Tpasif)
                .HasColumnType("datetime")
                .HasColumnName("TPasif");
        });

        modelBuilder.Entity<OgrenciDersTablo>(entity =>
        {
            entity.ToTable("OgrenciDersTablo");

            entity.HasOne(d => d.Ders).WithMany(p => p.OgrenciDersTablos)
                .HasForeignKey(d => d.DersId)
                .HasConstraintName("FK_OgrenciDersTablo_DersTablo");

            entity.HasOne(d => d.Ogrenci).WithMany(p => p.OgrenciDersTablos)
                .HasForeignKey(d => d.OgrenciId)
                .HasConstraintName("FK_OgrenciDersTablo_OgrenciTablo");
        });

        modelBuilder.Entity<OgrenciTablo>(entity =>
        {
            entity.ToTable("OgrenciTablo");

            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Soyad).HasMaxLength(100);
            entity.Property(e => e.Taktif)
                .HasColumnType("datetime")
                .HasColumnName("TAktif");
            entity.Property(e => e.Tpasif)
                .HasColumnType("datetime")
                .HasColumnName("TPasif");

            entity.HasOne(d => d.Sinif).WithMany(p => p.OgrenciTablos)
                .HasForeignKey(d => d.SinifId)
                .HasConstraintName("FK_OgrenciTablo_SinifTablo");
        });

        modelBuilder.Entity<SinifTablo>(entity =>
        {
            entity.ToTable("SinifTablo");

            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Taktif)
                .HasColumnType("datetime")
                .HasColumnName("TAktif");
            entity.Property(e => e.Tpasif)
                .HasColumnType("datetime")
                .HasColumnName("TPasif");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
