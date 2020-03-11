using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreRepository<Product, OkkaKalipContext>, IProductDal
    {
        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

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
    }
}