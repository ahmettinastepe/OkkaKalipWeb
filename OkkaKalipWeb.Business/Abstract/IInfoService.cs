using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IInfoService : IValidator<Info>
    {
        Info GetInfo(int id = 1);
        void Update(Info entity);
        List<BannerImage> GetAllBannerIamges();
    }
}