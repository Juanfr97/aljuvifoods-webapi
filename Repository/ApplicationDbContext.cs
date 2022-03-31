using aljuvifoods_webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace aljuvifoods_webapi.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }

        //Config
        protected override void OnModelCreating(ModelBuilder model)
        {
           // base.OnModelCreating(model);
           // model.ApplyConfiguration(new OrderProductConfiguration());
            model.Entity<OrderProduct>().HasKey(orp => new { orp.Id });
            //model.Entity<Order>().HasMany(o => o.Products).WithOne(o => o.order);
            
        }

    }
}
