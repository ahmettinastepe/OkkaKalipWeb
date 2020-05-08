using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreClientsLogoDal : EfCoreRepository<ClientsLogo, NakisKalipContext>, IClientsLogoDal
    {
    }
}