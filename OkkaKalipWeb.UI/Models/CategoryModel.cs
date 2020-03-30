using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class CategoryModel : BaseModel
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
