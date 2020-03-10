using OkkaKalipWeb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
