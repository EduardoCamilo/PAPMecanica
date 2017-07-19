using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAP.Controllers
{
    public class TipoDefeitoController : Controller
    {
        // GET: TipoDefeito
        public ActionResult Index()
        {
            return View();
        }

        // GET: TipoDefeito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDefeito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDefeito/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDefeito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoDefeito/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDefeito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDefeito/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
