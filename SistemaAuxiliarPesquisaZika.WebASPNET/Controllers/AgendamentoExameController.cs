﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
using EntityState = System.Data.Entity.EntityState;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class AgendamentoExameController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: AgendamentoExame
        public ActionResult Index()
        {
            var agendamentoExame = db.AgendamentoExame.Include(a => a.Paciente).Include(a => a.Usuario);
            return View(agendamentoExame.ToList());
        }

        // GET: AgendamentoExame/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoExame agendamentoExame = db.AgendamentoExame.Find(id);
            if (agendamentoExame == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoExame);
        }

        // GET: AgendamentoExame/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto");
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Nome");
            return View();
        }

        // POST: AgendamentoExame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPaciente,IdUsuario,DataMarcadaExame,NomeExame,LocalExame")] AgendamentoExame agendamentoExame)
        {
            if (ModelState.IsValid)
            {
                db.AgendamentoExame.Add(agendamentoExame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", agendamentoExame.IdPaciente);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Nome", agendamentoExame.IdUsuario);
            return View(agendamentoExame);
        }

        // GET: AgendamentoExame/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoExame agendamentoExame = db.AgendamentoExame.Find(id);
            if (agendamentoExame == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", agendamentoExame.IdPaciente);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Nome", agendamentoExame.IdUsuario);
            return View(agendamentoExame);
        }

        // POST: AgendamentoExame/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdPaciente,IdUsuario,DataMarcadaExame,NomeExame,LocalExame")] AgendamentoExame agendamentoExame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendamentoExame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto", agendamentoExame.IdPaciente);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Nome", agendamentoExame.IdUsuario);
            return View(agendamentoExame);
        }

        // GET: AgendamentoExame/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgendamentoExame agendamentoExame = db.AgendamentoExame.Find(id);
            agendamentoExame.Paciente = db.Paciente.Find(id);

            if (agendamentoExame == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoExame);
        }

        // POST: AgendamentoExame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgendamentoExame agendamentoExame = db.AgendamentoExame.Find(id);
            db.AgendamentoExame.Remove(agendamentoExame);
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