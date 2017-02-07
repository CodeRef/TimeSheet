using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeTracker.Model.Common;

namespace TimeTracker.Repository.Common
{
    /// <summary>
    ///     Note: I didn’t use IQueryable for public methods because EF queries should NOT be made outside of repository layer.
    ///     <-- Change to be --> IEnumerable<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected readonly IDbSet<T> _dbset;
        protected DbContext DbContext;

        public GenericRepository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException("DbContext can not be null.");
            DbContext = context;
            _dbset = context.Set<T>();
        }

        #region Command

        public virtual void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion Command

        #region Query

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().SingleOrDefault(predicate);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).AsQueryable();
            ;
        }

        public int Count()
        {
            return DbContext.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Count(predicate);
        }

        #endregion Query

        #region Asynchronous Query

        public async Task<List<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<int> CountAllAsync()
        {
            return await DbContext.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().CountAsync(predicate);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbContext.Set<T>().Where(predicate).ToListAsync();
        }

        #endregion Asynchronous Query
    }
}