using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ClienteAppService : IClienteAppSevicos
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteAppService(IMapper mapper, IClienteRepositorio clienteRepositorio)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }

        public void Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            _clienteRepositorio.Atualizar(cliente);
        }

        public async Task<ClienteViewModel> BuscarPorId(int id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepositorio.BuscarPorId(id));
        }

        public async Task<IEnumerable<ClienteViewModel>> BuscarTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepositorio.BuscarTodos());
        }

        public void Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            _clienteRepositorio.Adicionar(cliente);
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
