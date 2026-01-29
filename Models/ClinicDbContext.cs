using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClinicDB.Models;

public partial class ClinicDbContext : DbContext
{
    public ClinicDbContext()
    {
    }

    public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Betalning> Betalnings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=YONIS\\SQLEXPRESS03;Database=ClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betalning>(entity =>
        {
            entity.HasKey(e => e.BetalningId).HasName("PK__Betalnin__765FF4493DCD2210");

            entity.ToTable("Betalning");

            entity.Property(e => e.BetalningId).HasColumnName("BetalningID");
            entity.Property(e => e.Belopp).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Betalningsdatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Betalningssatt).HasMaxLength(50);
            entity.Property(e => e.Betalningsstatus)
                .HasMaxLength(30)
                .HasDefaultValue("Obetald");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
