using System.Collections.Generic;
using TimeTracker.Model;
using TimeTracker.Repository.Common;

namespace TimeTracker.Repository.IRepository
{
    public interface IShelfBookRepository : IGenericRepository<ShelfBook>
    {
        //Model.ShelfBook GetByShelfIdAndBookId(int shelfid,int bookid);
        List<Book> GetByShelfId(int id);

        List<Book> GetByBookId(int id);
    }
}