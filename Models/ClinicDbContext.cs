using System;
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
    public virtual DbSet<Bokningar> Bokningars { get; set; }
    public virtual DbSet<KonummerSekven> KonummerSekvens { get; set; }
    public virtual DbSet<Patienter> Patienters { get; set; }
    public virtual DbSet<Personal> Personals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
        => optionsBuilder.UseSqlServer("Server=YONIS\\SQLEXPRESS03;Database=ClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ================= BETALNING =================
        modelBuilder.Entity<Betalning>(entity =>
        {
            entity.HasKey(e => e.BetalningId);

            entity.ToTable("Betalning");

            entity.Property(e => e.Belopp).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Betalningsdatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Betalningssatt)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Betalningsstatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Obetald");

            entity.HasOne(d => d.Patient)
                  .WithMany(p => p.Betalnings)
                  .HasForeignKey(d => d.PatientId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        // ================= BOKNINGAR =================
        modelBuilder.Entity<Bokningar>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Bokningar");

            entity.Property(e => e.Skapad)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartTid).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Patient)
                  .WithMany(p => p.Bokningars)
                  .HasForeignKey(d => d.PatientId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Personal)
                  .WithMany(p => p.Bokningars)
                  .HasForeignKey(d => d.PersonalId)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        });

        // ================= KONUMMERSEKVENS =================
        modelBuilder.Entity<KonummerSekven>(entity =>
        {
            entity.HasKey(e => new { e.MottagningId, e.Datum });

            entity.ToTable("KonummerSekven");
        });

        // ================= PATIENTER =================
        modelBuilder.Entity<Patienter>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("Patienter");

            entity.Property(e => e.Förnamn)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Efternamn)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Telefonnummer)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Skapad)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        // ================= PERSONAL =================
        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PersonalId);

            entity.ToTable("Personal");

            entity.Property(e => e.Namn)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Yrke)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Telefonnummer)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
