using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvemtoryManagement.DatabaseContext
{
    public class InventoryDbContext:DbContext
    {
        public DbSet<CodeSeasons> CodeSeasons { get; set; }
        public DbSet<CodeCares> CodeCares { get; set; }
        public DbSet<CodeColors> CodeColors { get; set; }
        public DbSet<CodeFabrics> CodeFabrics { get; set; }
        public DbSet<CodeFits> CodeFits { get; set; }
        public DbSet<CodeProductGroups> CodeProductGroups { get; set; }
        public DbSet<CodeProductTypes> CodeProductTypes { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TestModelForDb> TestModelForDb { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
