using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface ISliderService:IValidator<Slider>
    {
        List<Slider> GetAll();
        bool Create(Slider entity);
        void Update(Slider entity);
        void Delete(Slider entity);
    }
}