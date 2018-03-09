using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;

namespace TimeTracker.Repository
{
    //public class ShelfBookRepository : GenericRepository<ShelfBook>, IShelfBookRepository
    //{
    //    public ShelfBookRepository(DbContext context)
    //        : base(context)
    //    {
    //    }

    //    public List<Project> GetByBookId(int id)
    //    {
    //        return _dbset.Where(a => a.BookId == id).Select(a => a.Book).ToList();
    //    }

    //    public List<Project> GetByShelfId(int id)
    //    {
    //        return _dbset.Where(a => a.ShelfId == id).Select(a => a.Book).ToList();
    //    }

    //    //    return _dbset.FirstOrDefault(a => a.ShelfId == shelfid && a.BookId == bookid);
    //    //{

    //    //public ShelfBook GetByShelfIdAndBookId(int shelfid, int bookid)
    //    //}
    //}
}