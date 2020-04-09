using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreServiceDal : EfCoreRepository<Service, NakisKalipContext>, IServiceDal
    {
        public List<Service> GetNewsByPageSize(int page, int pageSize)
        {
            using (var context = new NakisKalipContext())
            {
                var news = context.Services.AsQueryable();
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public Service GetServiceDetail(int id)
        {
            using (var context = new NakisKalipContext())
            {
                return context.Services
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}