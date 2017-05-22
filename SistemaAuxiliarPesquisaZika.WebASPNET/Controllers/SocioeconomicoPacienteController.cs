using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class SocioeconomicoPacienteController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();

        // GET: SocioeconomicoPaciente
        public ActionResult Index()
        {
            var pesquisaSocioSaude = db.PesquisaSocioSaude.Include(p => p.Paciente);
            return View(pesquisaSocioSaude.ToList());
        }

        // GET: SocioeconomicoPaciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocioeconomicoPaciente pesquisaSocioSaude = db.PesquisaSocioSaude.Find(id);
            if (pesquisaSocioSaude == null)
            {
                return HttpNotFound();
            }
            return View(pesquisaSocioSaude);
        }

        // GET: SocioeconomicoPaciente/Create
        public ActionResult Create()
        {
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto");
            return View();
        }

        // POST: SocioeconomicoPaciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabalhoRemunerado,VivePaiRN,Fuma,UsoDrogas,NumeroCigarrosDia,TemDiabetes,TemHipertensao,SatisfacaoGravidez,TentativaInterromperGravidez,AbortosAnteriores,QuantosAborto,MotivoAborto,IdPaciente")] SocioeconomicoPaciente pesquisaSocioSaude)
        {
            if (ModelState.IsValid)
            {
                db.PesquisaSocioSaude.Add(pesquisaSocioSaude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Paciente, "Id", "NomeCompleto", pesquisaSocioSaude.Id);
            return View(pesquisaSocioSaude);
        }

        // GET: SocioeconomicoPaciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocioeconomicoPaciente pesquisaSocioSaude = db.PesquisaSocioSaude.Find(id);
            if (pesquisaSocioSaude == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Paciente, "Id", "NomeCompleto", pesquisaSocioSaude.Id);
            return View(pesquisaSocioSaude);
        }

        // POST: SocioeconomicoPaciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TrabalhoRemunerado,VivePaiRN,Fuma,UsoDrogas,NumeroCigarrosDia,TemDiabetes,TemHipertensao,SatisfacaoGravidez,TentativaInterromperGravidez,AbortosAnteriores,QuantosAborto,MotivoAborto,IdPaciente")] SocioeconomicoPaciente pesquisaSocioSaude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pesquisaSocioSaude).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Paciente, "Id", "NomeCompleto", pesquisaSocioSaude.Id);
            return View(pesquisaSocioSaude);
        }

        // GET: SocioeconomicoPaciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocioeconomicoPaciente pesquisaSocioSaude = db.PesquisaSocioSaude.Find(id);
            if (pesquisaSocioSaude == null)
            {
                return HttpNotFound();
            }
            return View(pesquisaSocioSaude);
        }

        // POST: SocioeconomicoPaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocioeconomicoPaciente pesquisaSocioSaude = db.PesquisaSocioSaude.Find(id);
            db.PesquisaSocioSaude.Remove(pesquisaSocioSaude);
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
