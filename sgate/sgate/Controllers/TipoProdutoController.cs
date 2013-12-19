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
    public class TipoProdutoController : Controller
    {
        private sgateEntities db = new sgateEntities();

        //
        // GET: /TipoProduto/

        public ActionResult Index()
        {
            return View(db.tipoproduto.ToList());
        }

        //
        // GET: /TipoProduto/Details/5

        public ActionResult Details(int id = 0)
        {
            tipoproduto tipoproduto = db.tipoproduto.Find(id);
            if (tipoproduto == null)
            {
                return HttpNotFound();
            }
            return View(tipoproduto);
        }

        //
        // GET: /TipoProduto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoProduto/Create

        [HttpPost]
        public ActionResult Create(tipoproduto tipoproduto)
        {
            if (ModelState.IsValid)
            {
                db.tipoproduto.Add(tipoproduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoproduto);
        }

        //
        // GET: /TipoProduto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            tipoproduto tipoproduto = db.tipoproduto.Find(id);
            if (tipoproduto == null)
            {
                return HttpNotFound();
            }
            return View(tipoproduto);
        }

        //
        // POST: /TipoProduto/Edit/5

        [HttpPost]
        public ActionResult Edit(tipoproduto tipoproduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoproduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoproduto);
        }

        //
        // GET: /TipoProduto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            tipoproduto tipoproduto = db.tipoproduto.Find(id);
            if (tipoproduto == null)
            {
                return HttpNotFound();
            }
            return View(tipoproduto);
        }

        //
        // POST: /TipoProduto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoproduto tipoproduto = db.tipoproduto.Find(id);
            db.tipoproduto.Remove(tipoproduto);
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