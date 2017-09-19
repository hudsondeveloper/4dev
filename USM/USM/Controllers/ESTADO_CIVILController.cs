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
    public class ESTADO_CIVILController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: ESTADO_CIVIL
        public ActionResult Index()
        {
            return View(db.ESTADO_CIVIL.ToList());
        }

        // GET: ESTADO_CIVIL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            if (eSTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CIVIL);
        }

        // GET: ESTADO_CIVIL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ESTADO_CIVIL/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTADO_CIVIL,DESCRICAO")] ESTADO_CIVIL eSTADO_CIVIL)
        {
            if (ModelState.IsValid)
            {
                db.ESTADO_CIVIL.Add(eSTADO_CIVIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eSTADO_CIVIL);
        }

        // GET: ESTADO_CIVIL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            if (eSTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CIVIL);
        }

        // POST: ESTADO_CIVIL/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTADO_CIVIL,DESCRICAO")] ESTADO_CIVIL eSTADO_CIVIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADO_CIVIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eSTADO_CIVIL);
        }

        // GET: ESTADO_CIVIL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            if (eSTADO_CIVIL == null)
            {
                return HttpNotFound();
            }
            return View(eSTADO_CIVIL);
        }

        // POST: ESTADO_CIVIL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADO_CIVIL eSTADO_CIVIL = db.ESTADO_CIVIL.Find(id);
            db.ESTADO_CIVIL.Remove(eSTADO_CIVIL);
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
