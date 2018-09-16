using System;
using System.Collections.Generic;
using System.Linq;
using Viva.Estetica.Dominio;

namespace Viva.Estetica.InfraEstrutura
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        IEnumerable<Cliente> _clientes = null;

        public ClienteRepositorio(IEnumerable<Cliente> clientes)
        {
            if (clientes.Count() > 0)
            {
                _clientes = clientes;
            }
            else
            {
                ClienteMock();
            }
        }

        public IEnumerable<Cliente> Obter()
        {
            return _clientes;
        }

        public Cliente Obter(int id)
        {
            return _clientes.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Cliente> Inserir(Cliente cliente)
        {
            var newId = _clientes.Max(c => c.Id);
            cliente.Id = newId + 1;
            _clientes.ToList().Add(cliente);

            return _clientes;
        }

        public IEnumerable<Cliente> Atualizar(Cliente cliente)
        {
            _clientes.FirstOrDefault(c => c.Id.Equals(cliente.Id)).Nome = cliente.Nome;
            _clientes.FirstOrDefault(c => c.Id.Equals(cliente.Id)).Sobrenome = cliente.Sobrenome;
            _clientes.FirstOrDefault(c => c.Id.Equals(cliente.Id)).Documento = cliente.Documento;
            _clientes.FirstOrDefault(c => c.Id.Equals(cliente.Id)).Celular = cliente.Celular;

            return _clientes;
        }

        public IEnumerable<Cliente> Excluir(int id)
        {
            var item = _clientes.SingleOrDefault(r => r.Id.Equals(id));
            if (item != null) _clientes.ToList().Remove(item);
            return _clientes;
        }

        public void Dispose()
        {

        }

        private void ClienteMock()
        {
            //Telefone telefone1 = new Telefone() { DDI = 55, DDD = 11, Numero = "912349964" };
            //CPF rg1 = new CPF() { Numero = "21496194X" };
            //Telefone telefone2 = new Telefone() { DDI = 55, DDD = 11, Numero = "996123493" };
            //CPF rg2 = new CPF() { Numero = "54961940" };
            //Telefone telefone3 = new Telefone() { DDI = 55, DDD = 11, Numero = "963149771" };
            //CPF rg3 = new CPF() { Numero = "225496191" };

            _clientes = new List<Cliente>()
            {
                new Cliente { Id = 1, Nome = "Márcia",Sobrenome = "Freire", Documento = "426.398.098-55",                                Celular = "+55-11-95338-8758", Endereco = "Rua Manuel Bandeira, 13" },
                new Cliente { Id = 2, Nome = "Mario", Sobrenome = "de Andrade", Celular = "+55-12-996123493", Documento = "5.496.194-0", Endereco = "Rua Treze dos Seis" },
                new Cliente { Id = 3, Nome = "Julieta Castro", Sobrenome = "Sodré", Celular = "+55-11-963149771", Documento = "22.549.619-1", Endereco = "Av Carlos Gameleira" }
            };
        }
    }
}
