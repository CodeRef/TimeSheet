using TimeTracker.Model;
using TimeTracker.Repository.Common;

namespace TimeTracker.Repository.IRepository
{
    public interface IBookRepository : IGenericRepository<Project>
    {
        // Model.Book GetById(int id);
    }
}