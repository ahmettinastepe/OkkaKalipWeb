using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Concrete
{
    public class AboutServicesManager : IAboutServicesService
    {
        private IServiceDal _serviceDal;

        public AboutServicesManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public bool Create(Service entity)
        {
            if (Validate(entity))
            {
                _serviceDal.Create(entity);
                return true;
            }
            else
                return false;
        }

        public void Delete(Service entity)
        {
            _serviceDal.Delete(entity);
        }

        public List<Service> GetAll()
        {
            return _serviceDal.GetAll();
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(id);
        }

        public List<Service> GetNewsByPageSize(int page, int pageSize)
        {
            return _serviceDal.GetNewsByPageSize(page, pageSize);
        }

        public Service GetNewsDetail(int id)
        {
            return _serviceDal.GetServiceDetail(id);
        }

        public void Update(Service entity)
        {
            _serviceDal.Update(entity);
        }

        public string ErrorMessage { get; set; }

        public bool Validate(Service entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Title))
            {
                ErrorMessage += "Servis ismi girmelisiniz.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(entity.ImageUrl))
            {
                ErrorMessage += "Bir Servis Resmi Seçmelisiniz";
                isValid = false;
            }

            return isValid;
        }
    }
}