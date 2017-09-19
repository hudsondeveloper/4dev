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
    public class PONTOS_PARADA_CAMACARIController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: PONTOS_PARADA_CAMACARI
        public ActionResult Index()
        {
            return View(db.PONTOS_PARADA_CAMACARI.ToList());
        }

        // GET: PONTOS_PARADA_CAMACARI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PONTOS_PARADA_CAMACARI pONTOS_PARADA_CAMACARI = db.PONTOS_PARADA_CAMACARI.Find(id);
            if (pONTOS_PARADA_CAMACARI == null)
            {
                return HttpNotFound();
            }
            return View(pONTOS_PARADA_CAMACARI);
        }

        // GET: PONTOS_PARADA_CAMACARI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PONTOS_PARADA_CAMACARI/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PONTO_CAMACARI,NOME_PONTO_PARADA_CAMACARI")] PONTOS_PARADA_CAMACARI pONTOS_PARADA_CAMACARI)
        {
            if (ModelState.IsValid)
            {
                db.PONTOS_PARADA_CAMACARI.Add(pONTOS_PARADA_CAMACARI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pONTOS_PARADA_CAMACARI);
        }

        // GET: PONTOS_PARADA_CAMACARI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PONTOS_PARADA_CAMACARI pONTOS_PARADA_CAMACARI = db.PONTOS_PARADA_CAMACARI.Find(id);
            if (pONTOS_PARADA_CAMACARI == null)
            {
                return HttpNotFound();
            }
            return View(pONTOS_PARADA_CAMACARI);
        }

        // POST: PONTOS_PARADA_CAMACARI/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PONTO_CAMACARI,NOME_PONTO_PARADA_CAMACARI")] PONTOS_PARADA_CAMACARI pONTOS_PARADA_CAMACARI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pONTOS_PARADA_CAMACARI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pONTOS_PARADA_CAMACARI);
        }

        // GET: PONTOS_PARADA_CAMACARI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PONTOS_PARADA_CAMACARI pONTOS_PARADA_CAMACARI = db.PONTOS_PARADA_CAMACARI.Find(id);
            if (pONTOS_PARADA_CAMACARI == null)
            {
                return HttpNotFound();
            }
            return View(pONTOS_PARADA_CAMACARI);
        }

        // POST: PONTOS_PARADA_CAMACARI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PONTOS_PARADA_CAMACARI pONTOS_PARADA_CAMACARI = db.PONTOS_PARADA_CAMACARI.Find(id);
            db.PONTOS_PARADA_CAMACARI.Remove(pONTOS_PARADA_CAMACARI);
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
