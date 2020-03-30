using OkkaKalipWeb.UI.Models.Interfaces;

namespace OkkaKalipWeb.UI.Models
{
    public class BaseModel : IBaseModel<BaseModel>
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }

        public BaseModel GetEntityModal(int id, string title)
        {
            return new BaseModel()
            {
                Id = id,
                Title = title
            };
        }
    }
}