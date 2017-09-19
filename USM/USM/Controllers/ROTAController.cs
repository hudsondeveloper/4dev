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
    public class ROTAController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: ROTA
        public ActionResult Index()
        {
            var rOTA = db.ROTA.Include(r => r.MOTORISTA).Include(r => r.ONIBUS).Include(r => r.TURNO);
            return View(rOTA.ToList());
        }

        // GET: ROTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROTA rOTA = db.ROTA.Find(id);
            if (rOTA == null)
            {
                return HttpNotFound();
            }
            return View(rOTA);
        }

        // GET: ROTA/Create
        public ActionResult Create()
        {
            ViewBag.MATRICULA_MOTORISTA = new SelectList(db.MOTORISTA, "MATRICULA", "NOME_MOTORISTA");
            ViewBag.PLACA_ONIBUS = new SelectList(db.ONIBUS, "PLACA", "EMPRESA");
            ViewBag.ID_TURNO_ROTA = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO");
            return View();
        }

        // POST: ROTA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ROTA,NOME_ROTA,PLACA_ONIBUS,MATRICULA_MOTORISTA,ID_TURNO_ROTA")] ROTA rOTA)
        {
            if (ModelState.IsValid)
            {
                db.ROTA.Add(rOTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MATRICULA_MOTORISTA = new SelectList(db.MOTORISTA, "MATRICULA", "NOME_MOTORISTA", rOTA.MATRICULA_MOTORISTA);
            ViewBag.PLACA_ONIBUS = new SelectList(db.ONIBUS, "PLACA", "EMPRESA", rOTA.PLACA_ONIBUS);
            ViewBag.ID_TURNO_ROTA = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO", rOTA.ID_TURNO_ROTA);
            return View(rOTA);
        }

        // GET: ROTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROTA rOTA = db.ROTA.Find(id);
            if (rOTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MATRICULA_MOTORISTA = new SelectList(db.MOTORISTA, "MATRICULA", "NOME_MOTORISTA", rOTA.MATRICULA_MOTORISTA);
            ViewBag.PLACA_ONIBUS = new SelectList(db.ONIBUS, "PLACA", "EMPRESA", rOTA.PLACA_ONIBUS);
            ViewBag.ID_TURNO_ROTA = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO", rOTA.ID_TURNO_ROTA);
            return View(rOTA);
        }

        // POST: ROTA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ROTA,NOME_ROTA,PLACA_ONIBUS,MATRICULA_MOTORISTA,ID_TURNO_ROTA")] ROTA rOTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MATRICULA_MOTORISTA = new SelectList(db.MOTORISTA, "MATRICULA", "NOME_MOTORISTA", rOTA.MATRICULA_MOTORISTA);
            ViewBag.PLACA_ONIBUS = new SelectList(db.ONIBUS, "PLACA", "EMPRESA", rOTA.PLACA_ONIBUS);
            ViewBag.ID_TURNO_ROTA = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO", rOTA.ID_TURNO_ROTA);
            return View(rOTA);
        }

        // GET: ROTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROTA rOTA = db.ROTA.Find(id);
            if (rOTA == null)
            {
                return HttpNotFound();
            }
            return View(rOTA);
        }

        // POST: ROTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROTA rOTA = db.ROTA.Find(id);
            db.ROTA.Remove(rOTA);
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
