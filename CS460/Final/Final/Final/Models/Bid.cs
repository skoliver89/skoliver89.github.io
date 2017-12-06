namespace Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        public int ID { get; set; }

        public int Item { get; set; }

        public int Buyer { get; set; }

        public decimal Price { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual Item Item1 { get; set; }

        public virtual Buyer Buyer1 { get; set; }
    }
}
