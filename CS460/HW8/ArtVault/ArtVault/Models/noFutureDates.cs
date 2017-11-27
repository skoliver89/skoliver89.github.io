using System;
using System.ComponentModel.DataAnnotations;

namespace ArtVault.Models
{
    //Inspired by: https://stackoverflow.com/questions/17321948/is-there-a-rangeattribute-for-datetime

    /// <summary>
    ///Custom Attribute to limit a DateTime/Date Field
    ///Between Now() and Now() - 110 years
    /// </summary>
    public class NoFutureDates : RangeAttribute
    {
        public NoFutureDates() : base(typeof(DateTime),
            DateTime.Now.AddYears(-110).ToShortDateString(),
            DateTime.Now.ToShortDateString())
        { }
    }
}