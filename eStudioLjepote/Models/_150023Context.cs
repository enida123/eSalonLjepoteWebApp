using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eStudioLjepote.Models
{
    public partial class _150023Context : DbContext
    {
        public _150023Context()
        {
        }

        public _150023Context(DbContextOptions<_150023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Edukacija> Edukacija { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Klijent> Klijent { get; set; }
        public virtual DbSet<Plata> Plata { get; set; }
        public virtual DbSet<Proizvods> Proizvods { get; set; }
        public virtual DbSet<ProizvodUsluga> ProizvodUsluga { get; set; }
        public virtual DbSet<PruzeneUsluge> PruzeneUsluge { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<RezervacijaEdukacije> RezervacijaEdukacije { get; set; }
        public virtual DbSet<TipUplate> TipUplate { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<Uplate> Uplate { get; set; }
        public virtual DbSet<Usluge> Usluge { get; set; }
        public virtual DbSet<VrstaProizvoda> VrstaProizvoda { get; set; }
        public virtual DbSet<VrstaUsluge> VrstaUsluge { get; set; }
        public virtual DbSet<ZaposleniciUloge> ZaposleniciUloge { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=150023;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv).IsRequired();
            });

            modelBuilder.Entity<Edukacija>(entity =>
            {
                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Edukacija)
                    .HasForeignKey(d => d.ZaposlenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Edukacija__Zapos__2739D489");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasIndex(e => e.DrzavaId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DrzavaId).HasColumnName("DrzavaID");

                entity.Property(e => e.Naziv).IsRequired();

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grad)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Klijent)
                    .HasForeignKey(d => d.GradId);
            });

            modelBuilder.Entity<Plata>(entity =>
            {
                entity.HasIndex(e => e.ZaposlenikId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.Godina).HasColumnName("godina");

                entity.Property(e => e.Mjesec).HasColumnName("mjesec");

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Plata)
                    .HasForeignKey(d => d.ZaposlenikId);
            });

            modelBuilder.Entity<Proizvods>(entity =>
            {
                entity.HasKey(e => e.ProizvodId);

                entity.HasIndex(e => e.VrstaProizvodaId);

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.Property(e => e.KolicinaUskladiste).HasColumnName("KolicinaUSkladiste");

                entity.Property(e => e.VrstaProizvodaId).HasColumnName("VrstaProizvodaID");

                entity.HasOne(d => d.VrstaProizvoda)
                    .WithMany(p => p.Proizvods)
                    .HasForeignKey(d => d.VrstaProizvodaId);
            });

            modelBuilder.Entity<ProizvodUsluga>(entity =>
            {
                entity.HasIndex(e => e.ProizvodId);

                entity.HasIndex(e => e.UslugeId);

                entity.Property(e => e.ProizvodUslugaId).HasColumnName("ProizvodUslugaID");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.ProizvodUsluga)
                    .HasForeignKey(d => d.ProizvodId);

                entity.HasOne(d => d.Usluge)
                    .WithMany(p => p.ProizvodUsluga)
                    .HasForeignKey(d => d.UslugeId);
            });

            modelBuilder.Entity<PruzeneUsluge>(entity =>
            {
                entity.HasIndex(e => e.RezervacijaId);

                entity.HasIndex(e => e.UslugaId);

                entity.HasIndex(e => e.ZaposlenikId);

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.UslugaId).HasColumnName("UslugaID");

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.PruzeneUsluge)
                    .HasForeignKey(d => d.RezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usluga)
                    .WithMany(p => p.PruzeneUsluge)
                    .HasForeignKey(d => d.UslugaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.PruzeneUsluge)
                    .HasForeignKey(d => d.ZaposlenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.HasIndex(e => e.KlijentId);

                entity.HasIndex(e => e.UslugeId);

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.UslugeId).HasColumnName("UslugeID");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.KlijentId);

                entity.HasOne(d => d.Usluge)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UslugeId);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasIndex(e => e.KlijentId);

                entity.HasIndex(e => e.UslugeId);

                entity.Property(e => e.KlijentId).HasColumnName("KlijentID");

                entity.Property(e => e.UslugeId).HasColumnName("UslugeID");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Usluge)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.UslugeId);
            });

            modelBuilder.Entity<RezervacijaEdukacije>(entity =>
            {
                entity.HasIndex(e => e.EdukacijaId);

                entity.HasIndex(e => e.KlijentId);

                entity.Property(e => e.EdukacijaId).HasColumnName("edukacijaID");

                entity.Property(e => e.KlijentId).HasColumnName("klijentID");

                entity.HasOne(d => d.Edukacija)
                    .WithMany(p => p.RezervacijaEdukacije)
                    .HasForeignKey(d => d.EdukacijaId);

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.RezervacijaEdukacije)
                    .HasForeignKey(d => d.KlijentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TipUplate>(entity =>
            {
                entity.Property(e => e.Naziv).HasColumnName("naziv");
            });

            modelBuilder.Entity<Uplate>(entity =>
            {
                entity.HasIndex(e => e.RezervacijaId);

                entity.HasIndex(e => e.TipUplateId);

                entity.HasIndex(e => e.ZaposlenikId);

                entity.Property(e => e.DatumUplate).HasColumnName("datumUplate");

                entity.Property(e => e.Popust).HasColumnName("popust");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.TipUplateId).HasColumnName("TipUplateID");

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.Uplate)
                    .HasForeignKey(d => d.RezervacijaId);

                entity.HasOne(d => d.TipUplate)
                    .WithMany(p => p.Uplate)
                    .HasForeignKey(d => d.TipUplateId);

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.Uplate)
                    .HasForeignKey(d => d.ZaposlenikId);
            });

            modelBuilder.Entity<Usluge>(entity =>
            {
                entity.HasOne(d => d.VrstaUsluge)
                    .WithMany(p => p.Usluge)
                    .HasForeignKey(d => d.VrstaUslugeId)
                    .HasConstraintName("FK__Usluge__VrstaUsl__160F4887");
            });

            modelBuilder.Entity<VrstaUsluge>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ZaposleniciUloge>(entity =>
            {
                entity.HasIndex(e => e.UlogaId);

                entity.HasIndex(e => e.ZaposlenikId);

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.ZaposlenikId).HasColumnName("ZaposlenikID");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.ZaposleniciUloge)
                    .HasForeignKey(d => d.UlogaId);

                entity.HasOne(d => d.Zaposlenik)
                    .WithMany(p => p.ZaposleniciUloge)
                    .HasForeignKey(d => d.ZaposlenikId);
            });

            modelBuilder.Entity<Zaposlenik>(entity =>
            {
                entity.HasIndex(e => e.GradId);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GradId).HasColumnName("GradID");

                entity.Property(e => e.Jmbg).HasColumnName("JMBG");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Zaposlenik)
                    .HasForeignKey(d => d.GradId);
            });
        }
    }
}
