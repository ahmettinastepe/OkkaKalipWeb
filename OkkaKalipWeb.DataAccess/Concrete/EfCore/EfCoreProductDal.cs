using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreProductDal : EfCoreRepository<Product, OkkaKalipContext>, IProductDal
    {
        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }
    }
}
