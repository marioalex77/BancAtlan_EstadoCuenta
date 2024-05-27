using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_BancAtlan_EstadoCuenta.Entities;

public partial class BancAtlanEstadoCuentaContext : DbContext
{
    public BancAtlanEstadoCuentaContext()
    {
    }

    public BancAtlanEstadoCuentaContext(DbContextOptions<BancAtlanEstadoCuentaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoCuentum> EstadoCuenta { get; set; }

    public virtual DbSet<Tarjetum> Tarjeta { get; set; }

    public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; }

    public virtual DbSet<Transaccion> Transaccions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Name=ConnectionStrings:BancAtlan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Genero).IsFixedLength();
        });

        modelBuilder.Entity<EstadoCuentum>(entity =>
        {
            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.EstadoCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estado_cuenta_tarjeta");
        });

        modelBuilder.Entity<Tarjetum>(entity =>
        {
            entity.Property(e => e.IdTarjeta).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdTarjetaNavigation).WithOne(p => p.Tarjetum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tarjeta_cliente");
        });

        modelBuilder.Entity<TipoTransaccion>(entity =>
        {
            entity.Property(e => e.Valor).IsFixedLength();
        });

        modelBuilder.Entity<Transaccion>(entity =>
        {
            entity.Property(e => e.Signo)
                .HasDefaultValue("D")
                .IsFixedLength();

            entity.HasOne(d => d.IdTarjetaNavigation).WithMany(p => p.Transaccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_transaccion_tarjeta");

            entity.HasOne(d => d.IdTipoTransaccionNavigation).WithMany(p => p.Transaccions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_transaccion_tipo_transaccion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
