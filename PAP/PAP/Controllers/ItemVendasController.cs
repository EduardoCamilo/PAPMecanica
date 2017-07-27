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
    public class ItemVendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemVendas
        public ActionResult Index()
        {
            var itemVendas = db.ItemVendas.Include(i => i._Categoria).Include(i => i._Embalagem);
            return View(itemVendas.ToList());
        }

        // GET: ItemVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItemVendas.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // GET: ItemVendas/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "DescricaoCategoria");
            ViewBag.EmbalagemID = new SelectList(db.Embalagems, "EmbalagemID", "DescricaoEmbalagem");
            return View();
        }

        // POST: ItemVendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemVendaID,QuantidadeItemVenda,QuantidadeEstoqueAtual,PrecoUnitario,VendaAtualID,ProdutoID,EmbalagemID,CategoriaID")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.ItemVendas.Add(itemVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "DescricaoCategoria", itemVenda.CategoriaID);
            ViewBag.EmbalagemID = new SelectList(db.Embalagems, "EmbalagemID", "DescricaoEmbalagem", itemVenda.EmbalagemID);
            return View(itemVenda);
        }

        // GET: ItemVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItemVendas.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "DescricaoCategoria", itemVenda.CategoriaID);
            ViewBag.EmbalagemID = new SelectList(db.Embalagems, "EmbalagemID", "DescricaoEmbalagem", itemVenda.EmbalagemID);
            return View(itemVenda);
        }

        // POST: ItemVendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemVendaID,QuantidadeItemVenda,QuantidadeEstoqueAtual,PrecoUnitario,VendaAtualID,ProdutoID,EmbalagemID,CategoriaID")] ItemVenda itemVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "DescricaoCategoria", itemVenda.CategoriaID);
            ViewBag.EmbalagemID = new SelectList(db.Embalagems, "EmbalagemID", "DescricaoEmbalagem", itemVenda.EmbalagemID);
            return View(itemVenda);
        }

        // GET: ItemVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemVenda itemVenda = db.ItemVendas.Find(id);
            if (itemVenda == null)
            {
                return HttpNotFound();
            }
            return View(itemVenda);
        }

        // POST: ItemVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemVenda itemVenda = db.ItemVendas.Find(id);
            db.ItemVendas.Remove(itemVenda);
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
