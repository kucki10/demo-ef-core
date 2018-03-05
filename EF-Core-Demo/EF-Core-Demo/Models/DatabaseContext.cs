using Microsoft.EntityFrameworkCore;
using EF_Core_Demo.Models.DB;

namespace EF_Core_Demo.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DbSet<Ratings> Ratings { get; set; }

    }

}
