using System.Data.Entity;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;

namespace TimeTracker.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext context)
            : base(context)
        {
        }

        //public Model.Book GetById(int id)
        //{
        //    return _dbset.FirstOrDefault(a => a.Id == id);
        //}
    }
}