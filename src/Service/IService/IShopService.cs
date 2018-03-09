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
    public interface IShopService : IEntityService<Prospect>
    {
        Prospect GetById(int id);

        List<Prospect> GetShopOnDemand(int start, int length, Dictionary<string, string> searchKey, out int recordCount);
    }
}