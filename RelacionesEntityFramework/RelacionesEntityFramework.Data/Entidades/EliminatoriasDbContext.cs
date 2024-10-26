using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RelacionesEntityFramework.Data.Entidades;

public partial class EliminatoriasDbContext : DbContext
{
    public EliminatoriasDbContext()
    {
    }

    public EliminatoriasDbContext(DbContextOptions<EliminatoriasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jugador> Jugadors { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<Seleccion> Seleccions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B5HECAG\\SQLEXPRESS;Database=EliminatoriasDB;User=sa;Password=pachan242;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jugador>(entity =>
        {
            entity.HasKey(e => e.IdJugador);

            entity.ToTable("Jugador");

            entity.Property(e => e.IdJugador).HasColumnName("idJugador");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.IdSeleccion).HasColumnName("idSeleccion");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdSeleccionNavigation).WithMany(p => p.Jugadors)
                .HasForeignKey(d => d.IdSeleccion)
                .HasConstraintName("FK_Jugador_Seleccion");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partido__3213E83FAE5AADE4");

            entity.ToTable("Partido");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Estadio)
                .HasMaxLength(255)
                .HasColumnName("estadio");
            entity.Property(e => e.GolesLocal).HasColumnName("goles_local");
            entity.Property(e => e.GolesVisitante).HasColumnName("goles_visitante");
            entity.Property(e => e.LocalId).HasColumnName("local_id");
            entity.Property(e => e.VisitanteId).HasColumnName("visitante_id");

            entity.HasOne(d => d.Local).WithMany(p => p.PartidoLocals)
                .HasForeignKey(d => d.LocalId)
                .HasConstraintName("FK__Partido__local_i__3A81B327");

            entity.HasOne(d => d.Visitante).WithMany(p => p.PartidoVisitantes)
                .HasForeignKey(d => d.VisitanteId)
                .HasConstraintName("FK__Partido__visitan__398D8EEE");
        });

        modelBuilder.Entity<Seleccion>(entity =>
        {
            entity.HasKey(e => e.IdSeleccion);

            entity.ToTable("Seleccion");

            entity.Property(e => e.IdSeleccion).HasColumnName("idSeleccion");
            entity.Property(e => e.Escudo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
