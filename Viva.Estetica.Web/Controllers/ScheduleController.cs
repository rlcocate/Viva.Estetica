using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Viva.Estetica.Dominio;
using Viva.Estetica.Dominio.Enums;
using Viva.Estetica.InfraEstrutura;

namespace Viva.Estetica.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IAplicacao<Agenda> _agendaAplicacao = null;
        private readonly IAgendamento _negocio = null;
        private IList<Agenda> _agendamentos = null;

        private int IdSessoes { get; set; }

        public ScheduleController(IAplicacao<Agenda> aplicacao, IAgendamento negocio)
        {
            _agendaAplicacao = aplicacao;
            _negocio = negocio;

            if (_agendamentos == null)
            {
                ObterAgendas(0);
            }
        }

        public ActionResult Index()
        {
            if (TempData["Mensagem"] != null)
            {
                ViewBag.Mensagem = TempData["Mensagem"];
            }
            else
            {
                if (TempData["Agendamentos"] != null)
                {
                    _agendamentos = TempData["Agendamentos"] as List<Agenda>;
                }

                ViewBag.DentroHorarioMarcacao = _negocio.ValidarHorarioMarcarAgendamento();
            }
            return View(_agendamentos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Titulo = "Agendamento de Serviço do Cliente";
            ViewBag.Edicao = 1;
            CarregarTipoServicos();
            CarregarSessoes();
            return View("Edit");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Agenda agendamento)
        {
            TempData["Agendamentos"] = _agendaAplicacao.Inserir(agendamento);

            return RedirectToAction("Index", "Schedule");
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            string mensagem = _negocio.ValidarPeriodoCancelamentoRemarcacaoAgendamento(id);

            if (string.IsNullOrEmpty(mensagem))
            {
                ViewBag.Titulo = "Alteração do Agendamento do Cliente";
                ViewBag.Edicao = 1;

                Agenda age = new Agenda();

                if (TempData["Agendamentos"] != null)
                {
                    _agendamentos = TempData["Agendamentos"] as List<Agenda>;
                }

                age = _agendamentos.Where(c => c.Id.Equals(id)).FirstOrDefault() as Agenda;
                CarregarTipoServicos();
                CarregarSessoes();
                return View(age);
            }
            else
            {
                TempData["Mensagem"] = mensagem;
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Agenda agendamento)
        {
            TempData["Agendamentos"] = _agendaAplicacao.Atualizar(agendamento);

            return RedirectToAction("Index", "Schedule");
        }

        public ActionResult Details(int id)
        {
            ViewBag.Titulo = "Consulta do Agendamento do Cliente";
            ViewBag.Edicao = 0;

            CarregarTipoServicos();
            CarregarSessoes();

            Agenda cli = new Agenda();
            cli = _agendamentos.Where(a => a.Id.Equals(id)).FirstOrDefault() as Agenda;
            
            return View("Edit", cli);
        }

        public ActionResult Delete(Agenda agenda)
        {
            var item = _agendamentos.SingleOrDefault(r => r.Id.Equals(agenda.Id));
            if (item != null) _agendamentos.Remove(item);

            TempData["Agendamentos"] = _agendamentos;

            return RedirectToAction("Index", "Schedule");
        }

        private IList<Agenda> ObterAgendas(int id)
        {
            _agendamentos = _agendaAplicacao.Obter().ToList();

            if (id > 0)
            {
                _agendamentos = _agendamentos.Where(c => c.Id.Equals(id)).ToList();
            }

            return _agendamentos;
        }

        private void CarregarSessoes()
        {
            var sessoes = from Sessoes s in Enum.GetValues(typeof(Sessoes))
                          select new
                          {
                              Id = (int)s,
                              Nome = s.ToString()
                          };

            ViewBag.Sessoes = new SelectList(sessoes, "Id", "Nome");
        }

        private void CarregarTipoServicos()
        {
            var servicos = from TipoServico s in Enum.GetValues(typeof(TipoServico))
                          select new
                          {
                              Id = (int)s,
                              Nome = s.ToString()
                          };

            ViewBag.Servicos = new SelectList(servicos, "Id", "Nome");
        }
    }
}