using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CatfishCove.Web.Models;

namespace CatfishCove.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly CatfishCoveDatabase _dbContext;

        public MenuController(CatfishCoveDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        [OutputCache(Duration = 10, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            List<IGrouping<FoodType, MenuItem>> menuItems = _dbContext.MenuItems
                .GroupBy(mi => mi.FoodType).ToList();

            menuItems = menuItems.OrderBy(group => group.Key.MenuOrder).ToList();

            return View(menuItems);
        }
	}
}