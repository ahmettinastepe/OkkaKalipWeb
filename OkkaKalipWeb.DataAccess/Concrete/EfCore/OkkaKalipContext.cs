using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class OkkaKalipContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=OkkaKalipDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
