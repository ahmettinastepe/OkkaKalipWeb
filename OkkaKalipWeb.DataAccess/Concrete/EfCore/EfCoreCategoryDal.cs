using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreRepository<Category, OkkaKalipContext>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
            using (var context = new OkkaKalipContext())
            {
                var entity = context.Set<ProductCategory>().Where(x => x.CategoryId == categoryId && x.ProductId == productId).FirstOrDefault();
                if (entity != null)
                {
                    context.Set<ProductCategory>().Remove(entity);
                    context.SaveChanges();
                }
            }
        }

        public Category GetByIdWithProducts(int id)
        {
            using (var context = new OkkaKalipContext())
            {
                return context.Categories
                    .Where(x => x.Id == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Product)
                    .FirstOrDefault();
            }
        }
    }
}