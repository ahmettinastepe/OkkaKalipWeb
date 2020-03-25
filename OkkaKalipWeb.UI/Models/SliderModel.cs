using OkkaKalipWeb.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class SliderModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 5, ErrorMessage = "Slider Başlığı Minimum 5, maksimum 60 karakter olabilir.")]
        public string Title { get; set; }

        [StringLength(200, MinimumLength = 5, ErrorMessage = "Slider Başlığı Minimum 5, maksimum 200 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bir Slider Resmi Seçmek Zorunludur.")]
        public string ImageUrl { get; set; }
    }

    public class SliderListModel
    {
        public List<Slider> Sliders { get; set; }
    }
}