using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Functions;
using OkkaKalipWeb.UI.Models.Interfaces;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class BaseModel : IBaseModel<BaseModel>
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public Info InfoModel { get; set; }
        public List<BannerImage> BannerImages { get; set; }

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

        public string GetBannerImageUrl()
        {
            if (BannerImages == null)
                return null;

            var entity = BannerImages.GetRandomEntity();
            return entity.ImageUrl;
        }
    }
}