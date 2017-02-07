//-----------------------------------------------------------------------
// <copyright company="SiamMarket">
//     Copyright (c) Siam Market. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Entity;
using TimeTracker.Model;
using TimeTracker.Repository.Common;
using TimeTracker.Repository.IRepository;

namespace TimeTracker.Repository
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(DbContext context) : base(context)
        {
        }
    }
}