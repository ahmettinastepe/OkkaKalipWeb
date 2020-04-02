using OkkaKalipWeb.Entities;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IInfoService : IValidator<Info>
    {
        Info GetInfo(int id = 1);
        void Update(Info entity);
    }
}