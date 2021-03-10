using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tenis.Models;


namespace Tenis.Controllers
{
    [AuthorizedFilter]
    public class TorneosController : Controller
    {
        private tenisEntities db = new tenisEntities();

        // GET: Torneos
        public ActionResult Index(int? id)
        {
            List<Torneo> torneos = db.Torneo.Include(t => t.Estadio).Include(t => t.Pais).Include(t => t.Superficie).Include(t => t.TipoTorneo).ToList();

            if (id!=null)
            {
                torneos = torneos.FindAll(delegate (Torneo torneo)
                {
                    return torneo.IdSuperficie.Equals(id);
                });
            }
          
            return View(torneos);
        }

        // GET: Torneos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        [AdminFilter]
        // GET: Torneos/Create
        public ActionResult Create()
        {
            ViewBag.IdEstadio = new SelectList(db.Estadio, "IdEstadio", "Estadio1");
            ViewBag.IdPais = new SelectList(db.Pais, "Id", "Pais1");
            ViewBag.IdSuperficie = new SelectList(db.Superficie, "Id", "Superficie1");
            ViewBag.IdTipo = new SelectList(db.TipoTorneo, "IdTipo", "TipoTorneo1");
            return View();
        }

        // POST: Torneos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Torneo1,IdPais,IdTipo,IdSuperficie,IdEstadio")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Torneo.Add(torneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstadio = new SelectList(db.Estadio, "IdEstadio", "Estadio1", torneo.IdEstadio);
            ViewBag.IdPais = new SelectList(db.Pais, "Id", "Pais1", torneo.IdPais);
            ViewBag.IdSuperficie = new SelectList(db.Superficie, "Id", "Superficie1", torneo.IdSuperficie);
            ViewBag.IdTipo = new SelectList(db.TipoTorneo, "IdTipo", "TipoTorneo1", torneo.IdTipo);
            return View(torneo);
        }

        // GET: Torneos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstadio = new SelectList(db.Estadio, "IdEstadio", "Estadio1", torneo.IdEstadio);
            ViewBag.IdPais = new SelectList(db.Pais, "Id", "Pais1", torneo.IdPais);
            ViewBag.IdSuperficie = new SelectList(db.Superficie, "Id", "Superficie1", torneo.IdSuperficie);
            ViewBag.IdTipo = new SelectList(db.TipoTorneo, "IdTipo", "TipoTorneo1", torneo.IdTipo);
            return View(torneo);
        }

        // POST: Torneos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTorneo,Torneo1,IdPais,IdTipo,IdSuperficie,IdEstadio")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstadio = new SelectList(db.Estadio, "IdEstadio", "Estadio1", torneo.IdEstadio);
            ViewBag.IdPais = new SelectList(db.Pais, "Id", "Pais1", torneo.IdPais);
            ViewBag.IdSuperficie = new SelectList(db.Superficie, "Id", "Superficie1", torneo.IdSuperficie);
            ViewBag.IdTipo = new SelectList(db.TipoTorneo, "IdTipo", "TipoTorneo1", torneo.IdTipo);
            return View(torneo);
        }

        // GET: Torneos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        // POST: Torneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Torneo torneo = db.Torneo.Find(id);
            db.Torneo.Remove(torneo);
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
