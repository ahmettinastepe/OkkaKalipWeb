using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Concrete
{
    public class BannerImageManager : IBannerImageService
    {
        private IBannerImageDal _bannerImageDal;

        public BannerImageManager(IBannerImageDal bannerImageDal)
        {
            _bannerImageDal = bannerImageDal;
        }

        public bool Create(BannerImage entity)
        {
            if (Validate(entity))
            {
                _bannerImageDal.Create(entity);
                return true;
            }
            else
                return false;
        }

        public void Delete(BannerImage entity)
        {
            _bannerImageDal.Delete(entity);
        }

        public List<BannerImage> GetAll()
        {
            return _bannerImageDal.GetAll();
        }

        public BannerImage GetById(int id)
        {
            return _bannerImageDal.GetById(id);
        }

        public void Update(BannerImage entity)
        {
            _bannerImageDal.Update(entity);
        }
        public string ErrorMessage { get; set; }

        public bool Validate(BannerImage entity)
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