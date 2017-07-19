using Microsoft.AspNet.Identity.EntityFramework;
using PAP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PAP.Controllers
{
    public class AutomovelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Automovel
        public ActionResult Index()
        {
            var automoveis = db.Automovels.ToList();
            return View(automoveis);
        }

        // GET: Automovel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Automovel/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            return View();
        }

        // POST: Automovel/Create
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

        // GET: Automovel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Automovel/Edit/5
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

        // GET: Automovel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Automovel/Delete/5
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
