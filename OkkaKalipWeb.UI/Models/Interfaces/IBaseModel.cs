using OkkaKalipWeb.Entities.Interfaces;

namespace OkkaKalipWeb.UI.Models.Interfaces
{
    public interface IBaseModel<T> : IBaseEntity where T : class
    {
        T GetEntityModal(int id, string title, string controller, string action);
    }
}