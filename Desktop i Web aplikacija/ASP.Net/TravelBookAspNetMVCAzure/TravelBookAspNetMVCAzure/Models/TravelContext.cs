using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TravelBookAspNetMVCAzure.Models
{
    public class TravelContext : DbContext
    {
        public TravelContext() : base("Data Source=tcp:travelbookserver.database.windows.net,1433;Initial Catalog=TravelBookDB;User ID=mujo;Password=Fata123.") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }
        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.KorisnikAzure> KorisnikAzures { get; set; }
        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.HotelAzure> HotelAzures { get; set; }

        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.AgencijaAzure> AgencijaAzures { get; set; }

        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.DestinacijaAzure> DestinacijaAzures { get; set; }

        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.PrevozAzure> PrevozAzures { get; set; }

        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.PutovanjeAzure> PutovanjeAzures { get; set; }

        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.RezervisanaPutovanjaAzure> RezervisanaPutovanjaAzures { get; set; }

        public System.Data.Entity.DbSet<TravelBookAspNetMVCAzure.Models.KarticaAzure> KarticaAzures { get; set; }
    }
}