using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }


        public About GetAbout(int id = 1)
        {
            return _aboutDal.GetById(id);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }

        public string ErrorMessage { get; set; }
        public bool Validate(About entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.ImageUrl))
            {
                ErrorMessage += "Resim seçmek zorunludur.";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.AboutTitle))
            {
                ErrorMessage += "Lütfen Başlık giriniz.";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Founder))
            {
                ErrorMessage += "Lütfen yetkili bir kişi ismi giriniz";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Mission))
            {
                ErrorMessage += "Lütfen misyon alanını doldurun";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Vision))
            {
                ErrorMessage += "Lütfen vizyon alanını doldurun";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.ValuesTitle))
            {
                ErrorMessage += "Lütfen başlık girin";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.ValuesDescription))
            {
                ErrorMessage += "Lütfen açıklama girin";
                isValid = false;
            }

            return isValid;
        }
    }
}