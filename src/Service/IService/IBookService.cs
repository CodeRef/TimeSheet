using System.Collections.Generic;
using TimeTracker.Model;
using TimeTracker.Service.Common;

namespace TimeTracker.Service.IService
{
    public interface IBookService : IEntityService<Project>
    {
        List<Project> All();

        Project GetById(int id);

        Project GetByIsbn(string isbn);
    }
}