using System;
using System.Collections.Generic;
using System.Linq;
using Viva.Estetica.Dominio;

namespace Viva.Estetica.InfraEstrutura
{
    public class AgendaRepositorio : IRepositorio<Agenda>
    {
        IEnumerable<Agenda> _agendamentos = null;

        public AgendaRepositorio(IEnumerable<Agenda> agendas)
        {
            if (agendas.Count() > 0)
            {
                _agendamentos = agendas;
            }
            else
            {
                AgendaMock();
            }
        }

        public IEnumerable<Agenda> Obter()
        {
            return _agendamentos;
        }

        public Agenda Obter(int id)
        {
            return _agendamentos.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Agenda> Inserir(Agenda agendamento)
        {
            var newId = _agendamentos.Max(c => c.Id);
            agendamento.Id = newId + 1;
            _agendamentos.ToList().Add(agendamento);

            return _agendamentos;
        }

        public IEnumerable<Agenda> Atualizar(Agenda agendamento)
        {
            _agendamentos.FirstOrDefault(c => c.Id.Equals(agendamento.Id)).Data = agendamento.Data;
            _agendamentos.FirstOrDefault(c => c.Id.Equals(agendamento.Id)).Horario = agendamento.Horario;
            _agendamentos.FirstOrDefault(c => c.Id.Equals(agendamento.Id)).Cliente = agendamento.Cliente;
            _agendamentos.FirstOrDefault(c => c.Id.Equals(agendamento.Id)).Servico = agendamento.Servico;

            return _agendamentos;
        }

        public void Dispose()
        {
        }

        public IEnumerable<Agenda> Excluir(int id)
        {
            var item = _agendamentos.SingleOrDefault(r => r.Id.Equals(id));
            if (item != null) _agendamentos.ToList().Remove(item);
            return _agendamentos;
        }

        private void AgendaMock()
        {
            Cliente marcia = new Cliente()
            {
                Id = 1,
                Nome = "Márcia",
                Sobrenome = "Freire",
                Documento = "426.398.098-55",
                Celular = "+55-11-95338-8758",
                Endereco = "Rua Manuel Bandeira, 13"
            };

            Cliente julieta = new Cliente()
            {
                Id = 3,
                Nome = "Julieta Castro",
                Sobrenome = "Sodré",
                Celular = "+55-11-963149771",
                Documento = "22.549.619-1",
                Endereco = "Av Carlos Gameleira"
            };

            _agendamentos = new List<Agenda>()
            {
                new Agenda {
                    Id = 1, Cliente = marcia,

                    TipoServico = Dominio.Enums.TipoServico.Massagem,
                    Data= "18/09/2018",
                    Horario = "13:00",
                    Duracao = 30,
                    IdSessoes = 0,
                    Servico = new Servico()
                    {
                        Id = 0,
                        Nome ="Massagem"
                    }
                },
                new Agenda {
                    Id = 3,Cliente = marcia,
                    TipoServico = Dominio.Enums.TipoServico.Massagem,
                    IdSessoes = 0,
                    Data = "21/09/2018",
                    Horario = "10:00",
                    Duracao = 30,
                    Servico = new Servico()
                    {
                        Id = 0,
                        Nome ="Massagem"
                    }
                },
                new Agenda {
                    Id = 2, Cliente = julieta,
                    TipoServico= Dominio.Enums.TipoServico.Outros,
                    IdSessoes = 1,
                    Data = "18/09/2018",
                    Horario = "15:00",
                    Duracao = 60,
                    Servico = new Servico()
                    {
                        Id = 1,
                        Nome ="Outros"
                    }
                },

                new Agenda {
                    Id = 4, Cliente = julieta,
                    IdSessoes = 1,
                    TipoServico=Dominio.Enums.TipoServico.Outros,
                    Data = "28/09/2018",
                    Horario = "11:00",
                    Duracao = 60,
                    Servico = new Servico()
                    {
                        Id = 1,
                        Nome ="Outros"
                    }
                },
            };
        }
    }
}
