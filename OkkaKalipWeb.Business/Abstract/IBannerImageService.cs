using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IBannerImageService : IValidator<BannerImage>
    {
        BannerImage GetById(int id);
        List<BannerImage> GetAll();
        bool Create(BannerImage entity);
        void Update(BannerImage entity);
        void Delete(BannerImage entity);
    }
}