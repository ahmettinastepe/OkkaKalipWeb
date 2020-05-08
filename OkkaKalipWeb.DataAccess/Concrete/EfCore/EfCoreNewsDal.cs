using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreNewsDal : EfCoreRepository<News, NakisKalipContext>, INewsDal
    {
        public List<News> GetNewsByPageSize(int page, int pageSize)
        {
            using (var context = new NakisKalipContext())
            {
                var news = context.News.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public News GetNewsDetail(int id)
        {
            using (var context = new NakisKalipContext())
            {
                return context.News
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}