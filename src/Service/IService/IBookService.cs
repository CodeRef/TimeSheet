using System.Collections.Generic;
using TimeTracker.Model;
using TimeTracker.Service.Common;

namespace TimeTracker.Service.IService
{
    public interface IBookService : IEntityService<Book>
    {
        List<Book> All();

        Book GetById(int id);

        Book GetByIsbn(string isbn);
    }
}