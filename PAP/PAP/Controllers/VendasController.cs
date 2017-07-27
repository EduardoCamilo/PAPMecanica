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
    public class VendasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vendas
        public ActionResult Index()
        {
            var vendas = db.Vendas.Include(v => v._Cliente).Include(v => v._CondicaoPagamento).Include(v => v._Funcionario);
            return View(vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            ViewBag.CondicaoPagamentoID = new SelectList(db.CondicaoPagamentoes, "CondicaoPagamentoID", "NomeCondicaoPagamento");
            ViewBag.VendedorID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario");
            ViewBag.ItemVendaID = new SelectList(db.ItemVendas, "ItemVendaID", "ItemVendaID");
            return View();
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendaID,DataDaVenda,ClienteID,VendedorID,CondicaoPagamentoID,ItemVendaID")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", venda.ClienteID);
            ViewBag.CondicaoPagamentoID = new SelectList(db.CondicaoPagamentoes, "CondicaoPagamentoID", "NomeCondicaoPagamento", venda.CondicaoPagamentoID);
            ViewBag.VendedorID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", venda.VendedorID);
            
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", venda.ClienteID);
            ViewBag.CondicaoPagamentoID = new SelectList(db.CondicaoPagamentoes, "CondicaoPagamentoID", "NomeCondicaoPagamento", venda.CondicaoPagamentoID);
            ViewBag.VendedorID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", venda.VendedorID);
            
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaID,DataDaVenda,ClienteID,VendedorID,CondicaoPagamentoID,ItemVendaID")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", venda.ClienteID);
            ViewBag.CondicaoPagamentoID = new SelectList(db.CondicaoPagamentoes, "CondicaoPagamentoID", "NomeCondicaoPagamento", venda.CondicaoPagamentoID);
            ViewBag.VendedorID = new SelectList(db.Funcionarios, "FuncionarioID", "NomeFuncionario", venda.VendedorID);
           
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
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
