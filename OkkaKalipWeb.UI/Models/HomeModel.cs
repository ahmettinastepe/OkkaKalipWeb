using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class HomeModel : BaseModel
    {
        public List<Slider> Sliders { get; set; }
    }
}