using System.Collections.Generic;
using System.Linq;
using Viva.Estetica.Dominio;

namespace Viva.Estetica.InfraEstrutura
{
    public class ClienteAplicacao : IAplicacao<Cliente>
    {
        private readonly IRepositorio<Cliente> _clienteRepositorio;

        public ClienteAplicacao(IRepositorio<Cliente> repositorio)
        {
            _clienteRepositorio = repositorio;
        }

        public IEnumerable<Cliente> Obter()
        {
            return _clienteRepositorio.Obter().ToList();
        }

        public Cliente Obter(int id)
        {
            return _clienteRepositorio.Obter(id);
        }

        public IEnumerable<Cliente> Inserir(Cliente cliente)
        {
            return _clienteRepositorio.Inserir(cliente);
        }

        public IEnumerable<Cliente> Atualizar(Cliente cliente)
        {
            return _clienteRepositorio.Atualizar(cliente);
        }

        public IEnumerable<Cliente> Excluir(int id)
        {
            return _clienteRepositorio.Excluir(id);
        }
    }
}
