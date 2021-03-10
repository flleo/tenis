using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Tenis.Models;

namespace Tenis.Controllers
{
    public class SuperficiesController : Controller
    {
        private tenisEntities db = new tenisEntities();

        // GET: Superficies
        public ActionResult Index()
        {
            return View(db.Superficie.ToList());
        }

        
   

        // GET: Superficies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superficie superficie = db.Superficie.Find(id);
            if (superficie == null)
            {
                return HttpNotFound();
            }
            return View(superficie);
        }

        public void torneos(int?id)
        {
            Response.Redirect(Url.RouteUrl(new { controller = "Torneos", action = "Index",  id = id  }));
        }



        // GET: Superficies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superficies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Superficie1")] Superficie superficie)
        {
            if (ModelState.IsValid)
            {
                List<Superficie> ss = db.Superficie.ToList();
                int id = ss.Last().Id + 1;
                superficie.Id = id;
                db.Superficie.Add(superficie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(superficie);
        }

        // GET: Superficies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superficie superficie = db.Superficie.Find(id);
            if (superficie == null)
            {
                return HttpNotFound();
            }
            return View(superficie);
        }

        // POST: Superficies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Superficie1")] Superficie superficie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superficie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superficie);
        }

        // GET: Superficies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superficie superficie = db.Superficie.Find(id);
            if (superficie == null)
            {
                return HttpNotFound();
            }
            return View(superficie);
        }

        // POST: Superficies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Superficie superficie = db.Superficie.Find(id);
            db.Superficie.Remove(superficie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
