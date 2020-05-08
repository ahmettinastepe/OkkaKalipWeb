using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.DataAccess.Abstract
{
    public interface INewsDal : IRepository<News>
    {
        News GetNewsDetail(int id);
        List<News> GetNewsByPageSize(int page, int pageSize);
    }
}