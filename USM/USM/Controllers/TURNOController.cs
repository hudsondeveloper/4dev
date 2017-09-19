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
    public class TURNOController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: TURNO
        public ActionResult Index()
        {
            return View(db.TURNO.ToList());
        }

        // GET: TURNO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TURNO tURNO = db.TURNO.Find(id);
            if (tURNO == null)
            {
                return HttpNotFound();
            }
            return View(tURNO);
        }

        // GET: TURNO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TURNO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TURNO,DESCRICAO")] TURNO tURNO)
        {
            if (ModelState.IsValid)
            {
                db.TURNO.Add(tURNO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tURNO);
        }

        // GET: TURNO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TURNO tURNO = db.TURNO.Find(id);
            if (tURNO == null)
            {
                return HttpNotFound();
            }
            return View(tURNO);
        }

        // POST: TURNO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TURNO,DESCRICAO")] TURNO tURNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tURNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tURNO);
        }

        // GET: TURNO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TURNO tURNO = db.TURNO.Find(id);
            if (tURNO == null)
            {
                return HttpNotFound();
            }
            return View(tURNO);
        }

        // POST: TURNO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TURNO tURNO = db.TURNO.Find(id);
            db.TURNO.Remove(tURNO);
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
