using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ClienteAppService : IClienteAppSevicos
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IValidarCliente _validarCliente;

        public ClienteAppService(IMapper mapper, IClienteRepositorio clienteRepositorio, IValidarCliente validarCliente)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
            _validarCliente = validarCliente;
        }

        public IList<Erro> Adicionar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            _validarCliente.ValidarCadastro(cliente);
            
            if (_validarCliente.Erros.Count() == 0)
                _clienteRepositorio.Adicionar(cliente);

            return _validarCliente.Erros;
        }

        public IList<Erro> Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            _validarCliente.ValidarEdicao(cliente);
           
            if (_validarCliente.Erros.Count() == 0)
                _clienteRepositorio.Atualizar(cliente);

            return _validarCliente.Erros;
        }

        public async Task<ClienteViewModel> BuscarPorId(int? id)
        {
            return _mapper.Map<ClienteViewModel>(await _clienteRepositorio.BuscarPorId(id));
        }

        public async Task<IEnumerable<ClienteViewModel>> BuscarTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepositorio.BuscarTodos());
        }

        public IList<Erro> Remover(ClienteViewModel clienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            _validarCliente.ValidarCadastro(cliente);

            if (_validarCliente.Erros.Count() == 0)
                _clienteRepositorio.Remover(cliente);

            return _validarCliente.Erros;
        }
    }
}
