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
        private readonly IPedidoAppServicos _pedidoAppServicos;
        public PedidoController(IClienteAppSevicos clienteAppSevicos, IProdutoAppServicos produtoAppServico, IPedidoAppServicos pedidoAppServicos)
        {
            _clienteAppSevicos = clienteAppSevicos;
            _produtoAppServico = produtoAppServico;
            _pedidoAppServicos = pedidoAppServicos;
        }
        // GET: PedidoController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> ListarPedidos()
        {
            return PartialView("~/Views/Shared/_ViewListarPedidos.cshtml", await _pedidoAppServicos.BuscarTodos());
        }

        public async Task<PartialViewResult> ListarPedidosPorFiltro(DateTime? dataInicio, DateTime? dataFim, string valor = "")
        {
            return PartialView("~/Views/Shared/_ViewListarPedidos.cshtml", await _pedidoAppServicos.BuscarPedidosPorFiltro(valor,dataInicio,dataFim));
        }

        public async Task<PartialViewResult> ItemPedidoIndex(int? id)
        {
            return PartialView("~/Views/Shared/_ViewItensPedido.cshtml", await _pedidoAppServicos.BuscarItensDoPedido(id));
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            var pedidoViewModelCadastro = new PedidoViewModelCadastro();
            PreencherPedidoViewModelCadastro(pedidoViewModelCadastro);

            return View(pedidoViewModelCadastro);
        }

        private void PreencherPedidoViewModelCadastro(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
            pedidoViewModelCadastro.Clientes = _clienteAppSevicos.BuscarTodos().Result;
            pedidoViewModelCadastro.Produtos =  _produtoAppServico.BuscarTodos().Result;
        }

        // POST: PedidoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
            try
            {
                var erros = _pedidoAppServicos.Adicionar(pedidoViewModelCadastro);

                if (erros.Count > 0)
                {
                    foreach (var item in erros)
                    {
                        ModelState.AddModelError(item.Propriedade, item.MensagemErro);        
                    }
                    PreencherPedidoViewModelCadastro(pedidoViewModelCadastro);
                    return View(pedidoViewModelCadastro);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                PreencherPedidoViewModelCadastro(pedidoViewModelCadastro);
                return View(pedidoViewModelCadastro);
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
    }
}
