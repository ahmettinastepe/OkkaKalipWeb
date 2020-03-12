using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        Product GetProductDetails(int id);
        int GetProductsByCategory(string category);
    }
}
