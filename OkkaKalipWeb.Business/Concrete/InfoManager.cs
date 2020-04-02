using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.Business.Concrete
{
    public class InfoManager : IInfoService
    {
        private IInfoDal _infoDal;

        public InfoManager(IInfoDal infoDal)
        {
            _infoDal = infoDal;
        }

        public Info GetInfo(int id = 1)
        {
            return _infoDal.GetById(id);
        }

        public string ErrorMessage { get; set; }

        public bool Validate(Info entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.LogoHeader))
            {
                ErrorMessage += "Bir Şirket Logosu Seçmelisiniz.";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Address))
            {
                ErrorMessage += "Şirket Adresini Girmelisiniz";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Tel1))
            {
                ErrorMessage += "Bir Telefon Numarası Girmelisiniz";
                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Email1))
            {
                ErrorMessage += "Bir Email Adresi Girmek Zorundasınız";
                isValid = false;
            }

            return isValid;
        }

        public void Update(Info entity)
        {
            _infoDal.Update(entity);
        }
    }
}
