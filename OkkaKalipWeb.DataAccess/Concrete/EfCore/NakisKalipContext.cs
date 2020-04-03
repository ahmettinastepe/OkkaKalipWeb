using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class NakisKalipContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\v11.0;Database=NakisKalipDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<News> News { get; set; }
    }
}