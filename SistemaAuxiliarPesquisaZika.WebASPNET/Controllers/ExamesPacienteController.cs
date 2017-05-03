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
    public class ExamesPacienteController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: ExamesPaciente
        public ActionResult Index()
        {
            var examesPaciente = db.ExamesPaciente.Include(e => e.Paciente);
            return View(examesPaciente.ToList());
        }

        // GET: ExamesPaciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesPaciente examesPaciente = db.ExamesPaciente.Find(id);
            if (examesPaciente == null)
            {
                return HttpNotFound();
            }
            return View(examesPaciente);
        }

        // GET: ExamesPaciente/Create
        public ActionResult Create()
        {
            ExamesPaciente examesPaciente = new ExamesPaciente();
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto");
            ViewBag.ResultadoLues = new SelectList(examesPaciente.ResultadoLues, "Id", "Value");
            return View();
        }

        // POST: ExamesPaciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPaciente,DataExame,ResultadoHB,ResultadoHT,ResultadoLeucograma,ResultadoPlaquetas,ResultadoSaliva,ResultadoUrina,ResultadoSangue,ResultadoToxoplasmose")] ExamesPaciente examesPaciente)
        {
            if (ModelState.IsValid)
            {
                db.ExamesPaciente.Add(examesPaciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", examesPaciente.IdPaciente);
            ViewBag.ResultadoLues = new SelectList(examesPaciente.ResultadoLues, "Id", "Value", examesPaciente.selecionadoResultadoLues);
            return View(examesPaciente);
        }

        // GET: ExamesPaciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesPaciente examesPaciente = db.ExamesPaciente.Find(id);
            if (examesPaciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", examesPaciente.IdPaciente);
            return View(examesPaciente);
        }

        // POST: ExamesPaciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPaciente,DataExame,ResultadoHB,ResultadoHT,ResultadoLeucograma,ResultadoPlaquetas,ResultadoSaliva,ResultadoUrina,ResultadoSangue,ResultadoToxoplasmose")] ExamesPaciente examesPaciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examesPaciente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", examesPaciente.IdPaciente);
            return View(examesPaciente);
        }

        // GET: ExamesPaciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesPaciente examesPaciente = db.ExamesPaciente.Find(id);
            if (examesPaciente == null)
            {
                return HttpNotFound();
            }
            return View(examesPaciente);
        }

        // POST: ExamesPaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamesPaciente examesPaciente = db.ExamesPaciente.Find(id);
            db.ExamesPaciente.Remove(examesPaciente);
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
