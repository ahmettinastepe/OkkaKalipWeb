using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreInfoDal : EfCoreRepository<Info, NakisKalipContext>, IInfoDal
    {
    }
}