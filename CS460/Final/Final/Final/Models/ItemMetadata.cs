using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
        public class ItemMetadata
    {
        [Display(Name = "Item Name")]
        public string Name { get; set; }
    }

    [MetadataType(typeof(ItemMetadata))]
    public partial class Item
    { }
}