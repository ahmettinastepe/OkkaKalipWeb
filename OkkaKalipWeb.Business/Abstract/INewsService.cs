using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface INewsService : IValidator<News>
    {
        News GetById(int id);
        News GetNewsDetail(int id);
        List<News> GetAll();
        List<News> GetNewsByPageSize(int page, int pageSize);
        bool Create(News entity);
        void Update(News entity);
        void Delete(News entity);
    }
}