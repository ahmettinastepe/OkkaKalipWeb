using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreInfoDal : EfCoreRepository<Info, NakisKalipContext>, IInfoDal
    {
        public List<BannerImage> GetAllBannerIamges()
        {
            using var context = new NakisKalipContext();
            return context.Set<BannerImage>().ToList();
        }
    }
}