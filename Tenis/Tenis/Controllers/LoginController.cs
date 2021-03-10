using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tenis.Controllers.InfraLayer.Security;
using Tenis.Models;

namespace Tenis.Controllers
{
    public class LoginController : Controller
    {
        private tenisEntities db = new tenisEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "user1,password")] User usuario)
        {
            if (ModelState.IsValid)
            {

                User authuser = null;

                using (db)
                {
                    string hashedPass = ShaUtils.GenerateSHA256String(usuario.password);
                    try
                    {
                        authuser = db.User.First(u => u.user1 == usuario.user1 && u.password == hashedPass);
                        Debug.WriteLine("authuser=" + authuser.user1 + "," + authuser.password);
                        FormsAuthentication.SetAuthCookie(authuser.user1, false);
                        Session["USUARIO"] = authuser;
                        Session["USER"] = authuser.user1;

                        if (authuser.idTipoUsuario == 1)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    catch
                    {
                        ViewBag.Message = "Usuario o contraseña incorrectos";
                        return View(usuario);
                    }
                }
            }
            else
            {
                return View("AuthError");
            }
        }

        [AdminFilter]
        // GET: Login/Create
        public ActionResult Create()
        {
            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuario, "Id", "Tipo");
            return View();
        }

        // POST: Login/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user1,password,idTipoUsuario")] User user)
        {
            if (ModelState.IsValid)
            {               
                user.password = ShaUtils.GenerateSHA256String(user.password);
                Debug.WriteLine( user.user1 + "," + user.password + "," + user.idTipoUsuario );
                
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoUsuario = new SelectList(db.TipoUsuario, "Id", "Tipo", user.idTipoUsuario);
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}
