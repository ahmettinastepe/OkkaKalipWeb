using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}