using System.Collections.Generic;
using System.Linq;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;
using TimeTracker.Service.Common;
using TimeTracker.Service.IService;

namespace TimeTracker.Service
{
    public class ShelfService : EntityService<Shelf>, IShelfService
    {
        private readonly IShelfRepository _shelfRepo;

        public ShelfService(IUnitOfWork unitOfWork, IShelfRepository shelfRepository)
            : base(unitOfWork, shelfRepository)
        {
            _shelfRepo = shelfRepository;
        }

        public List<Shelf> All()
        {
            return _shelfRepo.GetAll().ToList();
        }

        public Shelf GetById(int id)
        {
            var obj = _shelfRepo.Find(a => a.Id == id);
            return obj;
        }
    }
}