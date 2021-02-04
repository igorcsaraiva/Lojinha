using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class PedidoAppService : IPedidoAppServicos
    {
        private readonly IMontarPedido _montarPedido;
        private readonly IPedidosRepositorio _pedidosRepositorio;
        private readonly IValidarPedido _validarPedido;
        private readonly IValidarView<PedidoViewModelCadastro> _validarView;
        private readonly IMapper _maper;

        public PedidoAppService(IMontarPedido montarPedido, IPedidosRepositorio pedidosRepositorio, IValidarPedido validarPedido, IValidarView<PedidoViewModelCadastro> validarView, IMapper mapper)
        {
            _montarPedido = montarPedido;
            _pedidosRepositorio = pedidosRepositorio;
            _validarPedido = validarPedido;
            _validarView = validarView;
            _maper = mapper;
        }

        public IList<Erro> Adicionar(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
            _validarView.Validar(pedidoViewModelCadastro);
            if (_validarView.Erros.Count > 0)
                return _validarView.Erros;
            
            var Pedido = _montarPedido.Montar(pedidoViewModelCadastro);
            _validarPedido.ValidarCadastro(Pedido);

            if (_validarPedido.Erros.Count == 0)
                _pedidosRepositorio.Adicionar(Pedido);

            return _validarPedido.Erros;
        }

        public IList<Erro> Atualizar(PedidoViewModelCadastro pedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PedidoItemViewModel>> BuscarItensDoPedido(int? id)
        {
            return _maper.Map<IEnumerable<PedidoItemViewModel>>(await _pedidosRepositorio.BuscarItensDoPedido(id));
        }

        public Task<PedidoViewModelCadastro> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PedidoViewModelExibir>> BuscarTodos()
        {
            return _maper.Map<IEnumerable<PedidoViewModelExibir>>(await _pedidosRepositorio.BuscarTodos());
        }

        public IList<Erro> Remover(PedidoViewModelCadastro pedidoViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
