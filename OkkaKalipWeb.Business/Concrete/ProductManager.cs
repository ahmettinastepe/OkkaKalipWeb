using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OkkaKalipWeb.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Create(Product entity)
        {
            _productDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetPopularProducts()
        {
            return _productDal.GetAll();
        }
    }
}
