﻿using System;
using System.Linq;
using System.Web.Helpers;
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

        public ActionResult Thanksgiving()
        {
            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult Create(BuffetItem buffetItem)
        {
            if (ModelState.IsValid)
            {
                int foodTypeId;
                if (int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
                {
                    FoodType type = _dbContext.FoodTypes.First(ft => ft.Id == foodTypeId);
                    buffetItem.FoodType = type;
                    _dbContext.BuffetItems.Add(buffetItem);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View(buffetItem);
        }

        [Authorize]
        public ActionResult CreateRotating()
        {
            ViewBag.MeatItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Buffet Meat"), "Id", "BuffetItem.Name");
            ViewBag.CasseroleItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Casserole"), "Id", "BuffetItem");
            ViewBag.CornItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Corn"), "Id", "BuffetItem");
            ViewBag.BeanItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Beans"), "Id", "BuffetItem");

            return View();
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult CreateRotating(BuffetRotatingWeek week)
        {
            if (ModelState.IsValid)
            {
                int meatId;
                int cornId;
                int casseroleId;
                int beansId;

                if (int.TryParse(Request.Form["Meat.Id"], out meatId) &&
                    int.TryParse(Request.Form["Corn.Id"], out cornId) &&
                    int.TryParse(Request.Form["Casserole.Id"], out casseroleId) &&
                    int.TryParse(Request.Form["Beans.Id"], out beansId))
                {
                    week.Meat = _dbContext.BuffetSchedules.First(bi => bi.Id == meatId);
                    week.Corn = _dbContext.BuffetSchedules.First(bi => bi.Id == cornId);
                    week.Casserole = _dbContext.BuffetSchedules.First(bi => bi.Id == casseroleId);
                    week.Beans = _dbContext.BuffetSchedules.First(bi => bi.Id == beansId);

                    _dbContext.BuffetRotatingWeeks.Add(week);
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View(week);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            BuffetItem buffetItem = _dbContext.BuffetItems.FirstOrDefault(bi => bi.Id == id);

            if (buffetItem == null)
                return RedirectToAction("Create");

            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View(buffetItem);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult Edit(BuffetItem buffetItem)
        {
            if (ModelState.IsValid)
            {
                BuffetItem oldItem = _dbContext.BuffetItems.First(mi => mi.Id == buffetItem.Id);
                oldItem.Name = buffetItem.Name;
                oldItem.Description = buffetItem.Description;
                oldItem.RotationFrequency = buffetItem.RotationFrequency;

                int foodTypeId;
                if (int.TryParse(Request.Form["FoodType.Id"], out foodTypeId))
                {
                    FoodType type = _dbContext.FoodTypes.First(ft => ft.Id == foodTypeId);
                    oldItem.FoodType = type;
                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View(buffetItem);
        }

        [Authorize]
        public ActionResult EditRotating(int id)
        {
            BuffetRotatingWeek week = _dbContext.BuffetRotatingWeeks.First(bi => bi.Id == id);

            ViewBag.MeatItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Buffet Meat"), "Id", "BuffetItem.Name");
            ViewBag.CasseroleItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Casserole"), "Id", "BuffetItem");
            ViewBag.CornItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Corn"), "Id", "BuffetItem");
            ViewBag.BeanItems = new SelectList(_dbContext.BuffetSchedules.Include("BuffetItem").Where(bi => bi.FoodType.Name == "Beans"), "Id", "BuffetItem");

            return View(week);
        }

        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public ActionResult EditRotating(BuffetRotatingWeek week)
        {
            if (ModelState.IsValid)
            {
                BuffetRotatingWeek oldWeek = _dbContext.BuffetRotatingWeeks.First(bi => bi.Id == week.Id);

                int meatId;
                int cornId;
                int casseroleId;
                int beansId;

                if (int.TryParse(Request.Form["Meat.Id"], out meatId) &&
                    int.TryParse(Request.Form["Corn.Id"], out cornId) &&
                    int.TryParse(Request.Form["Casserole.Id"], out casseroleId) &&
                    int.TryParse(Request.Form["Beans.Id"], out beansId))
                {
                    oldWeek.Meat = _dbContext.BuffetSchedules.First(bi => bi.Id == meatId);
                    oldWeek.Corn = _dbContext.BuffetSchedules.First(bi => bi.Id == cornId);
                    oldWeek.Casserole = _dbContext.BuffetSchedules.First(bi => bi.Id == casseroleId);
                    oldWeek.Beans = _dbContext.BuffetSchedules.First(bi => bi.Id == beansId);
                    oldWeek.SundayDate = week.SundayDate;

                    _dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            ViewBag.FoodTypes = new SelectList(_dbContext.FoodTypes.ToList(), "Id", "Name");
            return View(week);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            BuffetItem buffetItem = _dbContext.BuffetItems.FirstOrDefault(bi => bi.Id == id);

            if (buffetItem == null)
                return RedirectToAction("Index");

            _dbContext.BuffetItems.Remove(buffetItem);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DeleteRotating(int id)
        {
            BuffetRotatingWeek week = _dbContext.BuffetRotatingWeeks.FirstOrDefault(bi => bi.Id == id);

            if (week == null)
                return RedirectToAction("Index");

            _dbContext.BuffetRotatingWeeks.Remove(week);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}