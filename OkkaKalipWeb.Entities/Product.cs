using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Properties { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
