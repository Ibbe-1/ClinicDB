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

    public virtual DbSet<Bokningar> Bokningars { get; set; }
    public virtual DbSet<Patienter> Patienters { get; set; }
    public virtual DbSet<Personal> Personals { get; set; }
    public virtual DbSet<Betalning> Betalnings { get; set; }   


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=YONIS\\SQLEXPRESS03;Database=ClinicDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Betalning>(entity =>
        {
            entity.HasKey(e => e.BetalningId);   // Primärnyckel

            entity.ToTable("Betalning");

            entity.Property(e => e.BetalningId).HasColumnName("BetalningID");
            entity.Property(e => e.PatientId).IsRequired();
            entity.Property(e => e.Belopp).HasColumnType("decimal(10,2)");
            entity.Property(e => e.Betalningsdatum)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Betalningssatt)
                  .HasMaxLength(50)
                  .IsUnicode(false);
            entity.Property(e => e.Betalningsstatus)
                  .HasMaxLength(30)
                  .IsUnicode(false)
                  .HasDefaultValue("Obetald");

            // Koppla till Patienter
            entity.HasOne(d => d.Patient)
                  .WithMany(p => p.Betalnings)
                  .HasForeignKey(d => d.PatientId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Betalning_Patienter");
        });

        modelBuilder.Entity<Bokningar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bokninga__3214EC0796B8826E");

            entity.ToTable("Bokningar");

            entity.Property(e => e.Skapad)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartTid).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Bokad");

            entity.HasOne(d => d.Patient).WithMany(p => p.Bokningars)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bokningar_Patienter");

            entity.HasOne(d => d.Personal).WithMany(p => p.Bokningars)
                .HasForeignKey(d => d.PersonalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bokningar_Personal");
        });

        modelBuilder.Entity<Patienter>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patiente__970EC346BD8F04CB");

            entity.ToTable("Patienter");

            entity.HasIndex(e => e.WaitingNumber, "UQ__Patiente__D021E8C6CB769ADD").IsUnique();

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.PersonalId).HasName("PK__Personal__C16BAC15B4B08766");

            entity.ToTable("Personal");

            entity.Property(e => e.PersonalId).HasColumnName("personal_id");
            entity.Property(e => e.Namn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("namn");
            entity.Property(e => e.Telefonnummer)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefonnummer");
            entity.Property(e => e.Yrke)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("yrke");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
