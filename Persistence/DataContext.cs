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
        public DbSet<WholesalerBeer> WholesalerBeers { get; set; }
        public DbSet<SaleHeader> SaleHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relationships

            // Brewery
            /*builder.Entity<Brewery>()
                .HasMany(br => br.Beers)
                .WithOne(be => be.Brewery);*/

            // Wholesaler
            /*builder.Entity<Wholesaler>()
                .HasMany(w => w.SaleHeaders)
                .WithOne(sh => sh.Wholesaler);*/

            // WholesalerBeer
            builder.Entity<WholesalerBeer>()
                .HasKey(wb => new { wb.WholesalerId, wb.BeerId });

            builder.Entity<WholesalerBeer>()
                .HasOne(wb => wb.Wholesaler)
                .WithMany(w => w.WholesalerBeers)
                .HasForeignKey(wb => wb.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WholesalerBeer>()
                .HasOne(wb => wb.Beer)
                .WithMany(b => b.WholesalerBeers)
                .HasForeignKey(wb => wb.BeerId)
                .OnDelete(DeleteBehavior.Cascade);

            // SaleHeader
            /*builder.Entity<SaleHeader>()
                .HasMany(sh => sh.SaleLines)
                .WithOne(sl => sl.SaleHeader);*/
        }
    }
}