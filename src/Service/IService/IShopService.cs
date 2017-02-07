//-----------------------------------------------------------------------
// <copyright company="SiamMarket">
//     Copyright (c) Siam Market. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using TimeTracker.Model;
using TimeTracker.Service.Common;

namespace TimeTracker.Service.IService
{
    public interface IShopService : IEntityService<Shop>
    {
        Shop GetById(int id);

        List<Shop> GetShopOnDemand(int start, int length, Dictionary<string, string> searchKey, out int recordCount);
    }
}