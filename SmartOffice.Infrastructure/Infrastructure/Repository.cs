using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SmartOffice.Infrastructure.Infrastructure
{
    public class Repository<T,U> : IRepository<T,U> 
        where T : class 
        where U : DbContext
    {
        private U context;
        private DbSet<T> entitySet;
        public Repository(U context)
        {
            this.context = context;
            entitySet = context.Set<T>();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return entitySet.Where(where).FirstOrDefault();
        }
        public T GetById(long Id)
        {
            return entitySet.Find(Id);
        }
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return entitySet.Where(where).ToList();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return entitySet.Where(where);
        }
        public IEnumerable<T> GetAll()
        {
            return entitySet.AsEnumerable();
        }
        public IQueryable<T> QueryAll()
        {
            return entitySet.AsQueryable();
        }

        public void Add(T entity)
        {
            entitySet.Add(entity);
            context.Entry(entity).State = EntityState.Added;
        }
        public void Delete(T entity)
        {
            entitySet.Remove(entity);
        }
        public void Update(T entity)
        {
            entitySet.Update(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void UpdateDirect(T entity)
        {
            entitySet.Update(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}
