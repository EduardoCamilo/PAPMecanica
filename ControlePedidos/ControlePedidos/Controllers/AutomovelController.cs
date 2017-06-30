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
    public class AutomovelController : Controller
    {
        //Deve ser utilizado o Contexto em todas as classes controller
        private Contexto db = new Contexto();

        // GET: Automovel
        public ActionResult Index()
        {
            var automoveis = db.Automovels.ToList();
            return View(automoveis);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                db.Automovels.Add(automovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automovel);
        }

        public ActionResult Details(int? id)
        {
            //Não passou o id?
            if(id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Automovel automovel = db.Automovels.Find(id);

            //não encontrou o objeto com este id
            if(automovel == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(automovel);
        }

        public ActionResult Edit(int? id)
        {
            //Não passou o id?
            if (id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Automovel automovel = db.Automovels.Find(id);

            //não encontrou o objeto com este id
            if (automovel == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(automovel);
        }

        [HttpPost]
        public ActionResult Edit(Automovel automovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(automovel);
        }

        public ActionResult Delete(int? id)
        {
            //Não passou o id?
            if (id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            Automovel automovel = db.Automovels.Find(id);

            //não encontrou o objeto com este id
            if (automovel == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(automovel);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Automovel automovel = db.Automovels.Find(id);

            db.Automovels.Remove(automovel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}