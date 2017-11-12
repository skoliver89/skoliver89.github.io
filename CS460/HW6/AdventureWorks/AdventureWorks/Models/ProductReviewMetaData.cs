using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdventureWorks.Models
{
    public partial class ProductReviewMetaData
    {
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }


    [MetadataType(typeof(ProductReviewMetaData))]
    public partial class ProductReview { }
}