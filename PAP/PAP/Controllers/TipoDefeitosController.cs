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
    public class TipoDefeitosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoDefeitos
        public ActionResult Index()
        {
            return View(db.TipoDefeitoes.ToList());
        }

        // GET: TipoDefeitos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDefeito tipoDefeito = db.TipoDefeitoes.Find(id);
            if (tipoDefeito == null)
            {
                return HttpNotFound();
            }
            return View(tipoDefeito);
        }

        // GET: TipoDefeitos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDefeitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoDefeitoID,Nome,Descricao")] TipoDefeito tipoDefeito)
        {
            if (ModelState.IsValid)
            {
                db.TipoDefeitoes.Add(tipoDefeito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDefeito);
        }

        // GET: TipoDefeitos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDefeito tipoDefeito = db.TipoDefeitoes.Find(id);
            if (tipoDefeito == null)
            {
                return HttpNotFound();
            }
            return View(tipoDefeito);
        }

        // POST: TipoDefeitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoDefeitoID,Nome,Descricao")] TipoDefeito tipoDefeito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDefeito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDefeito);
        }

        // GET: TipoDefeitos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDefeito tipoDefeito = db.TipoDefeitoes.Find(id);
            if (tipoDefeito == null)
            {
                return HttpNotFound();
            }
            return View(tipoDefeito);
        }

        // POST: TipoDefeitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDefeito tipoDefeito = db.TipoDefeitoes.Find(id);
            db.TipoDefeitoes.Remove(tipoDefeito);
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
