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
    public class ProdutoController : Controller
    {
        private sgateEntities db = new sgateEntities();

        //
        // GET: /Produto/

        public ActionResult Index()
        {
            var produto = db.produto.Include(p => p.pacote).Include(p => p.tipoproduto);
            return View(produto.ToList());
        }

        //
        // GET: /Produto/Details/5

        public ActionResult Details(int id = 0)
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // GET: /Produto/Create

        public ActionResult Create()
        {
            ViewBag.idpacote = new SelectList(db.pacote, "idpacote", "pacote1");
            ViewBag.idtipo = new SelectList(db.tipoproduto, "idtipo", "tipo");
            return View();
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(produto produto)
        {
            if (ModelState.IsValid)
            {
                db.produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idpacote = new SelectList(db.pacote, "idpacote", "pacote1", produto.idpacote);
            ViewBag.idtipo = new SelectList(db.tipoproduto, "idtipo", "tipo", produto.idtipo);
            return View(produto);
        }

        //
        // GET: /Produto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idpacote = new SelectList(db.pacote, "idpacote", "pacote1", produto.idpacote);
            ViewBag.idtipo = new SelectList(db.tipoproduto, "idtipo", "tipo", produto.idtipo);
            return View(produto);
        }

        //
        // POST: /Produto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idpacote = new SelectList(db.pacote, "idpacote", "pacote1", produto.idpacote);
            ViewBag.idtipo = new SelectList(db.tipoproduto, "idtipo", "tipo", produto.idtipo);
            return View(produto);
        }

        //
        // GET: /Produto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // POST: /Produto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produto produto = db.produto.Find(id);
            db.produto.Remove(produto);
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