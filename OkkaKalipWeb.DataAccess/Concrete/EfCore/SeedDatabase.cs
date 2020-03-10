using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new OkkaKalipContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                    context.Categories.AddRange(Categories);

                if (context.Products.Count() == 0)
                    context.Products.AddRange(Products);
            }

            context.SaveChanges();
        }

        private static Category[] Categories =
        {
            new Category() {Name="Telefon"},
            new Category() {Name="Bilgisayar"}
        };

        private static Product[] Products =
        {
            new Product(){Name="Samsung S5",Price=1000,ImageUrl="https://via.placeholder.com/750x750.png"},
            new Product(){Name="Samsung S6",Price=2000,ImageUrl="https://via.placeholder.com/750x750.png"},
            new Product(){Name="Samsung S7",Price=3000,ImageUrl="https://via.placeholder.com/750x750.png"},
            new Product(){Name="Samsung S8",Price=4000,ImageUrl="https://via.placeholder.com/750x750.png"},
            new Product(){Name="Samsung S9",Price=5000,ImageUrl="https://via.placeholder.com/750x750.png"}
        };
    }
}
