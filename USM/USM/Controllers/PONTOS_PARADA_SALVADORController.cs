using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USM.Models;

namespace USM.Controllers
{
    public class PONTOS_PARADA_SALVADORController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: PONTOS_PARADA_SALVADOR
        public ActionResult Index()
        {
            return View(db.PONTOS_PARADA_SALVADOR.ToList());
        }

        // GET: PONTOS_PARADA_SALVADOR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PONTOS_PARADA_SALVADOR pONTOS_PARADA_SALVADOR = db.PONTOS_PARADA_SALVADOR.Find(id);
            if (pONTOS_PARADA_SALVADOR == null)
            {
                return HttpNotFound();
            }
            return View(pONTOS_PARADA_SALVADOR);
        }

        // GET: PONTOS_PARADA_SALVADOR/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PONTOS_PARADA_SALVADOR/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PONTO_SALVADOR,NOME_PONTO_PARADA_SALVADOR")] PONTOS_PARADA_SALVADOR pONTOS_PARADA_SALVADOR)
        {
            if (ModelState.IsValid)
            {
                db.PONTOS_PARADA_SALVADOR.Add(pONTOS_PARADA_SALVADOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pONTOS_PARADA_SALVADOR);
        }

        // GET: PONTOS_PARADA_SALVADOR/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PONTOS_PARADA_SALVADOR pONTOS_PARADA_SALVADOR = db.PONTOS_PARADA_SALVADOR.Find(id);
            if (pONTOS_PARADA_SALVADOR == null)
            {
                return HttpNotFound();
            }
            return View(pONTOS_PARADA_SALVADOR);
        }

        // POST: PONTOS_PARADA_SALVADOR/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PONTO_SALVADOR,NOME_PONTO_PARADA_SALVADOR")] PONTOS_PARADA_SALVADOR pONTOS_PARADA_SALVADOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pONTOS_PARADA_SALVADOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pONTOS_PARADA_SALVADOR);
        }

        // GET: PONTOS_PARADA_SALVADOR/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PONTOS_PARADA_SALVADOR pONTOS_PARADA_SALVADOR = db.PONTOS_PARADA_SALVADOR.Find(id);
            if (pONTOS_PARADA_SALVADOR == null)
            {
                return HttpNotFound();
            }
            return View(pONTOS_PARADA_SALVADOR);
        }

        // POST: PONTOS_PARADA_SALVADOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PONTOS_PARADA_SALVADOR pONTOS_PARADA_SALVADOR = db.PONTOS_PARADA_SALVADOR.Find(id);
            db.PONTOS_PARADA_SALVADOR.Remove(pONTOS_PARADA_SALVADOR);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
