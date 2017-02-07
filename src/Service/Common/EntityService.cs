using System;
using System.Threading.Tasks;
using TimeTracker.Model.Common;
using TimeTracker.Repository.Common;

namespace TimeTracker.Service.Common
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #region Command

        public virtual int Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Add(entity);
            return _unitOfWork.Commit();
        }

        public virtual int Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Edit(entity);
            return _unitOfWork.Commit();
        }

        public virtual int Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Delete(entity);
            return _unitOfWork.Commit();
        }

        #endregion Command

        #region Query

        // Use repository

        #endregion Query

        #region Asynchronous command

        public async Task<int> CreateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Add(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Edit(entity);
            return await _unitOfWork.CommitAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repository.Delete(entity);
            return await _unitOfWork.CommitAsync();
        }

        #endregion Asynchronous command
    }
}