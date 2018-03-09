using System.Collections.Generic;
using TimeTracker.Model;
using TimeTracker.Repository.Common;

namespace TimeTracker.Repository.IRepository
{
    public interface IShelfBookRepository : IGenericRepository<ShelfBook>
    {
        //Model.ShelfBook GetByShelfIdAndBookId(int shelfid,int bookid);
        List<Project> GetByShelfId(int id);

        List<Project> GetByBookId(int id);
    }
}