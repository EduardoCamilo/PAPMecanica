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
    public class TipoDefeitoController : Controller
    {
        //Deve ser utilizado o Contexto em todas as classes controller
        private Contexto db = new Contexto();

        // GET: TipoDefeito
        public ActionResult Index()
        {
            var defeitos = db.TipoDefeitoes.ToList();
            return View(defeitos);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoDefeito defeito)
        {
            if (ModelState.IsValid)
            {
                db.TipoDefeitoes.Add(defeito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defeito);
        }

        public ActionResult Details(int? id)
        {
            //Não passou o id?
            if (id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            TipoDefeito defeito = db.TipoDefeitoes.Find(id);

            //não encontrou o objeto com este id
            if (defeito == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(defeito);
        }

        public ActionResult Edit(int? id)
        {
            //Não passou o id?
            if (id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            TipoDefeito defeito = db.TipoDefeitoes.Find(id);

            //não encontrou o objeto com este id
            if (defeito == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(defeito);
        }

        [HttpPost]
        public ActionResult Edit(TipoDefeito defeito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defeito).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defeito);
        }

        public ActionResult Delete(int? id)
        {
            //Não passou o id?
            if (id == null /*id.HasValue*/)
            {
                //HTTP 400
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            TipoDefeito defeito = db.TipoDefeitoes.Find(id);

            //não encontrou o objeto com este id
            if (defeito == null)
            {
                //HTTP 404
                return HttpNotFound();
            }

            return View(defeito);
        }


        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDefeito defeito = db.TipoDefeitoes.Find(id);

            db.TipoDefeitoes.Remove(defeito);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
