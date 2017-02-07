//-----------------------------------------------------------------------
// <copyright company="SiamMarket">
//     Copyright (c) Siam Market. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;
using TimeTracker.Service.Common;
using TimeTracker.Service.IService;

namespace TimeTracker.Service
{
    public class ShopService : EntityService<Shop>, IShopService
    {
        private readonly IShopRepository _shopRepo;

        public ShopService(IUnitOfWork unitOfWork, IShopRepository shopRepository) : base(unitOfWork, shopRepository)
        {
            _shopRepo = shopRepository;
        }

        public Shop GetById(int id)
        {
            return _shopRepo.Find(a => a.Id == id);
        }

        public List<Shop> GetShopOnDemand(int start, int length, Dictionary<string, string> searchKey,
            out int recordCount)
        {
            //recordCount = 0;
            //var allRecords = _shopRepo.Count();
            var records = _shopRepo.GetAll();
            recordCount = _shopRepo.Count();

            //  var recordWithConditions = Search(allRecords, searchKey);
            // recordCount = recordWithConditions.Count();
            //var data = (length == -1 ? records.OrderBy(a => a.ProjectCustomer.Customer.Id).Skip(start).Take(length).ToList() :
            //    recordWithConditions.OrderBy(a => a.ProjectCustomer.Customer.Id).Skip(start).Take(length).ToList());
            //return data;
            return records.OrderBy(a => a.Id).Skip(start).Take(length).ToList();
        }
    }
}