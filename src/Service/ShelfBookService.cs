using System.Collections.Generic;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;
using TimeTracker.Service.Common;
using TimeTracker.Service.IService;

namespace TimeTracker.Service
{
    public class ShelfBookService : EntityService<ShelfBook>, IShelfBookService
    {
        private readonly IShelfBookRepository _shelfBookRepo;

        public ShelfBookService(IUnitOfWork unitOfWork, IShelfBookRepository shelfBookRepository)
            : base(unitOfWork, shelfBookRepository)
        {
            _shelfBookRepo = shelfBookRepository;
        }

        public List<Book> GetBookByShelfId(int id)
        {
            var books = _shelfBookRepo.GetByShelfId(id);
            return books;
        }

        //    var obj = _ShelfBookRepo.Find(a => a.Id == id);
        //{

        //public Model.ShelfBook GetById(int id)
        //    return obj;
        //}
    }
}