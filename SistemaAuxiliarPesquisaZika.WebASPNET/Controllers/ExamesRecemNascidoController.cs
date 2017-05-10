using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Bussiness;
using SistemaAuxiliarPesquisaZika.Domain.DTO;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class ExamesRecemNascidoController : Controller
    {
        private AuxSystemResearchContext _db = new AuxSystemResearchContext();
        private ExameBSN _examesRNRepository = new ExameBSN();

        // GET: ExamesRecemNascido
        public ActionResult Index()
        {
            //var examesRecemNascidoes = _db.ExamesRecemNascido.Include(e => e.RecemNascido);
            var examesRecemNascido = _examesRNRepository.ConsultaRNComExame();
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ExamesRecemNascido examesRecemNascido = _db.ExamesRecemNascido.Find(id);

            RNExameViewModel examesRecemNascido = _examesRNRepository.GetExameByIdRN(id);
            if (examesRecemNascido == null)
            {
                return HttpNotFound();
            }
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Create
        public ActionResult Create()
        {
            ViewBag.IdRecemNascido = new SelectList(_db.RecemNascido, "Id", "NomeCompleto");
            return View();
        }

        // POST: ExamesRecemNascido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdRecemNascido,DataExameZika,MaterialUtilizadoZika,ResultadoZika,DataExameChikunguia,MaterialUtilizadoChikunguia,ResultadoChikunguia,DataExameFebreAmarela,MaterialUtilizadoFebreAmarela,ResultadoFebreAmarela,DataExameToxoplasmose,MaterialUtilizadoToxoplasmose,ResultadoToxoplasmose")] ExamesRecemNascido examesRecemNascido)
        {
            if (ModelState.IsValid)
            {
                _db.ExamesRecemNascido.Add(examesRecemNascido);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.IdRecemNascido = new SelectList(_db.RecemNascido, "Id", "NomeCompleto", examesRecemNascido.IdRecemNascido);
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesRecemNascido examesRecemNascido = _db.ExamesRecemNascido.Find(id);
            if (examesRecemNascido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_db.RecemNascido, "Id", "NomeCompleto", examesRecemNascido.Id);
            return View(examesRecemNascido);
        }

        // POST: ExamesRecemNascido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataExameZika,MaterialUtilizadoZika,ResultadoZika,DataExameChikunguia,MaterialUtilizadoChikunguia,ResultadoChikunguia,DataExameFebreAmarela,MaterialUtilizadoFebreAmarela,ResultadoFebreAmarela,DataExameToxoplasmose,MaterialUtilizadoToxoplasmose,ResultadoToxoplasmose")] ExamesRecemNascido examesRecemNascido)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(examesRecemNascido).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Id = new SelectList(_db.RecemNascido, "Id", "NomeCompleto", examesRecemNascido.Id);
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesRecemNascido examesRecemNascido = _db.ExamesRecemNascido.Find(id);
            if (examesRecemNascido == null)
            {
                return HttpNotFound();
            }
            return View(examesRecemNascido);
        }

        // POST: ExamesRecemNascido/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExamesRecemNascido examesRecemNascido = _db.ExamesRecemNascido.Find(id);
            _db.ExamesRecemNascido.Remove(examesRecemNascido);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
            _db.Dispose();
        }
    }
}
