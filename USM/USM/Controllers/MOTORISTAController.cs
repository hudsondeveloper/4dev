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
    public class MOTORISTAController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: MOTORISTA
        public ActionResult Index()
        {
            var mOTORISTA = db.MOTORISTA.Include(m => m.ESTADO_CIVIL).Include(m => m.SEXO);
            return View(mOTORISTA.ToList());
        }

        // GET: MOTORISTA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOTORISTA mOTORISTA = db.MOTORISTA.Find(id);
            if (mOTORISTA == null)
            {
                return HttpNotFound();
            }
            return View(mOTORISTA);
        }

        // GET: MOTORISTA/Create
        public ActionResult Create()
        {
            ViewBag.ESTADO_CIVIL_ID = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "DESCRICAO");
            ViewBag.SEXO_ID = new SelectList(db.SEXO, "ID_SEXO", "DESCRICAO");
            return View();
        }

        // POST: MOTORISTA/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MATRICULA,NOME_MOTORISTA,CPF_MOTORISTA,NUM_HABILITACAO,DATA_NASC_MOTORISTA,ENDERECO_MOTORISTA,TELEFONE_MOTORISTA,SEXO_ID,ESTADO_CIVIL_ID")] MOTORISTA mOTORISTA)
        {
            if (ModelState.IsValid)
            {
                db.MOTORISTA.Add(mOTORISTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ESTADO_CIVIL_ID = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "DESCRICAO", mOTORISTA.ESTADO_CIVIL_ID);
            ViewBag.SEXO_ID = new SelectList(db.SEXO, "ID_SEXO", "DESCRICAO", mOTORISTA.SEXO_ID);
            return View(mOTORISTA);
        }

        // GET: MOTORISTA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOTORISTA mOTORISTA = db.MOTORISTA.Find(id);
            if (mOTORISTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ESTADO_CIVIL_ID = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "DESCRICAO", mOTORISTA.ESTADO_CIVIL_ID);
            ViewBag.SEXO_ID = new SelectList(db.SEXO, "ID_SEXO", "DESCRICAO", mOTORISTA.SEXO_ID);
            return View(mOTORISTA);
        }

        // POST: MOTORISTA/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MATRICULA,NOME_MOTORISTA,CPF_MOTORISTA,NUM_HABILITACAO,DATA_NASC_MOTORISTA,ENDERECO_MOTORISTA,TELEFONE_MOTORISTA,SEXO_ID,ESTADO_CIVIL_ID")] MOTORISTA mOTORISTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOTORISTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ESTADO_CIVIL_ID = new SelectList(db.ESTADO_CIVIL, "ID_ESTADO_CIVIL", "DESCRICAO", mOTORISTA.ESTADO_CIVIL_ID);
            ViewBag.SEXO_ID = new SelectList(db.SEXO, "ID_SEXO", "DESCRICAO", mOTORISTA.SEXO_ID);
            return View(mOTORISTA);
        }

        // GET: MOTORISTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOTORISTA mOTORISTA = db.MOTORISTA.Find(id);
            if (mOTORISTA == null)
            {
                return HttpNotFound();
            }
            return View(mOTORISTA);
        }

        // POST: MOTORISTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOTORISTA mOTORISTA = db.MOTORISTA.Find(id);
            db.MOTORISTA.Remove(mOTORISTA);
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
