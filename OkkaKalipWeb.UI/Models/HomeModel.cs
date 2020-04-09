using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class HomeModel : BaseModel
    {
        public List<Slider> Sliders { get; set; }
        public AboutModel AboutModel { get; set; }
        public List<News> NewsListModel { get; set; }
        public List<Service> Services { get; set; }
    }
}