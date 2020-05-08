using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IClientsLogoService:IValidator<ClientsLogo>
    {
        ClientsLogo GetById(int id);
        List<ClientsLogo> GetAll();
        bool Create(ClientsLogo entity);
        void Update(ClientsLogo entity);
        void Delete(ClientsLogo entity);
    }
}