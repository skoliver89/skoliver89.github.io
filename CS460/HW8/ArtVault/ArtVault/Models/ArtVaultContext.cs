namespace ArtVault.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ArtVaultContext : DbContext
    {
        public ArtVaultContext()
            : base("name=ArtVaultContext")
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtWork> ArtWorks { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .Property(e => e.BirthCity)
                .IsUnicode(false);

            modelBuilder.Entity<Artist>()
                .HasMany(e => e.ArtWorks)
                .WithOptional(e => e.Artist1)
                .HasForeignKey(e => e.Artist);

            modelBuilder.Entity<ArtWork>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<ArtWork>()
                .Property(e => e.Artist)
                .IsUnicode(false);

            modelBuilder.Entity<ArtWork>()
                .HasMany(e => e.Genres)
                .WithMany(e => e.ArtWorks)
                .Map(m => m.ToTable("Classifications").MapLeftKey("ArtWork").MapRightKey("Genre"));

            modelBuilder.Entity<Genre>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
