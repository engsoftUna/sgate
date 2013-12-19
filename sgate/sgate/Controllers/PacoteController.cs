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
        public int idpac, idprod;
        
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
            //ViewBag.itenspac = new List<produto>(db.produto.ToList());

            //busca as informacoes do pacote na base
            var listpac = (Object)(from pc in db.pacote
                             join it in db.itenspacote
                                on  pc.idpacote equals it.idpacote
                             join pd in db.produto
                                on it.idproduto equals pd.idproduto
                             where pc.idpacote.Equals(id)
                             orderby it.iditempacote
                             select new { pd.idproduto, pd.descricao, pd.valorproduto, pd.dataexpiracao }
                         );

            ViewBag.itenspac = (Object)listpac;

            if (ViewBag.itenspac == null)
            {
                return HttpNotFound();
            }
            //return View(pacote);
            return View();
        }

        //
        // GET: /Pacote/Create

        public ActionResult Create()
        {
            ViewBag.produto = new List<produto>(db.produto.ToList());           
            return View();
        }

        //
        // POST: /Pacote/Create

        [HttpPost]
        public ActionResult Create(pacote pacote, FormCollection form)
        {
            //var desc = form.GetValues("descricao");
            var idprodpac = form.GetValues("chbidprod");

            foreach (string id in idprodpac)
            {
                if (pacote.idpacote == 0)
                {
                    db.pacote.Add(pacote);
                    db.SaveChanges();

                    idpac = pacote.idpacote;
                    idprod = Convert.ToInt16(id);

                    var itens = new itenspacote
                    {
                        idpacote = idpac,
                        idproduto = idprod
                    };

                    db.itenspacote.Add(itens);
                    db.SaveChanges();
                }
                else
                {
                    idpac = pacote.idpacote;
                    idprod = Convert.ToInt16(id);

                    var itens = new itenspacote
                    {
                        idpacote = idpac,
                        idproduto = idprod
                    };

                    db.itenspacote.Add(itens);
                    db.SaveChanges();
                }
                
                //return RedirectToAction("Index");
            }

            //return View(pacote);
            //ViewBag.produto = new List<produto>(db.produto.ToList());
            //return View();
            return RedirectToAction("Index");
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
        public ActionResult DeleteConfirmed(int id)
        {
            pacote pacote = db.pacote.Find(id);
            db.pacote.Remove(pacote);
            db.SaveChanges();

            itenspacote itens = db.itenspacote.First(i => i.idpacote == id);
            db.itenspacote.Remove(itens);
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