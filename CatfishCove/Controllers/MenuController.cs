using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatfishCove.Models;
using System.Web.UI;

namespace CatfishCove.Controllers
{
    public class MenuController : Controller
    {
        CatfishCoveDatabase db = new CatfishCoveDatabase();

        [OutputCache(Duration=10, Location=OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            List<IGrouping<FoodType, MenuItem>> menuItems = db.MenuItems
                .GroupBy(mi => mi.FoodType).ToList();

            menuItems = menuItems.OrderBy(group => group.Key.MenuOrder).ToList();

            return View(menuItems);
        }

        public ActionResult Delete(int id)
        {
            MenuItem menuItem = db.MenuItems.Where(mi => mi.Id == id).FirstOrDefault();

            if (menuItem == null)
                return RedirectToAction("Index");

            db.MenuItems.Remove(menuItem);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            MenuItem menuItem = db.MenuItems.Where(mi => mi.Id == id).FirstOrDefault();

            if (menuItem == null)
                return RedirectToAction("Create");

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(menuItem);
        }

        [HttpPost]
        public ActionResult Edit(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                MenuItem oldItem = db.MenuItems.Where(mi => mi.Id == menuItem.Id).First();
                oldItem.Name = menuItem.Name;
                oldItem.Description = menuItem.Description;
                oldItem.HalfOrderPrice = menuItem.HalfOrderPrice;
                oldItem.WholeOrderPrice = menuItem.WholeOrderPrice;
                
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
            return View(menuItem);
        }

        public ActionResult Create()
        {
            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuItem menuItem)
        {
            if (ModelState.IsValid)
            {
                int foodTypeId = 0;
                if (int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
                {
                    FoodType type = db.FoodTypes.Where(ft => ft.Id == foodTypeId).First();
                    menuItem.FoodType = type;
                    db.MenuItems.Add(menuItem);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(db.FoodTypes.ToList(), "Id", "Name");
            return View(menuItem);
        }
    }
}
