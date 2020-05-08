using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IAboutService:IValidator<About>
    {
        About GetAbout(int id = 1);
        void Update(About entity);
    }
}