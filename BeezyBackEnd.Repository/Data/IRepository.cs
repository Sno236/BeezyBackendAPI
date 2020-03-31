using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BeezyBackend.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        
        T Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> Table { get; }
        
    }
}
