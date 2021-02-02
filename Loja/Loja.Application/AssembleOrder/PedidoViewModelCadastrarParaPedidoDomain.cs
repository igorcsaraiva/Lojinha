using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loja.Application.AssembleOrder
{
    public class PedidoViewModelCadastrarParaPedidoDomain : IMontarPedido
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public PedidoViewModelCadastrarParaPedidoDomain(IProdutoRepositorio produtoRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }
        public Pedidos Montar(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
            var Pedido = new Pedidos();
            Pedido.PedidoItems = MontarItensDoPedido(pedidoViewModelCadastro);
            Pedido.Cliente = AssociarCliente(pedidoViewModelCadastro);

            return Pedido;
        }

        private Cliente AssociarCliente(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
            return _clienteRepositorio.BuscarPorId(pedidoViewModelCadastro.ClienteDoPedido).Result;
        }

        private IEnumerable<PedidoItem> MontarItensDoPedido(PedidoViewModelCadastro pedidoViewModelCadastro)
        {
            var pedidoItem = new List<PedidoItem>();
            
            var produtos = _produtoRepositorio.ProdutosSelecionados(pedidoViewModelCadastro.IdProdutosDoPedido).Result;

            for (int i = 0; i < produtos.Count(); i++)
            {
                pedidoItem.Add(new PedidoItem(pedidoViewModelCadastro.QuantidadeDoPedido[i], produtos.ElementAt(i),produtos.ElementAt(i).ValorDeVenda.Real));
            }

            return pedidoItem;
        }
    }
}
