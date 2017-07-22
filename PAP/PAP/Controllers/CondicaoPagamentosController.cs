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
    public class CondicaoPagamentosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CondicaoPagamentos
        public ActionResult Index()
        {
            return View(db.CondicaoPagamentoes.ToList());
        }

        // GET: CondicaoPagamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicaoPagamento condicaoPagamento = db.CondicaoPagamentoes.Find(id);
            if (condicaoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(condicaoPagamento);
        }

        // GET: CondicaoPagamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondicaoPagamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CondicaoPagamentoID,NomeCondicaoPagamento,CodigoCondicaoPagamento,DescricaoCondicaoPagamento,DescontoCondicaoPagamento,AcrescimoCondicaoPagamento")] CondicaoPagamento condicaoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.CondicaoPagamentoes.Add(condicaoPagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicaoPagamento);
        }

        // GET: CondicaoPagamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicaoPagamento condicaoPagamento = db.CondicaoPagamentoes.Find(id);
            if (condicaoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(condicaoPagamento);
        }

        // POST: CondicaoPagamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CondicaoPagamentoID,NomeCondicaoPagamento,CodigoCondicaoPagamento,DescricaoCondicaoPagamento,DescontoCondicaoPagamento,AcrescimoCondicaoPagamento")] CondicaoPagamento condicaoPagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicaoPagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicaoPagamento);
        }

        // GET: CondicaoPagamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CondicaoPagamento condicaoPagamento = db.CondicaoPagamentoes.Find(id);
            if (condicaoPagamento == null)
            {
                return HttpNotFound();
            }
            return View(condicaoPagamento);
        }

        // POST: CondicaoPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CondicaoPagamento condicaoPagamento = db.CondicaoPagamentoes.Find(id);
            db.CondicaoPagamentoes.Remove(condicaoPagamento);
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
