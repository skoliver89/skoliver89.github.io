using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtVault.Models
{
    public partial class ArtistMetadata
    {
        [DataType(DataType.Date)]
        [NoFutureDates(ErrorMessage = (nameof(BirthDate) + " must be no greater" +
            " than today and no less than 110 years before today"))]
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Name { get; set; }

        [RegularExpression(@"(([A-z]+[' -]?[A-z]*)[ ]?([A-z]+[' -]?[A-z]*)?, )+([A-z]+)",
            ErrorMessage ="Expected format :" +
            " 'City, Country' or 'City, State, CountryCode'")]
        public string BirthCity { get; set; }
    }

    [MetadataType(typeof(ArtistMetadata))]
    public partial class Artist { }

}