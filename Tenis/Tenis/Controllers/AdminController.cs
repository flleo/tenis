using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tenis.Controllers
{
  
    [AdminFilter]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Message = "Esta logueado como administrador";
            return View();
        }
    }
}