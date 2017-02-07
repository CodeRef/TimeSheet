using TimeTracker.Model;
using TimeTracker.Repository.Common;

namespace TimeTracker.Repository.IRepository
{
    public interface IShelfRepository : IGenericRepository<Shelf>
    {
        // Model.Book GetById(int id);
    }
}