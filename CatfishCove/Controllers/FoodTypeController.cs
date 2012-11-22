using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatfishCove.Models;

namespace CatfishCove.Controllers
{
    [Authorize]
    public class FoodTypeController : Controller
    {
        CatfishCoveDatabase db = new CatfishCoveDatabase();

        public ActionResult Index()
        {
            return View(db.FoodTypes);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FoodType foodType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.FoodTypes.Add(foodType);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(foodType);
            }

            return View(foodType);
        }
         
        public ActionResult Edit(int id)
        {
            FoodType foodType = db.FoodTypes.Where(ft => ft.Id == id).FirstOrDefault();

            if (foodType == null)
                return RedirectToAction("Index");

            return View(foodType);
        }

        [HttpPost]
        public ActionResult Edit(FoodType foodType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    FoodType oldFoodType = db.FoodTypes.Where(ft => ft.Id == foodType.Id).First();
                    oldFoodType.Name = foodType.Name;
                    oldFoodType.MenuOrder = foodType.MenuOrder;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View(foodType);
            }
            catch
            {
                return View(foodType);
            }
        }
 
        public ActionResult Delete(int id)
        {
            FoodType foodType = db.FoodTypes.Where(ft => ft.Id == id).FirstOrDefault();

            if (foodType == null)
                return RedirectToAction("Index");

            db.FoodTypes.Remove(foodType);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
