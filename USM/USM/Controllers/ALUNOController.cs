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
    public class ALUNOController : Controller
    {
        private CONEXAOBD db = new CONEXAOBD();

        // GET: ALUNO
        public ActionResult Index()
        {
            var aLUNO = db.ALUNO.Include(a => a.FACULDADE).Include(a => a.ROTA).Include(a => a.TURNO);
            return View(aLUNO.ToList());
        }

        // GET: ALUNO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO aLUNO = db.ALUNO.Find(id);
            if (aLUNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUNO);
        }

        // GET: ALUNO/Create
        public ActionResult Create()
        {
            ViewBag.ID_FACULDADE = new SelectList(db.FACULDADE, "ID_FACULDADE", "NOME_FACULDADE");
            ViewBag.ID_ROTA = new SelectList(db.ROTA, "ID_ROTA", "NOME_ROTA");
            ViewBag.ID_TURNO_FACULDADE = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO");
            return View();
        }

        // POST: ALUNO/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALUNO,NOME_ALUNO,CPF_ALUNO,TITULO_ELEITOR,ENDERECO_ALUNO,TELEFONE_ALUNO,RUA,NUMERO,COMPLEMENTO,BAIRRO,CEP,ID_FACULDADE,ID_ROTA,ID_TURNO_FACULDADE")] ALUNO aLUNO)
        {
            if (ModelState.IsValid)
            {
                db.ALUNO.Add(aLUNO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_FACULDADE = new SelectList(db.FACULDADE, "ID_FACULDADE", "NOME_FACULDADE", aLUNO.ID_FACULDADE);
            ViewBag.ID_ROTA = new SelectList(db.ROTA, "ID_ROTA", "NOME_ROTA", aLUNO.ID_ROTA);
            ViewBag.ID_TURNO_FACULDADE = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO", aLUNO.ID_TURNO_FACULDADE);
            return View(aLUNO);
        }

        // GET: ALUNO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO aLUNO = db.ALUNO.Find(id);
            if (aLUNO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_FACULDADE = new SelectList(db.FACULDADE, "ID_FACULDADE", "NOME_FACULDADE", aLUNO.ID_FACULDADE);
            ViewBag.ID_ROTA = new SelectList(db.ROTA, "ID_ROTA", "NOME_ROTA", aLUNO.ID_ROTA);
            ViewBag.ID_TURNO_FACULDADE = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO", aLUNO.ID_TURNO_FACULDADE);
            return View(aLUNO);
        }

        // POST: ALUNO/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALUNO,NOME_ALUNO,CPF_ALUNO,TITULO_ELEITOR,ENDERECO_ALUNO,TELEFONE_ALUNO,RUA,NUMERO,COMPLEMENTO,BAIRRO,CEP,ID_FACULDADE,ID_ROTA,ID_TURNO_FACULDADE")] ALUNO aLUNO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLUNO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_FACULDADE = new SelectList(db.FACULDADE, "ID_FACULDADE", "NOME_FACULDADE", aLUNO.ID_FACULDADE);
            ViewBag.ID_ROTA = new SelectList(db.ROTA, "ID_ROTA", "NOME_ROTA", aLUNO.ID_ROTA);
            ViewBag.ID_TURNO_FACULDADE = new SelectList(db.TURNO, "ID_TURNO", "DESCRICAO", aLUNO.ID_TURNO_FACULDADE);
            return View(aLUNO);
        }

        // GET: ALUNO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALUNO aLUNO = db.ALUNO.Find(id);
            if (aLUNO == null)
            {
                return HttpNotFound();
            }
            return View(aLUNO);
        }

        // POST: ALUNO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALUNO aLUNO = db.ALUNO.Find(id);
            db.ALUNO.Remove(aLUNO);
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
