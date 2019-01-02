namespace TravelBookRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KorisnikAzure")]
    public partial class KorisnikAzure
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

        public string ime { get; set; }

        public string prezime { get; set; }

        public string jmbg { get; set; }

        public DateTimeOffset? datumRodjenja { get; set; }

        public string telefon { get; set; }

        public string email { get; set; }

        public string sifra { get; set; }

        public string idKartice { get; set; }
    }
}
