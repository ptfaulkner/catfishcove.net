using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatfishCove.Models;
using System.Web.UI;

namespace CatfishCove.Controllers
{
    public class BuffetController : Controller
    {
        CatfishCoveDatabase db = new CatfishCoveDatabase();

        [OutputCache(Duration=10, Location=OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            ViewBag.StapleCrops = db.BuffetItems.Include("FoodType").Where(bi => bi.RotationFrequency == 0);
            
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var rotatingItems = db.BuffetRotatingWeeks
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

        public ActionResult Thanksgiving()
        {
            return View();
        }

        private void SetupMissingWeeks()
        {
            BuffetRotatingWeek newWeek = new BuffetRotatingWeek();
            //get most recent week
            BuffetRotatingWeek recentMostWeek = db.BuffetRotatingWeeks
                .Include("Meat.NextItem")
                .Include("Casserole.NextItem")
                .Include("Corn.NextItem")
                .Include("Beans.NextItem").OrderByDescending(brw => brw.SundayDate).First();

            newWeek.SundayDate = recentMostWeek.SundayDate.AddDays(7);
            newWeek.Meat = recentMostWeek.Meat.NextItem;
            newWeek.Casserole = recentMostWeek.Casserole.NextItem;
            newWeek.Corn = recentMostWeek.Corn.NextItem;
            newWeek.Beans = recentMostWeek.Beans.NextItem;

            db.BuffetRotatingWeeks.Add(newWeek);
            db.SaveChanges();
        }
        
        public ActionResult Create()
        {
            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(BuffetItem buffetItem)
        {
            if (ModelState.IsValid)
            {
                int foodTypeId = 0;
                if (int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
                {
                    FoodType type = db.FoodTypes.Where(ft => ft.Id == foodTypeId).First();
                    buffetItem.FoodType = type;
                    db.BuffetItems.Add(buffetItem);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(buffetItem);
        }

        public ActionResult CreateRotating()
        {
            ViewBag.MeatItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Buffet Meat"), "Id", "BuffetItem.Name");
            ViewBag.CasseroleItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Casserole"), "Id", "BuffetItem");
            ViewBag.CornItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Corn"), "Id", "BuffetItem");
            ViewBag.BeanItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Beans"), "Id", "BuffetItem");
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateRotating(BuffetRotatingWeek week)
        {
            if (ModelState.IsValid)
            {
                int MeatId = 0;
                int CornId = 0;
                int CasseroleId = 0;
                int BeansId = 0;

                if (int.TryParse(Request.Form["Meat.Id"], out MeatId) &&
                    int.TryParse(Request.Form["Corn.Id"], out CornId) &&
                    int.TryParse(Request.Form["Casserole.Id"], out CasseroleId) &&
                    int.TryParse(Request.Form["Beans.Id"], out BeansId))
                {
                    week.Meat = db.BuffetSchedules.Where(bi => bi.Id == MeatId).First();
                    week.Corn = db.BuffetSchedules.Where(bi => bi.Id == CornId).First();
                    week.Casserole = db.BuffetSchedules.Where(bi => bi.Id == CasseroleId).First();
                    week.Beans = db.BuffetSchedules.Where(bi => bi.Id == BeansId).First();

                    db.BuffetRotatingWeeks.Add(week);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(week);
        }
 
        public ActionResult Edit(int id)
        {
            BuffetItem buffetItem = db.BuffetItems.Where(bi => bi.Id == id).FirstOrDefault();

            if (buffetItem == null)
                return RedirectToAction("Create");

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(buffetItem);
        }

        [HttpPost]
        public ActionResult Edit(BuffetItem buffetItem)
        {
            if (ModelState.IsValid)
            {
                BuffetItem oldItem = db.BuffetItems.Where(mi => mi.Id == buffetItem.Id).First();
                oldItem.Name = buffetItem.Name;
                oldItem.Description = buffetItem.Description;
                oldItem.RotationFrequency = buffetItem.RotationFrequency;

                int foodTypeId = 0;
                if (int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
                {
                    FoodType type = db.FoodTypes.Where(ft => ft.Id == foodTypeId).First();
                    oldItem.FoodType = type;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(buffetItem);
        }

        public ActionResult EditRotating(int id)
        {
            BuffetRotatingWeek week = db.BuffetRotatingWeeks.Where(bi => bi.Id == id).First();

            ViewBag.MeatItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Buffet Meat"), "Id", "BuffetItem.Name");
            ViewBag.CasseroleItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Casserole"), "Id", "BuffetItem");
            ViewBag.CornItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Corn"), "Id", "BuffetItem");
            ViewBag.BeanItems = new SelectList(db.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Beans"), "Id", "BuffetItem");
            
            return View(week);
        }

        [HttpPost]
        public ActionResult EditRotating(BuffetRotatingWeek week)
        {
            if (ModelState.IsValid)
            {
                BuffetRotatingWeek oldWeek = db.BuffetRotatingWeeks.Where(bi => bi.Id == week.Id).First();

                int MeatId = 0;
                int CornId = 0;
                int CasseroleId = 0;
                int BeansId = 0;

                if (int.TryParse(Request.Form["Meat.Id"], out MeatId) &&
                    int.TryParse(Request.Form["Corn.Id"], out CornId) &&
                    int.TryParse(Request.Form["Casserole.Id"], out CasseroleId) &&
                    int.TryParse(Request.Form["Beans.Id"], out BeansId))
                {
                    oldWeek.Meat = db.BuffetSchedules.Where(bi => bi.Id == MeatId).First();
                    oldWeek.Corn = db.BuffetSchedules.Where(bi => bi.Id == CornId).First();
                    oldWeek.Casserole = db.BuffetSchedules.Where(bi => bi.Id == CasseroleId).First();
                    oldWeek.Beans = db.BuffetSchedules.Where(bi => bi.Id == BeansId).First();
                    oldWeek.SundayDate = week.SundayDate;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(week);
        }

        public ActionResult Delete(int id)
        {
            BuffetItem buffetItem = db.BuffetItems.Where(bi => bi.Id == id).FirstOrDefault();

            if (buffetItem == null)
                return RedirectToAction("Index");

            db.BuffetItems.Remove(buffetItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteRotating(int id)
        {
            BuffetRotatingWeek week = db.BuffetRotatingWeeks.Where(bi => bi.Id == id).FirstOrDefault();

            if (week == null)
                return RedirectToAction("Index");

            db.BuffetRotatingWeeks.Remove(week);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
