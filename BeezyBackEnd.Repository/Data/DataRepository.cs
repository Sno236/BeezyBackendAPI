using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BeezyBackend.Repository
{
    public class DataRepository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> _entities;
        string _errorMessage = string.Empty;

        public DataRepository(DbContext context)
        {
            this._context = context;
            _entities = context.Set<T>();
        }     

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return Table.FirstOrDefault(predicate);

        }
        public IQueryable<T> Table
        {
            get
            {
                return _context.Set<T>();
            }
        }

    }
}

