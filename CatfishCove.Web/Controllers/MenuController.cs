using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatfishCove.Web.Data;
using CatfishCove.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatfishCove.Web.Controllers
{
    public class MenuController : Controller
    {
        private readonly CatfishCoveDbContext _dbContext;

        public MenuController(CatfishCoveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<IGrouping<FoodType, MenuItem>> menuItems = _dbContext.MenuItems
                .GroupBy(mi => mi.FoodType).ToList();

            menuItems = menuItems.OrderBy(group => group.Key.MenuOrder).ToList();

            return View(menuItems);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            MenuItem menuItem = _dbContext.MenuItems.FirstOrDefault(mi => mi.Id == id);

            if (menuItem == null)
                return RedirectToAction("Index");

            _dbContext.MenuItems.Remove(menuItem);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            MenuItem menuItem = _dbContext.MenuItems.FirstOrDefault(mi => mi.Id == id);

            if (menuItem == null)
                return RedirectToAction("Create");

            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View(menuItem);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult Edit(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
                return View(menuItem);
            }

            MenuItem oldItem = _dbContext.MenuItems.FirstOrDefault(mi => mi.Id == menuItem.Id);

            if (oldItem == null)
            {
                ModelState.AddModelError("Summary", "The menu item for the given id was not found.");
                return View(menuItem);
            }

            int foodTypeId = 0;
            if (!int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
            {
                ModelState.AddModelError("Summary", "The food type for the submitted menu item for the given id was not found.");
                return View(menuItem);
            }

            FoodType type = _dbContext.FoodTypes.First(ft => ft.Id == foodTypeId);
            oldItem.FoodType = type;
            oldItem.Name = menuItem.Name;
            oldItem.Description = menuItem.Description;
            oldItem.HalfOrderPrice = menuItem.HalfOrderPrice;
            oldItem.WholeOrderPrice = menuItem.WholeOrderPrice;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult Create(MenuItem menuItem)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
                return View(menuItem);
            }

            int foodTypeId = 0;
            if (!int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
            {
                ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
                return View(menuItem);
            }

            FoodType type = _dbContext.FoodTypes.First(ft => ft.Id == foodTypeId);
            menuItem.FoodType = type;
            _dbContext.MenuItems.Add(menuItem);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}