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
        private readonly IProdutoAppServico _produtoAppServico;
        public PedidoController(IClienteAppSevicos clienteAppSevicos, IProdutoAppServico produtoAppServico)
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
            return View();
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModelCriar produtoViewModelCriar)
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

        [HttpGet]
        public JsonResult CarregarClientes()
        {
            var ListaCliente = _clienteAppSevicos.BuscarTodos().Result;

            return Json(new { ListaCliente });
        }

        [HttpGet]
        public JsonResult CarregarProdutos()
        {
            var ListaProduto = _produtoAppServico.BuscarTodos().Result;

            return Json(new { ListaProduto });
        }
    }
}
