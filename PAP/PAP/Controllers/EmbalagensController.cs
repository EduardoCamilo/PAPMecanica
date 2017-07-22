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
    public class EmbalagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Embalagens
        public ActionResult Index()
        {
            return View(db.Embalagems.ToList());
        }

        // GET: Embalagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embalagem embalagem = db.Embalagems.Find(id);
            if (embalagem == null)
            {
                return HttpNotFound();
            }
            return View(embalagem);
        }

        // GET: Embalagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Embalagens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmbalagemID,DescricaoEmbalagem,CodigoEmbalagem,QuantidadeProdutoEmbalagem,TipoEmbalagem")] Embalagem embalagem)
        {
            if (ModelState.IsValid)
            {
                db.Embalagems.Add(embalagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(embalagem);
        }

        // GET: Embalagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embalagem embalagem = db.Embalagems.Find(id);
            if (embalagem == null)
            {
                return HttpNotFound();
            }
            return View(embalagem);
        }

        // POST: Embalagens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmbalagemID,DescricaoEmbalagem,CodigoEmbalagem,QuantidadeProdutoEmbalagem,TipoEmbalagem")] Embalagem embalagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(embalagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(embalagem);
        }

        // GET: Embalagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Embalagem embalagem = db.Embalagems.Find(id);
            if (embalagem == null)
            {
                return HttpNotFound();
            }
            return View(embalagem);
        }

        // POST: Embalagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Embalagem embalagem = db.Embalagems.Find(id);
            db.Embalagems.Remove(embalagem);
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
