using System;
using Microsoft.EntityFrameworkCore;

namespace ClinicDB.Models
{
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
        public virtual DbSet<KonummerSekven> KonummerSekvens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string till lokal SQL Server
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost\\SQLEXPRESS;Database=ClinicDB;Trusted_Connection=True;TrustServerCertificate=True;"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----------------- KonummerSekven -----------------
            modelBuilder.Entity<KonummerSekven>(entity =>
            {
                entity.HasKey(e => new { e.MottagningId, e.Datum });
                entity.ToTable("KonummerSekven");
                entity.Property(e => e.SistaKonummer).IsRequired();
            });

            // ----------------- Betalning -----------------
            modelBuilder.Entity<Betalning>(entity =>
            {
                entity.HasKey(e => e.BetalningId);
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

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Betalnings)
                      .HasForeignKey(d => d.PatientId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Betalning_Patienter");
            });

            // ----------------- Bokningar -----------------
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
                      .HasDefaultValue("Bokad");

                entity.HasOne(d => d.Patient)
                      .WithMany(p => p.Bokningars)
                      .HasForeignKey(d => d.PatientId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Bokningar_Patienter");

                entity.HasOne(d => d.Personal)
                      .WithMany(p => p.Bokningars)
                      .HasForeignKey(d => d.PersonalId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Bokningar_Personal");
            });

            // ----------------- Patienter -----------------
            modelBuilder.Entity<Patienter>(entity =>
            {
                entity.HasKey(e => e.PatientId);
                entity.ToTable("Patienter");

                entity.HasIndex(e => e.WaitingNumber).IsUnique();

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

            // ----------------- Personal -----------------
            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.PersonalId);
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
}
