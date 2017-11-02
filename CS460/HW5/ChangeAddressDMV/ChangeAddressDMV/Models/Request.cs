using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChangeAddressDMV.Models
{
    public class Request
    {
        [Required]
        [Display(Name ="Request #")]
        public int RequestID { get; set; }

        [Required]
        [Display(Name ="ODL/PERMIT/ID/CUSTOMER #")]
        public int IDNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "DATE OF BIRTH")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name ="FULL LEGAL NAME")]
        public string FullName { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name ="NEW RESIDENCE ADDRESS")]
        public string NewResAddr { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "CITY, STATE, ZIP CODE")]
        public string NewResCityStateZip { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "COUNTY")]
        public string NewResCounty { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "NEW MAILING ADDRESS")]
        public string NewMailAddr { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "CITY, STATE, ZIP CODE")]
        public string NewMailCityStateZip { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "COUNTY")]
        public string NewMailCounty { get; set; }

    }
}
