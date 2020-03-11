using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        IEnumerable<Product> GetPopularProducts();
        Product GetProductDetails(int id);
    }
}
