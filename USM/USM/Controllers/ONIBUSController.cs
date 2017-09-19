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
    public class ONIBUSController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: ONIBUS
        public ActionResult Index()
        {
            return View(db.ONIBUS.ToList());
        }

        // GET: ONIBUS/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ONIBUS oNIBUS = db.ONIBUS.Find(id);
            if (oNIBUS == null)
            {
                return HttpNotFound();
            }
            return View(oNIBUS);
        }

        // GET: ONIBUS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ONIBUS/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PLACA,EMPRESA,QTD_ASSENTOS")] ONIBUS oNIBUS)
        {
            if (ModelState.IsValid)
            {
                db.ONIBUS.Add(oNIBUS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oNIBUS);
        }

        // GET: ONIBUS/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ONIBUS oNIBUS = db.ONIBUS.Find(id);
            if (oNIBUS == null)
            {
                return HttpNotFound();
            }
            return View(oNIBUS);
        }

        // POST: ONIBUS/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PLACA,EMPRESA,QTD_ASSENTOS")] ONIBUS oNIBUS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oNIBUS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oNIBUS);
        }

        // GET: ONIBUS/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ONIBUS oNIBUS = db.ONIBUS.Find(id);
            if (oNIBUS == null)
            {
                return HttpNotFound();
            }
            return View(oNIBUS);
        }

        // POST: ONIBUS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ONIBUS oNIBUS = db.ONIBUS.Find(id);
            db.ONIBUS.Remove(oNIBUS);
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
