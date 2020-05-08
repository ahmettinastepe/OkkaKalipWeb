using OkkaKalipWeb.Entities.Interfaces;

namespace OkkaKalipWeb.Entities
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}