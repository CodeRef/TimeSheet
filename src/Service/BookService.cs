using System.Collections.Generic;
using System.Linq;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;
using TimeTracker.Service.Common;
using TimeTracker.Service.IService;

namespace TimeTracker.Service
{
    public class BookService : EntityService<Project>, IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IUnitOfWork unitOfWork, IBookRepository bookRepository)
            : base(unitOfWork, bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public List<Project> All()
        {
            return _bookRepo.GetAll().ToList();
        }

        public Project GetById(int id)
        {
            var obj = _bookRepo.Find(a => a.Id == id);
            return obj;
        }

        public Project GetByIsbn(string isbn)
        {
            //var obj = _bookRepo.Find(a => a.ISBN.Trim().Equals(isbn.Trim()));
            return null;
            //return obj;
        }
    }
}