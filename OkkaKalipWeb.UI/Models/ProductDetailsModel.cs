using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class ProductDetailsModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}