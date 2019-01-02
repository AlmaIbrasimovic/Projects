namespace TravelBookRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelAzure")]
    public partial class HotelAzure
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

        public string slika { get; set; }

        public double? maxKapacitet { get; set; }

        public double? kapacitet { get; set; }

        public string idDestinacije { get; set; }

        public double? cijena { get; set; }
    }
}
