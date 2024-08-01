using Autokuca.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Autokuca.DAL;
    public partial class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public virtual DbSet<Gorivo> Gorivos { get; set; }

        public virtual DbSet<Mjenjac> Mjenjacs { get; set; }

        public virtual DbSet<Oblik> Obliks { get; set; }

        public virtual DbSet<Salon> Salons { get; set; }

        public virtual DbSet<TipVozila> TipVozilas { get; set; }

        public virtual DbSet<Vozilo> Vozilos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Gorivo>(entity =>
        {
            entity.HasKey(e => e.GorivoId).HasName("PK__Gorivo__86902C48447831F6");

            entity.ToTable("Gorivo");

            entity.Property(e => e.GorivoId).HasColumnName("GorivoID");
            entity.Property(e => e.TipGoriva).HasMaxLength(50);
        });

        modelBuilder.Entity<Mjenjac>(entity =>
        {
            entity.HasKey(e => e.MjenjacId).HasName("PK__Mjenjac__862D65814D10996D");

            entity.ToTable("Mjenjac");

            entity.Property(e => e.MjenjacId).HasColumnName("MjenjacID");
            entity.Property(e => e.TipMjenjaca).HasMaxLength(50);
        });

        modelBuilder.Entity<Oblik>(entity =>
        {
            entity.HasKey(e => e.OblikId).HasName("PK__Oblik__78F2A562C3B909E8");

            entity.ToTable("Oblik");

            entity.Property(e => e.OblikId).HasColumnName("OblikID");
            entity.Property(e => e.TipOblika).HasMaxLength(50);
        });

        modelBuilder.Entity<Salon>(entity =>
        {
            entity.HasKey(e => e.SalonId).HasName("PK__Salon__5E2558411AF20045");

            entity.ToTable("Salon");

            entity.Property(e => e.SalonId).HasColumnName("SalonID");
            entity.Property(e => e.AdminId).HasMaxLength(450);
            entity.Property(e => e.Adresa).HasMaxLength(50);
            entity.Property(e => e.Kontakt).HasMaxLength(150);
            entity.Property(e => e.Naziv).HasMaxLength(50);
            entity.Property(e => e.RadnoVrijeme).HasMaxLength(150);
        });

        modelBuilder.Entity<TipVozila>(entity =>
        {
            entity.HasKey(e => e.TipVozilaId).HasName("PK__TipVozil__C7F206B41D5266CA");

            entity.ToTable("TipVozila");

            entity.Property(e => e.TipVozilaId).HasColumnName("TipVozilaID");
            entity.Property(e => e.TipVozila1)
                .HasMaxLength(50)
                .HasColumnName("TipVozila");
        });

        modelBuilder.Entity<Vozilo>(entity =>
        {
            entity.HasKey(e => e.VoziloId).HasName("PK__Vozila__19A5242FD3074363");

            entity.ToTable("Vozila");

            entity.Property(e => e.VoziloId).HasColumnName("VoziloID");
            entity.Property(e => e.GorivoId).HasColumnName("GorivoID");
            entity.Property(e => e.MjenjacId).HasColumnName("MjenjacID");
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.OblikId).HasColumnName("OblikID");
            entity.Property(e => e.Proizvodac).HasMaxLength(50);
            entity.Property(e => e.SalonId).HasColumnName("SalonID");
            entity.Property(e => e.TipVozilaId).HasColumnName("TipVozilaID");
            entity.Property(e => e.Vin)
                .HasMaxLength(17)
                .HasColumnName("VIN");

            entity.HasOne(d => d.Gorivo).WithMany(p => p.Vozilas)
                .HasForeignKey(d => d.GorivoId)
                .HasConstraintName("FK__Vozila__GorivoID__5535A963");

            entity.HasOne(d => d.Mjenjac).WithMany(p => p.Vozilas)
                .HasForeignKey(d => d.MjenjacId)
                .HasConstraintName("FK__Vozila__MjenjacI__5629CD9C");

            entity.HasOne(d => d.Oblik).WithMany(p => p.Vozilas)
                .HasForeignKey(d => d.OblikId)
                .HasConstraintName("FK__Vozila__OblikID__571DF1D5");

            entity.HasOne(d => d.Salon).WithMany(p => p.Vozilas)
                .HasForeignKey(d => d.SalonId)
                .HasConstraintName("FK__Vozila__SalonID__534D60F1");

            entity.HasOne(d => d.TipVozila).WithMany(p => p.Vozilas)
                .HasForeignKey(d => d.TipVozilaId)
                .HasConstraintName("FK__Vozila__TipVozil__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
