using Microsoft.EntityFrameworkCore;
using PastryShopAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Models
{
    public class PastryShopContext : DbContext
    {
        public PastryShopContext(DbContextOptions<PastryShopContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<PastryShop> PastryShop { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        

    }
}
