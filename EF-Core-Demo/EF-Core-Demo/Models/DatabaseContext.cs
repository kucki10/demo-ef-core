using Microsoft.EntityFrameworkCore;
using EF_Core_Demo.Models.DB;

namespace EF_Core_Demo.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder
                .Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

            /*
            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Ratings)
                .WithOne(r => r.Product);

            modelBuilder
                .Entity<Rating>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Ratings);
            */

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<Rating> Ratings { get; set; }

    }

}
