using System;
using System.ComponentModel.DataAnnotations;

namespace ArtVault.Models
{
    //Inspired by: https://stackoverflow.com/questions/17321948/is-there-a-rangeattribute-for-datetime

    /// <summary>
    ///Custom Attribute to limit a DateTime/Date Field
    ///Between Now() and the earliest possible year
    /// </summary>
    public class NoFutureDates : RangeAttribute
    {
        public NoFutureDates() : base(typeof(DateTime),
            DateTime.MinValue.ToShortDateString(),
            DateTime.Now.ToShortDateString())
        { }
    }
}