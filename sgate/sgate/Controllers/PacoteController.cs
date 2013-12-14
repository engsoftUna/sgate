using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sgate.Models;

namespace sgate.Controllers
{
    public class PacoteController : Controller
    {
        private sgateEntities db = new sgateEntities();

        //
        // GET: /Pacote/

        public ActionResult Index()
        {
            return View(db.pacote.ToList());
        }

        //
        // GET: /Pacote/Details/5

        public ActionResult Details(int id = 0)
        {
            pacote pacote = db.pacote.Find(id);
            if (pacote == null)
            {
                return HttpNotFound();
            }
            return View(pacote);
        }

        //
        // GET: /Pacote/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pacote/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(pacote pacote)
        {
            if (ModelState.IsValid)
            {
                db.pacote.Add(pacote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pacote);
        }

        //
        // GET: /Pacote/Edit/5

        public ActionResult Edit(int id = 0)
        {
            pacote pacote = db.pacote.Find(id);
            if (pacote == null)
            {
                return HttpNotFound();
            }
            return View(pacote);
        }

        //
        // POST: /Pacote/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(pacote pacote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacote);
        }

        //
        // GET: /Pacote/Delete/5

        public ActionResult Delete(int id = 0)
        {
            pacote pacote = db.pacote.Find(id);
            if (pacote == null)
            {
                return HttpNotFound();
            }
            return View(pacote);
        }

        //
        // POST: /Pacote/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pacote pacote = db.pacote.Find(id);
            db.pacote.Remove(pacote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}