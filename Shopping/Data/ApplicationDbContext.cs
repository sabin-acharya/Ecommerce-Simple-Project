using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Models;

namespace Shopping.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Database Tables
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<CartItemModel> CartItems { get; set; }

        public DbSet<CartModel> Carts { get; set; }

        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<LocationModel> Buys { get; set; }

        public DbSet<BuyCartIdModel> BuyCartIdModels { get; set; }

        public DbSet<ReviewModel> Reviews { get; set; }

        
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            {
                base.OnModelCreating(Builder);
                seedRoles(Builder);
            }

            
        }

        // Assigining the roles
        private static void seedRoles(ModelBuilder Builder)
        {
            Builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Customer", ConcurrencyStamp = "2", NormalizedName = "Customer" }
                );

        }
        
    }
    
}