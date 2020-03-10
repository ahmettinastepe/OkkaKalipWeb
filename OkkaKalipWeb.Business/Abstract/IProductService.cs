﻿using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        List<Product> GetPopularProducts();
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
