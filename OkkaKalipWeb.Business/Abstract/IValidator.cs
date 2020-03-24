using System;
using System.Collections.Generic;
using System.Text;

namespace OkkaKalipWeb.Business.Abstract
{
    public interface IValidator<T>
    {
        public string ErrorMessage { get; set; }
        bool Validate(T entity);
    }
}