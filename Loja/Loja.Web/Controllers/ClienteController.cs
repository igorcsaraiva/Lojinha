using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppSevicos _clienteAppSevicos;
        public ClienteController(IClienteAppSevicos clienteAppSevicos)
        {
            _clienteAppSevicos = clienteAppSevicos;
        }
        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            return View(await _clienteAppSevicos.BuscarTodos());
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var erros = _clienteAppSevicos.Adicionar(clienteViewModel);
                    
                    if(erros.Count() > 0)
                    {
                        foreach (var item in erros)
                        {
                            ModelState.AddModelError(item.Propriedade, item.MensagemErro);
                        }

                        return View(clienteViewModel);
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException e)
                {
                    return BadRequest(e.InnerException);
                }
            }
            return View(clienteViewModel);
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
