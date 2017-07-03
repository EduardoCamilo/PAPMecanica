using BaseModels;
using ControlePedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ControlePedidos.Controllers
{
    public class ClienteController : Controller
    {
        //Deve ser utilizado o Contexto em todas as classes controller
        private Contexto db = new Contexto();

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = db.Clientes.ToList();
            return View(clientes);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Details(int? id)
        {
            //Não passou o id?
            if(id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            //Não econtrou o objeto com este id
            if(cliente == null)
            {
                //HTTP 404
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Edit(int? id)
        {
            //Não passou o id?
            if(id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            //Não encontrou o objeto com este id
            if(cliente == null)
            {
                //HTTP 404
                return HttpNotFound();
            }
            return View(cliente);
        }


        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Delete(int? id)
        {
            //Não passou a id?
            if(id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            //não encontrou o objeto com este id
            if (cliente == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}