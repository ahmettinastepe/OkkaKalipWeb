using System;

namespace OkkaKalipWeb.Entities
{
    public class News : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}