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
    public class ClienteController : Controller
    {
        private sgateEntities db = new sgateEntities();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void PreencherEstados()
        {
            List<SelectListItem> estados = new List<SelectListItem>();

            //Estados
            estados.Add(new SelectListItem() { Value = "MG", Text = "MG", Selected = true });
            estados.Add(new SelectListItem() { Value = "AC", Text = "AC" });
            estados.Add(new SelectListItem() { Value = "AL", Text = "AL" });
            estados.Add(new SelectListItem() { Value = "AP", Text = "AP" });
            estados.Add(new SelectListItem() { Value = "AM", Text = "AM" });
            estados.Add(new SelectListItem() { Value = "BA", Text = "BA" });
            estados.Add(new SelectListItem() { Value = "CE", Text = "CE" });
            estados.Add(new SelectListItem() { Value = "DF", Text = "DF" });
            estados.Add(new SelectListItem() { Value = "ES", Text = "ES" });
            estados.Add(new SelectListItem() { Value = "GO", Text = "GO" });
            estados.Add(new SelectListItem() { Value = "MA", Text = "MA" });
            estados.Add(new SelectListItem() { Value = "MT", Text = "MT" });
            estados.Add(new SelectListItem() { Value = "MS", Text = "MS" });
            estados.Add(new SelectListItem() { Value = "PA", Text = "PA" });
            estados.Add(new SelectListItem() { Value = "PB", Text = "PB" });
            estados.Add(new SelectListItem() { Value = "PR", Text = "PR" });
            estados.Add(new SelectListItem() { Value = "PE", Text = "PE" });
            estados.Add(new SelectListItem() { Value = "PI", Text = "PI" });
            estados.Add(new SelectListItem() { Value = "RJ", Text = "RJ" });
            estados.Add(new SelectListItem() { Value = "RN", Text = "RN" });
            estados.Add(new SelectListItem() { Value = "RS", Text = "RS" });
            estados.Add(new SelectListItem() { Value = "RO", Text = "RO" });
            estados.Add(new SelectListItem() { Value = "RR", Text = "RR" });
            estados.Add(new SelectListItem() { Value = "SC", Text = "SC" });
            estados.Add(new SelectListItem() { Value = "SP", Text = "SP" });
            estados.Add(new SelectListItem() { Value = "SE", Text = "SE" });
            estados.Add(new SelectListItem() { Value = "TO", Text = "TO" });

            ViewBag.Estados = new SelectList(estados, "value", "text");
        }
    }
}