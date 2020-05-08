using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.DataAccess.Abstract
{
    public interface IInfoDal : IRepository<Info>
    {
        List<BannerImage> GetAllBannerIamges();
    }
}