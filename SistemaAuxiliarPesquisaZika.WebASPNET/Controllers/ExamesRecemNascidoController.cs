using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class ExamesRecemNascidoController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: ExamesRecemNascido
        public ActionResult Index()
        {
            var examesRecemNascidoes = db.ExamesRecemNascidoes.Include(e => e.RecemNascido);
            return View(examesRecemNascidoes.ToList());
        }

        // GET: ExamesRecemNascido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesRecemNascido examesRecemNascido = db.ExamesRecemNascidoes.Find(id);
            if (examesRecemNascido == null)
            {
                return HttpNotFound();
            }
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.RecemNascido, "Id", "NomeCompleto");
            return View();
        }

        // POST: ExamesRecemNascido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataExameZika,MaterialUtilizadoZika,ResultadoZika,DataExameChikunguia,MaterialUtilizadoChikunguia,ResultadoChikunguia,DataExameFebreAmarela,MaterialUtilizadoFebreAmarela,ResultadoFebreAmarela,DataExameToxoplasmose,MaterialUtilizadoToxoplasmose,ResultadoToxoplasmose")] ExamesRecemNascido examesRecemNascido)
        {
            if (ModelState.IsValid)
            {
                db.ExamesRecemNascidoes.Add(examesRecemNascido);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Id = new SelectList(db.RecemNascido, "Id", "NomeCompleto", examesRecemNascido.Id);
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesRecemNascido examesRecemNascido = db.ExamesRecemNascidoes.Find(id);
            if (examesRecemNascido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.RecemNascido, "Id", "NomeCompleto", examesRecemNascido.Id);
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
                db.Entry(examesRecemNascido).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Id = new SelectList(db.RecemNascido, "Id", "NomeCompleto", examesRecemNascido.Id);
            return View(examesRecemNascido);
        }

        // GET: ExamesRecemNascido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExamesRecemNascido examesRecemNascido = db.ExamesRecemNascidoes.Find(id);
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
            ExamesRecemNascido examesRecemNascido = db.ExamesRecemNascidoes.Find(id);
            db.ExamesRecemNascidoes.Remove(examesRecemNascido);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
            db.Dispose();
        }
    }
}
