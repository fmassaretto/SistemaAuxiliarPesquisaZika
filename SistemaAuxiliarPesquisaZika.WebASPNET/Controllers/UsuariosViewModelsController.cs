using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class UsuariosViewModelsController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: UsuariosViewModels
        public ActionResult Index()
        {
            return View(db.UsuariosViewModels.ToList());
        }

        // GET: UsuariosViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosViewModel usuariosViewModel = db.UsuariosViewModels.Find(id);
            if (usuariosViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuariosViewModel);
        }

        // GET: UsuariosViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuariosViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Senha,ConfirmaSenha,Ativo,IdPerfil")] UsuariosViewModel usuariosViewModel)
        {
            if (ModelState.IsValid)
            {
                db.UsuariosViewModels.Add(usuariosViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuariosViewModel);
        }

        // GET: UsuariosViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosViewModel usuariosViewModel = db.UsuariosViewModels.Find(id);
            if (usuariosViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuariosViewModel);
        }

        // POST: UsuariosViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Senha,ConfirmaSenha,Ativo,IdPerfil")] UsuariosViewModel usuariosViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariosViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariosViewModel);
        }

        // GET: UsuariosViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuariosViewModel usuariosViewModel = db.UsuariosViewModels.Find(id);
            if (usuariosViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuariosViewModel);
        }

        // POST: UsuariosViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuariosViewModel usuariosViewModel = db.UsuariosViewModels.Find(id);
            db.UsuariosViewModels.Remove(usuariosViewModel);
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
