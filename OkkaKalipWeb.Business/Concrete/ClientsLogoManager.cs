using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Concrete
{
    public class ClientsLogoManager : IClientsLogoService
    {
        private IClientsLogoDal _clientsLogoDal;

        public ClientsLogoManager(IClientsLogoDal clientsLogoDal)
        {
            _clientsLogoDal = clientsLogoDal;
        }

        public bool Create(ClientsLogo entity)
        {
            if (Validate(entity))
            {
                _clientsLogoDal.Create(entity);
                return true;
            }
            else
                return false;
        }

        public void Delete(ClientsLogo entity)
        {
            _clientsLogoDal.Delete(entity);
        }

        public List<ClientsLogo> GetAll()
        {
            return _clientsLogoDal.GetAll();
        }

        public ClientsLogo GetById(int id)
        {
            return _clientsLogoDal.GetById(id);
        }

        public void Update(ClientsLogo entity)
        {
            _clientsLogoDal.Update(entity);
        }

        public string ErrorMessage { get; set; }

        public bool Validate(ClientsLogo entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.ImageUrl))
            {
                ErrorMessage += "Bir Resim Seçmelisiniz.";
                isValid = false;
            }

            return isValid;
        }
    }
}