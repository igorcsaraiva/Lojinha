using Loja.Domain.Shared;
using Loja.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Loja.Domain.Domain
{
    public class Pedidos : Entidade
    {
        public string Codigo { get; set; }
        public string ValorPedido => ValorTotalPedido().ValorFormatoTexto;
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<PedidoItem> PedidoItems { get; set; }

        public DateTime DataPedido { get; set; }

        public Pedidos()
        {
            Codigo = Guid.NewGuid().ToString();
            PedidoItems = new List<PedidoItem>();
            DataPedido = DateTime.Now;
        }

        public Pedidos(Cliente cliente, IEnumerable<PedidoItem> pedidoItems, int id) : base(id)
        {
            Cliente = cliente;
            PedidoItems = pedidoItems;
            DataPedido = DateTime.Now;
            Codigo = Guid.NewGuid().ToString();
            ID = id;
        }

        private Dinheiro ValorTotalPedido()
        {
            Dinheiro valor = 0;

            foreach (var item in PedidoItems)
                valor += item.TotalItemPedido;

            return valor;
        }

        public void AtualizarEstoque()
        {
            foreach (var item in PedidoItems)
            {
                item.Produto.Quantidade -= item.Quantidade;
            }
        }
    }
}
