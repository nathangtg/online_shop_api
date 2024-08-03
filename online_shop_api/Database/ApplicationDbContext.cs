using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using online_shop_api.Models;

namespace online_shop_api.Database
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}