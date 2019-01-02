namespace TravelBookAspNetMVCAzure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KorisnikAzure")]
    public partial class KorisnikAzure
    {
          [StringLength(255)]
         // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public string id { get; set; }//set;
                                   /* 
                                      public DateTimeOffset createdAt { get; set; }

                                      public DateTimeOffset? updatedAt { get; set; }

                                      [Column(TypeName = "timestamp")]
                                      [MaxLength(8)]
                                      [Timestamp]
                                      public byte[] version { get; set; }

                                      public bool? deleted { get; set; }*/

        [Key]
        [DisplayName ("Ime")]
        public string ime { get; set; }

        [DisplayName("Prezime")]
        public string prezime { get; set; }

        [DisplayName("JMBG")]
        public string jmbg { get; set; }

        [DisplayName("Datum rodjenja")]
        public DateTimeOffset? datumRodjenja { get; set; }

        [DisplayName("Telefon")]
        public string telefon { get; set; }

        [DisplayName("Email")]
        public string email { get; set; }

        [DisplayName("Password")]
        public string sifra { get; set; }

        [DisplayName("Kartica")]
        public string idKartice { get; set; }
    }
}
