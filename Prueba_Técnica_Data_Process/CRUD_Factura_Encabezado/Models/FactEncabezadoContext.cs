using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_Factura_Encabezado.Models
{
    public partial class FactEncabezadoContext : DbContext
    {
        public FactEncabezadoContext()
        {
        }

        public FactEncabezadoContext(DbContextOptions<FactEncabezadoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EfectoComprobante> EfectoComprobante { get; set; } = null!;
        public virtual DbSet<Encabezado> Encabezado { get; set; } = null!;
        public virtual DbSet<FormaPago> FormaPago { get; set; } = null!;
        public virtual DbSet<MetodoPago> MetodoPago { get; set; } = null!;
        public virtual DbSet<Moneda> Moneda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfectoComprobante>(entity =>
            {
                entity.HasKey(e => e.IdEfectoComprobante)
                    .HasName("PK__EfectoCo__29009D7D68488D96");

                entity.Property(e => e.IdEfectoComprobante).HasColumnName("idEfectoComprobante");

                entity.Property(e => e.NombreEfectoComprobante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreEfectoComprobante");
            });

            modelBuilder.Entity<Encabezado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Factura)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("factura");

                entity.Property(e => e.FechaCertificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCertificacion");

                entity.Property(e => e.FechaEmision)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEmision");

                entity.Property(e => e.FolioFiscal)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("folioFiscal");

                entity.Property(e => e.IdEfectoComprobante).HasColumnName("idEfectoComprobante");

                entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");

                entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");

                entity.Property(e => e.IdMoneda).HasColumnName("idMoneda");

                entity.Property(e => e.LugarExpedicion)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("lugarExpedicion");

                entity.HasOne(d => d.IdEfectoComprobanteNavigation)
                    .WithMany(p => p.Encabezado)
                    .HasForeignKey(d => d.IdEfectoComprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encabezado_efectoComprobante");

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.Encabezado)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encabezado_formaPago");

                entity.HasOne(d => d.IdMetodoPagoNavigation)
                    .WithMany(p => p.Encabezado)
                    .HasForeignKey(d => d.IdMetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encabezado_metodoPago");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Encabezado)
                    .HasForeignKey(d => d.IdMoneda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Encabezado_moneda");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago)
                    .HasName("PK__FormaPag__952893F6F1FAA427");

                entity.Property(e => e.IdFormaPago).HasColumnName("idFormaPago");

                entity.Property(e => e.NombreFormaPago)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreFormaPago");
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.IdMetodoPago)
                    .HasName("PK__MetodoPa__817BFC32EDD7FADA");

                entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");

                entity.Property(e => e.NombreMetodoPago)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreMetodoPago");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.IdMoneda)
                    .HasName("PK__Moneda__E14012F4F5EF0142");

                entity.Property(e => e.IdMoneda).HasColumnName("idMoneda");

                entity.Property(e => e.NombreMoneda)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreMoneda");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
