using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Models.Interfaces;

namespace OkkaKalipWeb.UI.Models
{
    public class BaseModel : IBaseModel<BaseModel>
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public Info InfoModel { get; set; }

        public BaseModel GetEntityModal(int id, string title, string controller, string action)
        {
            return new BaseModel()
            {
                Id = id,
                Title = title,
                Controller = controller,
                Action = action
            };
        }
    }
}