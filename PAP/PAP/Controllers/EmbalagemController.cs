using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAP.Controllers
{
    public class EmbalagemController : Controller
    {
        // GET: Embalagem
        public ActionResult Index()
        {
            return View();
        }

        // GET: Embalagem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Embalagem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Embalagem/Create
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

        // GET: Embalagem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Embalagem/Edit/5
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

        // GET: Embalagem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Embalagem/Delete/5
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
