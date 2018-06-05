using Ark.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Ark.Data
{
    public interface IRepository<T> 
    {
        T GetById(int Id,
                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                    bool noTracking = true);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> order = null,
                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                    bool noTracking = true);

        IPagedRecords<T> GetPagedRecords(Expression<Func<T, bool>> predicate = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> order = null,
                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                    bool noTracking = true,
                    int pageSize = 10,
                    int pageNumber = 1);

        long Count(Expression<Func<T, bool>> predicate = null);

        void Insert(T entity);
        void Insert(params T[] entities);
        void Insert(IEnumerable<T> entities);
        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);
    }

    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> order = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool noTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (noTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (order != null)
                return order(query);
            else
                return query;

        }

        public IPagedRecords<T> GetPagedRecords(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> order = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool noTracking = true, int pageSize = 10, int pageNumber = 1)
        {
            IQueryable<T> query = _dbSet;
            if (noTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (order != null)
                return order(query).ToPagedRecords(pageSize, pageNumber);
            else
                return query.ToPagedRecords(pageSize, pageNumber);

        }

        public long Count(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet.Count();
            }
            else
            {
                return _dbSet.Count(predicate);
            }
        }

        public T GetById(int Id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool noTracking = true)
        {
            IQueryable<T> query = _dbSet;
            if (noTracking)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            return query.Where(o => o.Id == Id).FirstOrDefault();
        }

        public void Insert(T entity) => _dbSet.Add(entity);
        public void Insert(params T[] entities) => _dbSet.AddRange(entities);
        public void Insert(IEnumerable<T> entities) => _dbSet.AddRange(entities);

        public void Update(T entity) => _dbSet.Update(entity);
        public void Update(params T[] entities) => _dbSet.UpdateRange(entities);
        public void Update(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);

        public void Delete(T entity) => _dbSet.Remove(entity);
        public void Delete(params T[] entities) => _dbSet.RemoveRange(entities);
        public void Delete(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);

    }

}
