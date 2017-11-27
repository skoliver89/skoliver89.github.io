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
        //Fix for editfor population: https://stackoverflow.com/questions/33247295/show-only-the-date-in-html-editorfor-helper
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [NoFutureDates(ErrorMessage = ("Future dates are not allowed."))]
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