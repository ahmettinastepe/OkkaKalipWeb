using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.DataAccess.Abstract
{
    public interface IServiceDal : IRepository<Service>
    {
        Service GetServiceDetail(int id);
        List<Service> GetNewsByPageSize(int page, int pageSize);
    }
}