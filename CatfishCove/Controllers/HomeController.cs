using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CatfishCove.Controllers
{
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 120)]
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Catering()
        {
            return View();
        }

        public ActionResult Directions()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
