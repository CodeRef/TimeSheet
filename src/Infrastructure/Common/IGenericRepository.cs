using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TimeTracker.Model.Common;

namespace TimeTracker.Repository.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        #region Command

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        #endregion Command

        #region Query

        IQueryable<T> GetAll();

        T Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);

        int Count();

        int Count(Expression<Func<T, bool>> predicate);

        #endregion Query

        #region Asynchronous Query

        Task<List<T>> GetAllAsync();

        Task<int> CountAllAsync();

        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        #endregion Asynchronous Query
    }
}