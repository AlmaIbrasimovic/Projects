namespace TravelBookRestAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TravelBookAdoNetModel : DbContext
    {
        public TravelBookAdoNetModel()
            : base("name=TravelBookAdoNetModel")
        {
        }

        public virtual DbSet<AgencijaAzure> AgencijaAzure { get; set; }
        public virtual DbSet<DestinacijaAzure> DestinacijaAzure { get; set; }
        public virtual DbSet<HotelAzure> HotelAzure { get; set; }
        public virtual DbSet<KarticaAzure> KarticaAzure { get; set; }
        public virtual DbSet<KorisnikAzure> KorisnikAzure { get; set; }
        public virtual DbSet<PrevozAzure> PrevozAzure { get; set; }
        public virtual DbSet<PutovanjeAzure> PutovanjeAzure { get; set; }
        public virtual DbSet<RezervisanaPutovanjaAzure> RezervisanaPutovanjaAzure { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgencijaAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<AgencijaAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<AgencijaAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<DestinacijaAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<DestinacijaAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<DestinacijaAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<HotelAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<HotelAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<HotelAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<KarticaAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<KarticaAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<KarticaAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.datumRodjenja)
                .HasPrecision(3);

            modelBuilder.Entity<PrevozAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<PrevozAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<PrevozAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<PutovanjeAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<PutovanjeAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<PutovanjeAzure>()
                .Property(e => e.version)
                .IsFixedLength();

            modelBuilder.Entity<PutovanjeAzure>()
                .Property(e => e.datumPolaska)
                .HasPrecision(3);

            modelBuilder.Entity<PutovanjeAzure>()
                .Property(e => e.datumPovratka)
                .HasPrecision(3);

            modelBuilder.Entity<RezervisanaPutovanjaAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<RezervisanaPutovanjaAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<RezervisanaPutovanjaAzure>()
                .Property(e => e.version)
                .IsFixedLength();
        }
    }
}
