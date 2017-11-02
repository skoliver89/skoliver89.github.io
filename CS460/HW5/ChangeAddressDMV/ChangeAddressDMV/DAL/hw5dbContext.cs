using ChangeAddressDMV.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChangeAddressDMV.DAL
{
    public class hw5dbContext : DbContext
    {
        public hw5dbContext() : base("name=HW5DBContext")
        { }

        public virtual DbSet<Request> Requests { get; set; }
    }
}