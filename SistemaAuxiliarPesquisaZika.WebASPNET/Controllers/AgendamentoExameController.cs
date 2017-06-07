using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SistemaAuxiliarPesquisaZika.Bussiness;
using SistemaAuxiliarPesquisaZika.Data.Context;
using SistemaAuxiliarPesquisaZika.Domain;
using SistemaAuxiliarPesquisaZika.Domain.DTO;
using ZikaVirusProject.Services.Email;
using ZikaVirusProject.Services.SMS;
using EntityState = System.Data.Entity.EntityState;

namespace SistemaAuxiliarPesquisaZika.WebASPNET.Controllers
{
    public class AgendamentoExameController : Controller
    {
        private AuxSystemResearchContext db = new AuxSystemResearchContext();
        private AgendamentoBSN _agendamentoRepository = new AgendamentoBSN();

        private const string _msgConfirmacaoAgendamentoEmail = "<h2>Projeto Vírus Zika</h2></br>" +
                                                               "<p>E-mail confirmando o agendamento do {0}, para o dia <b>{1}</b> " +
                                                               "com o médico {2}.</p><p>Comparecer no local: <b>{3}</b> com 30 minutos" +
                                                               " de antecedência.</p>";

        private const string _subjectConfirmacaoAgendamentoEmail = "Confirmação do Agendamento de Exame - Projeto Vírus Zika";

        private const string _msgConfirmacaoAgendamentoCel = "CONFIRMAÇÃO DO AGENDAMENTO\n" +
                                                            "Você tem {0}, marcado para o dia " +
                                                            "{1} com o médico {2} no local {3}";

        private const string _msgCancelAgendamentoEmail = "<h2>Projeto Vírus Zika</h2></br>" + 
                                                          "<p>E-mail <b>CANCELANDO</b> o agendamento do {0}, para o dia <b>{1}</b> " +
                                                          "com o médico {2}, no local: <b>{3}</b>.</p><p><b>Nova data será " +
                                                          "remarcada.</b></p>";
        private const string _subjectCancelAgendamentoEmail = "CANCELAMENTO do Agendamento de Exame - Projeto Vírus Zika";

        private const string _msgCancelAgendamentoCel = "CANCELAMENTO DO AGENDAMENTO\n" +
                                                        "O agendamendo do {0}, marcado para o dia " +
                                                        "{1} com o médico {2} no local {3} foi CANCELADO";

        // GET: AgendamentoExame
        public ActionResult Index()
        {
            var agendamentoExame = db.AgendamentoExame.Include(a => a.Paciente).Include(a => a.Usuario);
            return View(agendamentoExame.ToList());
        }

        // GET: AgendamentoExame/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //AgendamentoExame agendamentoExame = db.AgendamentoExame.Find(id);
            AgendamentoViewModel agendamentoExame = _agendamentoRepository.GetAgendamento(id);
            if (agendamentoExame == null)
            {
                return HttpNotFound();
            }
            return View(agendamentoExame);
        }

        // GET: AgendamentoExame/Create
        public ActionResult Create()
        {
            var selectMedico = db.Usuarios.SqlQuery("SELECT * FROM Usuario WHERE IdPerfil = 3");
            ViewBag.IdPaciente = new SelectList(db.Paciente, "Id", "NomeCompleto");
            //ViewBag.IdUsuario = new SelectList(db.Usuarios, "Id", "Nome");
            ViewBag.IdUsuario = new SelectList(selectMedico, "Id", "Nome");
            return View();
        }

        // POST: AgendamentoExame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdPaciente,IdUsuario,DataMarcadaExame,NomeExame,LocalExame")] AgendamentoExame agendamentoExame)
        {
            TwilioSMS twilioSMS = new TwilioSMS();
            Email email = new Email();
            var paciente = db.Paciente.Find(agendamentoExame.IdPaciente);
            var nomeMedico = db.Usuarios.Find(agendamentoExame.IdUsuario);

            var msgConfirmacaoCel = String.Format(_msgConfirmacaoAgendamentoCel, agendamentoExame.NomeExame, 
                agendamentoExame.DataMarcadaExame, nomeMedico.Nome, agendamentoExame.LocalExame);

            var msgConfirmacaoEmail = String.Format(_msgConfirmacaoAgendamentoEmail, agendamentoExame.NomeExame,
                agendamentoExame.DataMarcadaExame, nomeMedico.Nome, agendamentoExame.LocalExame);

            if (ModelState.IsValid)
            {
                db.AgendamentoExame.Add(agendamentoExame);
                db.SaveChanges();

                if (!paciente.Telefone.IsNullOrWhiteSpace())
                    twilioSMS.SendTwilioSMS(paciente.Telefone, msgConfirmacaoCel);

                if (!paciente.Email.IsNullOrWhiteSpace())
                    email.SendEmail(paciente.Email, _subjectConfirmacaoAgendamentoEmail, msgConfirmacaoEmail);

                return RedirectToAction($"Index");
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
                return RedirectToAction($"Index");
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
            AgendamentoViewModel agendamentoExame = _agendamentoRepository.GetAgendamento(id);
            //agendamentoExame.Paciente = db.Paciente.Find(id);

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
            Email email = new Email();
            TwilioSMS twilioSMS = new TwilioSMS();

            var paciente = db.Paciente.Find(agendamentoExame.IdPaciente);
            var nomeMedico = db.Usuarios.Find(agendamentoExame.IdUsuario);

            var msgCancelamentoCel = String.Format(_msgCancelAgendamentoCel, agendamentoExame.NomeExame,
                agendamentoExame.DataMarcadaExame, nomeMedico.Nome, agendamentoExame.LocalExame);

            var msgCancelamentoEmail = String.Format(_msgCancelAgendamentoEmail, agendamentoExame.NomeExame,
                agendamentoExame.DataMarcadaExame, nomeMedico.Nome, agendamentoExame.LocalExame);

            if (!paciente.Telefone.IsNullOrWhiteSpace())
                twilioSMS.SendTwilioSMS(paciente.Telefone, msgCancelamentoCel);

            if (!paciente.Email.IsNullOrWhiteSpace())
                email.SendEmail(paciente.Email, _subjectCancelAgendamentoEmail, msgCancelamentoEmail);

            db.AgendamentoExame.Remove(agendamentoExame);
            db.SaveChanges();
            return RedirectToAction($"Index");
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
