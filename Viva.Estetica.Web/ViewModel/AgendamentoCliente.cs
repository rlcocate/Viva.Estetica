using System;
using Viva.Estetica.Dominio;

namespace Viva.Estetica.Web.ViewModel
{
    public class AgendamentoCliente
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public DateTime Horario { get; set; }

        public Cliente Cliente { get; set; }

        public AgendamentoCliente()
        {
            Cliente = new Cliente();
        }
    }
}