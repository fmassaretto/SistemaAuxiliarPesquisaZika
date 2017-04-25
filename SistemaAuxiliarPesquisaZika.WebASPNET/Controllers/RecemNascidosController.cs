using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class RecemNascidosController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: RecemNascidos
        public ActionResult Index()
        {
            var recemNascido = db.RecemNascido.Include(r => r.Paciente);
            return View(recemNascido.ToList());
        }

        // GET: RecemNascidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecemNascido recemNascido = db.RecemNascido.Find(id);
            if (recemNascido == null)
            {
                return HttpNotFound();
            }
            return View(recemNascido);
        }

        // GET: RecemNascidos/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto");
            return View();
        }

        // POST: RecemNascidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeCompleto,DataNascimento,IdPaciente")] RecemNascido recemNascido)
        {
            if (ModelState.IsValid)
            {
                db.RecemNascido.Add(recemNascido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", recemNascido.IdPaciente);
            return View(recemNascido);
        }

        // GET: RecemNascidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecemNascido recemNascido = db.RecemNascido.Find(id);
            if (recemNascido == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", recemNascido.IdPaciente);
            return View(recemNascido);
        }

        // POST: RecemNascidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeCompleto,DataNascimento,IdPaciente")] RecemNascido recemNascido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recemNascido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", recemNascido.IdPaciente);
            return View(recemNascido);
        }

        // GET: RecemNascidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecemNascido recemNascido = db.RecemNascido.Find(id);
            if (recemNascido == null)
            {
                return HttpNotFound();
            }
            return View(recemNascido);
        }

        // POST: RecemNascidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecemNascido recemNascido = db.RecemNascido.Find(id);
            db.RecemNascido.Remove(recemNascido);
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
