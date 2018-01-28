

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{ //base class gives access to EFC's functionality
    //derived class will adds properties to read and write to the app's data
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //provides access to product objects in the database; read and write
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
 
