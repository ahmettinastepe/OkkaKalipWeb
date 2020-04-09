using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IAboutServicesService : IValidator<Service>
    {
        Service GetById(int id);
        Service GetNewsDetail(int id);
        List<Service> GetAll();
        List<Service> GetNewsByPageSize(int page, int pageSize);
        bool Create(Service entity);
        void Update(Service entity);
        void Delete(Service entity);
    }
}