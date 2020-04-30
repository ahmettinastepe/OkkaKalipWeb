using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class NakisKalipContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=46.45.178.125; Database=NakisKalipDb; User Id=ozelsebe_dbuser; Password=Sabh4257.;");
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
        public DbSet<About> About { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ClientsLogo> ClientsLogos { get; set; }
        public DbSet<BannerImage> BannerImages { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}