using OkkaKalipWeb.UI.Enums;

namespace OkkaKalipWeb.Entities
{
    public class Image : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public ImageType ImageType { get; set; }
    }
}