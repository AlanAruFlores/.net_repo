using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ModeloParcial2PW3.Entidades.Entidades;

public partial class Formula1Context : DbContext
{
    public Formula1Context()
    {
    }

    public Formula1Context(DbContextOptions<Formula1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Escuderium> Escuderia { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B5HECAG\\SQLEXPRESS;Database=Formula1;User=sa;Password=pachan242;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Escuderium>(entity =>
        {
            entity.HasKey(e => e.IdEscuderia);

            entity.Property(e => e.IdEscuderia).HasColumnName("idEscuderia");
            entity.Property(e => e.NombreEscuderia).HasMaxLength(50);
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto);

            entity.ToTable("Piloto");

            entity.Property(e => e.IdPiloto).HasColumnName("idPiloto");
            entity.Property(e => e.IdEscuderia).HasColumnName("idEscuderia");
            entity.Property(e => e.NombrePiloto).HasMaxLength(50);

            entity.HasOne(d => d.IdEscuderiaNavigation).WithMany(p => p.Pilotos)
                .HasForeignKey(d => d.IdEscuderia)
                .HasConstraintName("FK_Piloto_Escuderia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
