using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaseModels;
using PAP.Models;

namespace PAP.Controllers
{
    public class AutomovelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Automovels
        public ActionResult Index()
        {
            var automovels = db.Automovels.Include(a => a._Cliente);
            return View(automovels.ToList());
        }

        // GET: Automovels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovel automovel = db.Automovels.Find(id);
            if (automovel == null)
            {
                return HttpNotFound();
            }
            return View(automovel);
        }

        // GET: Automovels/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            return View();
        }

        // POST: Automovels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutomovelID,Modelo,Placa,Cor,Ano,Observacao,ClienteID")] Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                db.Automovels.Add(automovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", automovel.ClienteID);
            return View(automovel);
        }

        // GET: Automovels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovel automovel = db.Automovels.Find(id);
            if (automovel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", automovel.ClienteID);
            return View(automovel);
        }

        // POST: Automovels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutomovelID,Modelo,Placa,Cor,Ano,Observacao,ClienteID")] Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", automovel.ClienteID);
            return View(automovel);
        }

        // GET: Automovels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Automovel automovel = db.Automovels.Find(id);
            if (automovel == null)
            {
                return HttpNotFound();
            }
            return View(automovel);
        }

        // POST: Automovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovel automovel = db.Automovels.Find(id);
            db.Automovels.Remove(automovel);
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
