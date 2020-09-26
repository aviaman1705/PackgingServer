using Microsoft.EntityFrameworkCore;

namespace PackgingAPI.Models
{
    public class PackgingDB : DbContext
    {
        public PackgingDB(DbContextOptions<PackgingDB> options)
           : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<ProductPlace> ProductPlaces { get; set; }
        public DbSet<WarehousesType> WarehousesTypes { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ProductPlace>().HasKey(bc => new { bc.ProductId, bc.PlaceId });

            //modelBuilder.Entity<ProductPlace>().HasOne(bc => bc.Product).WithMany(b => b.ProductPlaces).HasForeignKey(bc => bc.ProductId);

            //modelBuilder.Entity<ProductPlace>().HasOne(bc => bc.Place).WithMany(c => c.ProductPlaces).HasForeignKey(bc => bc.PlaceId);
        }
    }
}
