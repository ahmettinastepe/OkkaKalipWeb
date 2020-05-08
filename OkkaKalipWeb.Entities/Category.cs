using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
