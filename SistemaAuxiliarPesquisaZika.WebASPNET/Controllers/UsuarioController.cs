using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SistemaAuxiliarPesquisaZika.Bussiness;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using SistemaAuxiliarPesquisaZika.WebASPNET.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class UsuarioController : Controller
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

            model.ListaPerfilColection = (from x in listaPerfil
                                 select new SelectListItem
                                 {
                                     Selected = (x.Id == model.IdPerfil),
                                     Text = x.Nome,
                                     Value = x.Id.ToString()
                                 });
            return View(model);
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuariosViewModel model)
        {
            var usuario = new UsuariosViewModel
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = model.Senha,
                ConfirmaSenha = model.ConfirmaSenha,
                Ativo = model.Ativo,
                IdPerfil = model.IdPerfil,
                PerfilSelecionado = model.PerfilSelecionado
            };

            if (ModelState.IsValid)
            {
                _usuarioRepository.Insert(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
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

                return RedirectToAction($"Index");
            }
            catch (Exception ex)
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

                return RedirectToAction($"Index");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Usuario usuario;

            using (LoginBSN repo = new LoginBSN())
            {
                usuario = repo.Login(model.Email, model.Senha);
                
            }

            // Login com sucesso
            if (usuario != null)
            {

                var ident = new ClaimsIdentity(
                    new[]
                    {
                        // Padrão para utilzar o mecanismo antiforgery
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                            "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),

                        // Outras Claims

                        // Nome do Usuario
                        new Claim(ClaimTypes.Name, usuario.Nome),

                        // Perfil
                        new Claim(ClaimTypes.Role, usuario.NomePerfil),

                        // Email
                        new Claim(ClaimTypes.Email, usuario.Email)

                    },
                    DefaultAuthenticationTypes.ApplicationCookie);

                HttpContext.GetOwinContext().Authentication.SignIn(
                    new AuthenticationProperties { IsPersistent = false }, ident);

                //Usuario Usuario = new Usuario();
                //int user = usuario.Id;
                //Usuario.Id = usuario.Id;
                //ViewData["IdUsuario"] = user;

                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction($"Index", $"Home");
            }
            else
            {
                ModelState.AddModelError("", "Credenciais Inválidas.");
                return View(model);
            }
        }

        public ActionResult LogOff()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Session.Abandon();
            return RedirectToAction($"Index", $"Home");
        }

        public ActionResult Registrar()
        {
            throw new NotImplementedException();
        }
    }
}
