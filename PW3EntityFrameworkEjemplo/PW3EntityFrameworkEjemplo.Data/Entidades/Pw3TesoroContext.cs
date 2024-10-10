using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PW3EntityFrameworkEjemplo.Data.Entidades;

public partial class Pw3TesoroContext : DbContext
{
    public Pw3TesoroContext()
    {
    }

    public Pw3TesoroContext(DbContextOptions<Pw3TesoroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tesoro> Tesoros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-B5HECAG\\SQLEXPRESS;Database=pw3_tesoro;User=sa;Password=pachan242;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tesoro>(entity =>
        {
            entity.ToTable("Tesoro");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ImagenRuta).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
