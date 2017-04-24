using SistemaAuxiliarPesquisaZika.Bussiness;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioBSN _usuarioRepository = new UsuarioBSN();
        private readonly PerfilBSN _perfilRepository = new PerfilBSN();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuarioViewModel = _usuarioRepository.SelectAll();
            return View(usuarioViewModel);
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var model = new UsuariosViewModel();

            var listaPerfil = _perfilRepository.SelectAll();

            model.ListaPerfil = (from x in listaPerfil
                                 select new SelectListItem
                                 {
                                     Text = x.Nome,
                                     Value = x.Id.ToString()
                                 });
            return View(model);
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepository.Insert(usuario);
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
