namespace TravelBookAspNetMVCAzure.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KarticaAzure")]
    public partial class KarticaAzure
    {
        [StringLength(255)]
        public string id { get; set; }
/*
        public DateTimeOffset createdAt { get; set; }

        public DateTimeOffset? updatedAt { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] version { get; set; }

        public bool? deleted { get; set; }*/

        public string vrstaKartice { get; set; }

        public string datumIsteka { get; set; }

        public string broj { get; set; }

        public double? csc { get; set; }
    }
}
