using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tenis.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicación para gestionar los torneos de tenis.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Nos puedes localizar en:";

            return View();
        }
    }
}