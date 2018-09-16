using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Viva.Estetica.Dominio;
using Viva.Estetica.InfraEstrutura;

namespace Viva.Estetica.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IAplicacao<Cliente> _clienteAplicacao = null;
        private IList<Cliente> _clientes = null;

        public ClientController(IAplicacao<Cliente> aplicacao)
        {
            _clienteAplicacao = aplicacao;

            if (_clientes == null)
            {
                ObterClientes(0);
            }
        }

        public ActionResult Index()
        {
            if (TempData["Clientes"] != null)
            {
                _clientes = TempData["Clientes"] as List<Cliente>;
            }
            return View(_clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Titulo = "Inclusão de Cliente";
            ViewBag.Edicao = 1;
            return View("Edit");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            TempData["Clientes"] = _clienteAplicacao.Inserir(cliente);

            return RedirectToAction("Index", "Client");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Titulo = "Alteração de Cliente";
            ViewBag.Edicao = 1;

            Cliente cli = new Cliente();

            if (TempData["Clientes"] != null)
            {
                _clientes = TempData["Clientes"] as List<Cliente>;
            }

            cli = _clientes.Where(c => c.Id.Equals(id)).FirstOrDefault() as Cliente;

            return View(cli);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            TempData["Clientes"] = _clienteAplicacao.Atualizar(cliente);

            return RedirectToAction("Index", "Client");
        }

        public ActionResult Details(int id)
        {
            ViewBag.Titulo = "Consulta de Cliente";
            ViewBag.Edicao = 0;

            Cliente cli = new Cliente();
            cli = _clientes.Where(c => c.Id.Equals(id)).FirstOrDefault() as Cliente;

            return View("Edit", cli);
        }

        public ActionResult Delete(Cliente cliente)
        {
            var item = _clientes.SingleOrDefault(r => r.Id.Equals(cliente.Id));
            if (item != null) _clientes.Remove(item);

            TempData["Clientes"] = _clientes;

            return RedirectToAction("Index", "Client");
        }

        private IList<Cliente> ObterClientes(int id = 0)
        {
            _clientes = _clienteAplicacao.Obter().ToList();

            if (id > 0)
            {
                _clientes = _clientes.Where(c => c.Id.Equals(id)).ToList();
            }

            return _clientes;
        }
    }
}