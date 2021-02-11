using Loja.API.Services;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {

        private readonly IClienteAppSevicos _clienteAppSevicos;
        private readonly ServicoToken _servicoToken;

        public LoginController(IClienteAppSevicos clienteAppSevicos, ServicoToken servicoToken)
        {
            _clienteAppSevicos = clienteAppSevicos;
            _servicoToken = servicoToken;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("logar")]
        public async Task<ActionResult<UsuarioLoginViewModel>> Logar(string login, string senha)
        {
            var cliente = await _clienteAppSevicos.BuscarPeloLoginSenha(login, senha);

            if (cliente is null) return BadRequest("Cliente não consta na base");


            var token = _servicoToken.GerarToken(cliente);

            return Ok(new UsuarioLoginViewModel { ID = cliente.ID, Token = token });

        }

        
    }
}
