using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace SmartOffice.Infrastructure.Infrastructure
{
    public interface IRepository<T, U> 
        where T : class
        where U : DbContext
    {
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> Where(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IQueryable<T> QueryAll();
        T GetById(long Id);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void UpdateDirect(T entity);
    }
}
