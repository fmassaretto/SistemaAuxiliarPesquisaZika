using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain.DTO;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class PacienteViewModelsController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: PacienteViewModels
        public ActionResult Index()
        {
            return View(db.PacienteViewModels.ToList());
        }

        // GET: PacienteViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PacienteViewModel pacienteViewModel = db.PacienteViewModels.Find(id);
            if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pacienteViewModel);
        }

        // GET: PacienteViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacienteViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroCaso,NomeCompleto,CPF,RG,Endereco,Bairro,Cidade,UBSFrequenta,Email,Telefone,DataNascimento,TrabalhoRemunerado,VivePaiRN,Fuma,UsoDrogas,NumeroCigarrosDia,TemDiabetes,TemHipertensao,SatisfacaoGravidez,TentativaInterromperGravidez,AbortosAnteriores,QuantosAborto,MotivoAborto")] PacienteViewModel pacienteViewModel)
        {
            if (ModelState.IsValid)
            {
                db.PacienteViewModels.Add(pacienteViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pacienteViewModel);
        }

        // GET: PacienteViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PacienteViewModel pacienteViewModel = db.PacienteViewModels.Find(id);
            if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pacienteViewModel);
        }

        // POST: PacienteViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroCaso,NomeCompleto,CPF,RG,Endereco,Bairro,Cidade,UBSFrequenta,Email,Telefone,DataNascimento,TrabalhoRemunerado,VivePaiRN,Fuma,UsoDrogas,NumeroCigarrosDia,TemDiabetes,TemHipertensao,SatisfacaoGravidez,TentativaInterromperGravidez,AbortosAnteriores,QuantosAborto,MotivoAborto")] PacienteViewModel pacienteViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacienteViewModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacienteViewModel);
        }

        // GET: PacienteViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PacienteViewModel pacienteViewModel = db.PacienteViewModels.Find(id);
            if (pacienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pacienteViewModel);
        }

        // POST: PacienteViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PacienteViewModel pacienteViewModel = db.PacienteViewModels.Find(id);
            db.PacienteViewModels.Remove(pacienteViewModel);
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
