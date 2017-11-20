namespace GiphySearch.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestLog
    {
        [Key]
        public int RequestID { get; set; }

        public DateTime RequestTime { get; set; }

        [StringLength(50)]
        public string RequestClientIP { get; set; }

        [StringLength(128)]
        public string RequestClientAgent { get; set; }

        [StringLength(128)]
        public string RequestQuery { get; set; }

        [StringLength(10)]
        public string RequestLang { get; set; }

        [StringLength(10)]
        public string RequestRating { get; set; }
    }
}
