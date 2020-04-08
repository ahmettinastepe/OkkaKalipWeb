using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreAboutDal : EfCoreRepository<About, NakisKalipContext>, IAboutDal
    {
    }
}