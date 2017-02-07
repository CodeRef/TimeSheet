using System.Threading.Tasks;
using TimeTracker.Model.Common;

namespace TimeTracker.Service.Common
{
    public interface IEntityService<in T> : IService
        where T : BaseEntity
    {
        // IQueryable<T> GetAll();
        int Create(T entity);

        int Delete(T entity);

        int Update(T entity);

        #region Async

        Task<int> CreateAsync(T entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(T entity);

        #endregion Async
    }
}