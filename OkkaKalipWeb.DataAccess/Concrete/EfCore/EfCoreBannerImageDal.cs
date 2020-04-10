using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreBannerImageDal : EfCoreRepository<BannerImage, NakisKalipContext>, IBannerImageDal
    {
    }
}