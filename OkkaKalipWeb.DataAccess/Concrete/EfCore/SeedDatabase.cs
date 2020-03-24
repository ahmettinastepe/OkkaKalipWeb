using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.Entities;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new NakisKalipContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                    context.Categories.AddRange(Categories);

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategoies);
                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories =
        {
            new Category() {Name="Telefon"},
            new Category() {Name="Bilgisayar"},
            new Category() {Name="Elektronik"}
        };

        private static Product[] Products =
        {
            new Product() {Name="Samsung S5",Price=1000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 1"},
            new Product() {Name="Samsung S6",Price=2000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 2"},
            new Product() {Name="Samsung S7",Price=3000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 3"},
            new Product() {Name="Samsung S8",Price=4000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 4"},
            new Product() {Name="Samsung S9",Price=5000,ImageUrl="urun-resim-yok.png", Description="Güzel Ürün 5"}
        };

        private static ProductCategory[] ProductCategoies =
        {
            new ProductCategory() { Product= Products[0],Category= Categories[0]},
            new ProductCategory() { Product= Products[0],Category= Categories[2]},
            new ProductCategory() { Product= Products[1],Category= Categories[0]},
            new ProductCategory() { Product= Products[1],Category= Categories[1]},
            new ProductCategory() { Product= Products[2],Category= Categories[0]},
            new ProductCategory() { Product= Products[2],Category= Categories[2]},
            new ProductCategory() { Product= Products[3],Category= Categories[1]}
        };
    }
}