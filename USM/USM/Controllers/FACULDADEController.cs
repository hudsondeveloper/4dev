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
    public class FACULDADEController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: FACULDADE
        public ActionResult Index()
        {
            return View(db.FACULDADE.ToList());
        }

        // GET: FACULDADE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULDADE fACULDADE = db.FACULDADE.Find(id);
            if (fACULDADE == null)
            {
                return HttpNotFound();
            }
            return View(fACULDADE);
        }

        // GET: FACULDADE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FACULDADE/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_FACULDADE,NOME_FACULDADE")] FACULDADE fACULDADE)
        {
            if (ModelState.IsValid)
            {
                db.FACULDADE.Add(fACULDADE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fACULDADE);
        }

        // GET: FACULDADE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULDADE fACULDADE = db.FACULDADE.Find(id);
            if (fACULDADE == null)
            {
                return HttpNotFound();
            }
            return View(fACULDADE);
        }

        // POST: FACULDADE/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_FACULDADE,NOME_FACULDADE")] FACULDADE fACULDADE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACULDADE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fACULDADE);
        }

        // GET: FACULDADE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULDADE fACULDADE = db.FACULDADE.Find(id);
            if (fACULDADE == null)
            {
                return HttpNotFound();
            }
            return View(fACULDADE);
        }

        // POST: FACULDADE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACULDADE fACULDADE = db.FACULDADE.Find(id);
            db.FACULDADE.Remove(fACULDADE);
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
