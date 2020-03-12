using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Create(Category entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}