namespace TravelBookAspNetMVCAzure.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TravelBookModel : DbContext
    {
        public TravelBookModel()
            : base("name=TravelBookModel")
        {
        }

        public virtual DbSet<AgencijaAzure> AgencijaAzures { get; set; }
        public virtual DbSet<DestinacijaAzure> DestinacijaAzures { get; set; }
        public virtual DbSet<HotelAzure> HotelAzures { get; set; }
        public virtual DbSet<KarticaAzure> KarticaAzures { get; set; }
        public virtual DbSet<KorisnikAzure> KorisnikAzures { get; set; }
        public virtual DbSet<PrevozAzure> PrevozAzures { get; set; }
        public virtual DbSet<PutovanjeAzure> PutovanjeAzures { get; set; }
        public virtual DbSet<RezervisanaPutovanjaAzure> RezervisanaPutovanjaAzures { get; set; }

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

         /*   modelBuilder.Entity<KarticaAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<KarticaAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<KarticaAzure>()
                .Property(e => e.version)
                .IsFixedLength();*/

         /*   modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.createdAt)
                .HasPrecision(3);

            modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.updatedAt)
                .HasPrecision(3);

            modelBuilder.Entity<KorisnikAzure>()
                .Property(e => e.version)
                .IsFixedLength();*/

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
