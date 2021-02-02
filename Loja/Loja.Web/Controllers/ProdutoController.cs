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
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppServicos _produtoAppServico;
        public ProdutoController(IProdutoAppServicos produtoAppServico)
        {
            _produtoAppServico = produtoAppServico;
        }
        // GET: ProdutoController
        public async Task<ActionResult> Index()
        {
            return View(await _produtoAppServico.BuscarTodos());
        }

        // GET: ProdutoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdutoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var erros = _produtoAppServico.Adicionar(produtoViewModel);
                   
                    if (erros.Count() > 0)
                    {
                        foreach (var item in erros)
                        {
                            ModelState.AddModelError(item.Propriedade, item.MensagemErro);
                        }

                        return View(produtoViewModel);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            return View(produtoViewModel);

        }

        // GET: ProdutoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdutoController/Edit/5
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

        // GET: ProdutoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdutoController/Delete/5
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
