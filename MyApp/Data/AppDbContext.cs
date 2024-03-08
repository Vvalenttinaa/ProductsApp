using Microsoft.EntityFrameworkCore;
using MyApp.Models.Entities;
using Type = MyApp.Models.Entities.Type;

namespace MyApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<Models.Entities.Attribute> Attribute { get; set; }
        public DbSet<Attributename> AttributeName { get; set; }
        public DbSet<Type> Type { get; set; } 
        public DbSet<Unit> Unit { get; set; }
        public DbSet<User> User { get; set; }
      
    }
}
