using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreRepository<Product, OkkaKalipContext>, IProductDal
    {
        public Product GetProductDetails(int id)
        {
            using (var context = new OkkaKalipContext())
            {
                return context.Products
                    .Where(x => x.Id == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            using (var context = new OkkaKalipContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                    products = products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.ProductCategories.Any(c => c.Category.Name.ToLower() == category.ToLower()));

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int GetProductsByCategory(string category)
        {
            using (var context = new OkkaKalipContext())
            {
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                    products = products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.ProductCategories.Any(c => c.Category.Name.ToLower() == category.ToLower()));

                return products.Count();
            }
        }
    }
}