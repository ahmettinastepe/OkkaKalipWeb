using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class ServiceModel : BaseModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class ServiceListModel : BaseModel
    {
        public List<Service> Services { get; set; }
    }
}