﻿using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkkaKalipWeb.UI.Models
{
    public class CategoryListModel : BaseModel
    {
        public List<Category> Categories { get; set; }
    }
}
