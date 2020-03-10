using Microsoft.EntityFrameworkCore;
using OkkaKalipWeb.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OkkaKalipWeb.DataAccess.Concrete.EfCore
{
    public class EfCoreRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext, new()
    {
        public void Create(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                     ? context.Set<TEntity>().ToList()
                     : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity GetById(int Id)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Find(Id);
            }
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).SingleOrDefault();
            }
        }
    }
}
