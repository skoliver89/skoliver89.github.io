namespace GiphySearch.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RequestsContext : DbContext
    {
        public RequestsContext()
            : base("name=RequestsContext")
        {
        }

        public virtual DbSet<RequestLog> RequestLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestLog>()
                .Property(e => e.RequestClientIP)
                .IsUnicode(false);

            modelBuilder.Entity<RequestLog>()
                .Property(e => e.RequestClientAgent)
                .IsUnicode(false);

            modelBuilder.Entity<RequestLog>()
                .Property(e => e.RequestQuery)
                .IsUnicode(false);

            modelBuilder.Entity<RequestLog>()
                .Property(e => e.RequestLang)
                .IsUnicode(false);

            modelBuilder.Entity<RequestLog>()
                .Property(e => e.RequestRating)
                .IsUnicode(false);
        }
    }
}
