using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OkkaKalipWeb.UI.Models
{
    public class NewsModel : BaseModel
    {
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Bir haber başlığı zorunludur."), StringLength(200, ErrorMessage = "Haber başlığı maksimum 200 karakter olabilir.")]
        public override string Title { get; set; }


        public string Author { get; set; }

        [Required(ErrorMessage = "Haber açıklaması girmek zorunludur.")]
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class NewsListModel : BaseListModel
    {
        public List<News> NewsList { get; set; }
    }
}