using OkkaKalipWeb.Business.Abstract;
using OkkaKalipWeb.DataAccess.Abstract;
using OkkaKalipWeb.Entities;
using System.Collections.Generic;

namespace OkkaKalipWeb.Business.Concrete
{
    public class NewsManager : INewsService
    {
        private INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public bool Create(News entity)
        {
            if (Validate(entity))
            {
                _newsDal.Create(entity);
                return true;
            }
            else
                return false;
        }

        public void Delete(News entity)
        {
            _newsDal.Delete(entity);
        }

        public List<News> GetAll()
        {
            return _newsDal.GetAll();
        }

        public News GetById(int id)
        {
            return _newsDal.GetById(id);
        }

        public News GetNewsDetail(int id)
        {
            return _newsDal.GetNewsDetail(id);
        }

        public void Update(News entity)
        {
            _newsDal.Update(entity);
        }

        public string ErrorMessage { get; set; }

        public bool Validate(News entity)
        {
            var isValid = true;

            if (string.IsNullOrEmpty(entity.Title))
            {
                ErrorMessage += "Haber ismi girmelisiniz.";
                isValid = false;
            }
            if (string.IsNullOrEmpty(entity.ImageUrl))
            {
                ErrorMessage += "Bir Haber Resmi Seçmelisiniz";
                isValid = false;
            }

            return isValid;
        }

        public List<News> GetNewsByPageSize(int page, int pageSize)
        {
            return _newsDal.GetNewsByPageSize(page, pageSize);
        }
    }
}