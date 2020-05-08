using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll();
        }


        public string ErrorMessage { get; set; }

        public bool Validate(Slider entity)
        {
            var isValid = true;


            if (string.IsNullOrEmpty(entity.ImageUrl))
            {
                ErrorMessage += "Bir Slider Resmi Seçmelisiniz.";
                isValid = false;
            }

            return isValid;
        }

        public bool Create(Slider entity)
        {
            if (Validate(entity))
            {
                _sliderDal.Create(entity);
                return true;
            }
            else
                return false;
        }

        public void Update(Slider entity)
        {
            _sliderDal.Update(entity);
        }

        public void Delete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public Slider GetById(int id)
        {
            return _sliderDal.GetById(id);
        }
    }
}