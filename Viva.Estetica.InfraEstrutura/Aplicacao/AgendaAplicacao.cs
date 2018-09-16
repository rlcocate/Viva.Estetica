using System;
using System.Collections.Generic;
using System.Linq;
using Viva.Estetica.Dominio;

namespace Viva.Estetica.InfraEstrutura
{
    public class AgendaAplicacao : IAplicacao<Agenda>, IAgendamento
    {
        private readonly IRepositorio<Agenda> _agendamentoRepositorio;

        public AgendaAplicacao(IRepositorio<Agenda> repositorio)
        {
            _agendamentoRepositorio = repositorio;
        }

        public IEnumerable<Agenda> Obter()
        {
            return _agendamentoRepositorio.Obter()
                                .OrderBy(a => a.Cliente.Nome)
                                .ThenBy(a => a.Servico.Nome)
                                .ThenBy(a => a.Data)
                                .ThenBy(a => a.Horario).ToList();
        }

        public Agenda Obter(int id)
        {
            return _agendamentoRepositorio.Obter(id);
        }

        public IEnumerable<Agenda> Inserir(Agenda agendamento)
        {
            return _agendamentoRepositorio.Inserir(agendamento);
        }

        public IEnumerable<Agenda> Atualizar(Agenda agendamento)
        {
            return _agendamentoRepositorio.Atualizar(agendamento);
        }

        public IEnumerable<Agenda> Excluir(int id)
        {
            return _agendamentoRepositorio.Excluir(id);
        }

        public bool ValidarHorarioMarcarAgendamento()
        {
            TimeSpan inicio = new TimeSpan(8, 0, 0);
            TimeSpan final = new TimeSpan(19, 30, 0); ;

            int i = TimeSpan.Compare(DateTime.Now.TimeOfDay, inicio);
            int f = TimeSpan.Compare(DateTime.Now.TimeOfDay, final);

            // Verifica se está entre o período de 8 e 16 horas.
            return (i >= 0 && f <= 0);
        }

        // O cliente pode cancelar o reagendar um serviço com até 1 dia de antecedência, 
        // mas se for uma massagem deve ser com 24hs de antecedência.
        public string ValidarPeriodoCancelamentoRemarcacaoAgendamento(int id)
        {
            string mensagem = string.Empty;

            var agendamento = Obter(id);

            //if (agendamento.Servico.Nome == TipoServico.Massagem.ToString())
            //{
            //    if (agendamento.Data != DateTime.Now)
            //    {
            //        mensagem = "Massagem so pode ser cancelada ou reagendada com 24 horas de antecedencia.";
            //    }
            //}
            //else
            //{
            //    if (agendamento.Data >= DateTime.Now)
            //    {
            //        mensagem = "Servico so pode ser cancelado com ate 1 dia de antecedencia.";
            //    }
            //}
            return mensagem;
        }
    }
}
