namespace TravelBookRestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PutovanjeAzure")]
    public partial class PutovanjeAzure
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

        public DateTimeOffset? datumPolaska { get; set; }

        public DateTimeOffset? datumPovratka { get; set; }

        public double? minBrojPutnika { get; set; }

        public double? maxBrojPutnika { get; set; }

        public string opisPutovanja { get; set; }

        public bool? istaknuto { get; set; }

        public string idAgencije { get; set; }

        public string idDestinacije { get; set; }

        public string idHotela { get; set; }

        public string idPrevoz { get; set; }

        public double? cijena { get; set; }
    }
}
