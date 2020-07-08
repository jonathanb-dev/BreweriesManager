using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relationships
            builder.Entity<Brewery>()
                .HasMany(be => be.Beers)
                .WithOne(br => br.Brewery);

            builder.Entity<WholesalerBeer>()
                .HasKey(wb => new { wb.WholesalerId, wb.BeerId });

            builder.Entity<WholesalerBeer>()
                .HasOne(wb => wb.Wholesaler)
                .WithMany(w => w.WholesalerBeers)
                .HasForeignKey(wb => wb.WholesalerId);

            builder.Entity<WholesalerBeer>()
                .HasOne(wb => wb.Beer)
                .WithMany(w => w.WholesalerBeers)
                .HasForeignKey(wb => wb.BeerId);
        }
    }
}