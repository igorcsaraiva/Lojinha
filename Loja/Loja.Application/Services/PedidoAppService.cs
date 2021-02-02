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

        public PedidoAppService(IMontarPedido montarPedido, IPedidosRepositorio pedidosRepositorio, IValidarPedido validarPedido)
        {
            _montarPedido = montarPedido;
            _pedidosRepositorio = pedidosRepositorio;
            _validarPedido = validarPedido;
        }

        public IList<Erro> Adicionar(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
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

        public Task<PedidoViewModelCadastro> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PedidoViewModelCadastro>> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public IList<Erro> Remover(PedidoViewModelCadastro pedidoViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
