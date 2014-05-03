using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatfishCove.Web.Models;

namespace CatfishCove.Web.Controllers
{
    public class BuffetController : Controller
    {
        private readonly CatfishCoveDatabase _dbContext;

        public BuffetController(CatfishCoveDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            ViewBag.StapleCrops = _dbContext.BuffetItems.Include("FoodType").Where(bi => bi.RotationFrequency == 0);

            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var rotatingItems = _dbContext.BuffetRotatingWeeks
                .Include("Meat.BuffetItem")
                .Include("Casserole.BuffetItem")
                .Include("Corn.BuffetItem")
                .Include("Beans.BuffetItem")
                .Where(brw => brw.SundayDate >= today)
                .OrderByDescending(brw => brw.SundayDate)
                .Take(4).ToList();

            if (rotatingItems.Count != 4)
            {
                SetupMissingWeeks();
            }
            rotatingItems.Reverse();
            ViewBag.RotatingItems = rotatingItems;

            return View();
        }

        private void SetupMissingWeeks()
        {
            BuffetRotatingWeek newWeek = new BuffetRotatingWeek();
            //get most recent week
            BuffetRotatingWeek recentMostWeek = _dbContext.BuffetRotatingWeeks
                .Include("Meat.NextItem")
                .Include("Casserole.NextItem")
                .Include("Corn.NextItem")
                .Include("Beans.NextItem").OrderByDescending(brw => brw.SundayDate).First();

            newWeek.SundayDate = recentMostWeek.SundayDate.AddDays(7);
            newWeek.Meat = recentMostWeek.Meat.NextItem;
            newWeek.Casserole = recentMostWeek.Casserole.NextItem;
            newWeek.Corn = recentMostWeek.Corn.NextItem;
            newWeek.Beans = recentMostWeek.Beans.NextItem;

            _dbContext.BuffetRotatingWeeks.Add(newWeek);
            _dbContext.SaveChanges();
        }
	}
}