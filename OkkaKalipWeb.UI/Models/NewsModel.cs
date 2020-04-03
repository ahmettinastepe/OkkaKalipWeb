using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Models.Base;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class NewsModel : BaseListModel
    {
        public News News { get; set; }
        public List<News> NewsList { get; set; }
    }
}