namespace TravelBookAspNetMVCAzure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgencijaAzure")]
    public partial class AgencijaAzure
    {
        [StringLength(255)]
        public string id { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset? updatedAt { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public bool? deleted { get; set; }

        public string naziv { get; set; }

        public string idKartica { get; set; }

        public string telefon { get; set; }

        public string grad { get; set; }

        public string lokacija { get; set; }

        public string sifra { get; set; }

        public string email { get; set; }
    }
}
