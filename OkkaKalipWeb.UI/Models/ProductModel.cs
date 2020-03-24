using OkkaKalipWeb.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 10, ErrorMessage = "Ürün İsmi Minimum 10, maksimum 60 karakter olabilir.")]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        [Range(0, 100000, ErrorMessage = "Fiyat sıfırdan (0) küçük olamaz")]
        public decimal Price { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}