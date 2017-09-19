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
    public class SEXOController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: SEXO
        public ActionResult Index()
        {
            return View(db.SEXO.ToList());
        }

        // GET: SEXO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEXO sEXO = db.SEXO.Find(id);
            if (sEXO == null)
            {
                return HttpNotFound();
            }
            return View(sEXO);
        }

        // GET: SEXO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SEXO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SEXO,DESCRICAO")] SEXO sEXO)
        {
            if (ModelState.IsValid)
            {
                db.SEXO.Add(sEXO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sEXO);
        }

        // GET: SEXO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEXO sEXO = db.SEXO.Find(id);
            if (sEXO == null)
            {
                return HttpNotFound();
            }
            return View(sEXO);
        }

        // POST: SEXO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SEXO,DESCRICAO")] SEXO sEXO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sEXO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sEXO);
        }

        // GET: SEXO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SEXO sEXO = db.SEXO.Find(id);
            if (sEXO == null)
            {
                return HttpNotFound();
            }
            return View(sEXO);
        }

        // POST: SEXO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SEXO sEXO = db.SEXO.Find(id);
            db.SEXO.Remove(sEXO);
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
