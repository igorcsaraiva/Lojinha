using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IClienteAppSevicos _clienteAppSevicos;
        private readonly IProdutoAppServicos _produtoAppServico;
        public PedidoController(IClienteAppSevicos clienteAppSevicos, IProdutoAppServicos produtoAppServico)
        {
            _clienteAppSevicos = clienteAppSevicos;
            _produtoAppServico = produtoAppServico;
        }
        // GET: PedidoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            var pedidoViewModel = new PedidoViewModelCadastro();
            PreencherPedidoViewModel(pedidoViewModel);

            return View(pedidoViewModel);
        }

        private void PreencherPedidoViewModel(PedidoViewModelCadastro pedidoViewModel)
        {
            pedidoViewModel.Clientes = _clienteAppSevicos.BuscarTodos().Result;
            pedidoViewModel.Produtos = _produtoAppServico.BuscarTodos().Result;
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModelCadastro pedidoViewModel)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
            }

            PreencherPedidoViewModel(pedidoViewModel);

            return View(pedidoViewModel);
        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
