using OkkaKalipWeb.Entities;
using OkkaKalipWeb.UI.Models.Base;
using System;
using System.Collections.Generic;

namespace OkkaKalipWeb.UI.Models
{
    public class PageInfo : BaseModel
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }

    public class ProductListModel : BaseListModel
    {
        public List<Product> Products { get; set; }
    }
}