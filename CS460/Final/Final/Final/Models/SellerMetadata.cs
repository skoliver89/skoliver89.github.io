using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class SellerMetadata
    {
        [Display(Name = "Seller Name")]
        public string Name { get; set; }
    }

    [MetadataType(typeof(SellerMetadata))]
    public partial class Seller
    { }

}