using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }
        public List<Category> Categories { get; set; }
    }
}