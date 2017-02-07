using RestMeet.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RestMeet.Areas.Backend.Controllers
{
    public class ShopController : Controller
    {
        private IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        // GET: Shop
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetShopOnDemand(int start, int length)
        {
            var searchKey = SetProjectCustomerSearchKey();
            var countRecord = 0;
            var shop = _shopService.GetShopOnDemand(0, 10, searchKey, out countRecord);
            var records = new List<string[]>();
            foreach (var act in shop)
            {
                records.Add(new[]
                {
                    "<input type=\"checkbox\" class=\"group-checkable\">",
                    act.Id.ToString(),
                    act.Name,
                    "",//act.ShopGroup==null?"":act.ShopGroup.Name,
                   "REMOVED",// act.Category==null?"":act.Category.Id.ToString(),//id_category.ToString(),
                   // act.Theme==null?"":act.Theme.Name,//id_theme.ToString(),
                    act.IsActive.ToString(),
                    act.IsDeleted.ToString(),
                    act.CreateUser.UserName,
                    "<a class=\"button\" href=\"/backend/dashboard/index/"+act.Id+"\">Dashboard</a>"
                });
            }
            var jsonResult = new
            {
                recordsTotal = countRecord,
                recordsFiltered = countRecord,
                data = records
            };
            return Json(jsonResult);
        }

        public ActionResult Info(int id)
        {
            //  var shl = _shopLanguageService.GetByShopId(id);
            var shop = _shopService.GetById(id);
            return View(shop);
        }

        //public async Task<ActionResult> SEO(int id)
        //{
        //    var shl = await _shopLanguageService.GetByShopId(id);
        //    return View(shl);
        //}
        protected void AddSearchKey(string strKey, ref Dictionary<string, string> dict)
        {
            if (Request[strKey] != null)
            {
                if (Request[strKey].Trim() != string.Empty)
                {
                    dict.Add(strKey, Request[strKey]);
                }
            }
        }

        protected Dictionary<string, string> SetProjectCustomerSearchKey()
        {
            var searchKey = new Dictionary<string, string>();
            AddSearchKey("shop_id", ref searchKey);
            AddSearchKey("shop_name", ref searchKey);
            AddSearchKey("shop_category", ref searchKey);
            AddSearchKey("shop_price_from", ref searchKey);
            AddSearchKey("shop_price_to", ref searchKey);
            return searchKey;
        }
    }
}