using Loja.Domain.Shared;
using Loja.Domain.ValueObjects;

namespace Loja.Domain.Domain
{
    public class PedidoItem : Entidade
    {
        public int Quantidade { get; set; }
        public int PedidosID { get; set; }
        public Produto Produto { get; set; }
        public Dinheiro TotalItemPedido => ValorProdutoNessePedido * Quantidade;
        public Dinheiro ValorProdutoNessePedido { get; set; }

        public PedidoItem()
        {
        }

        public PedidoItem(int id, int quantidade, Produto produto) : base(id)
        {
            Quantidade = quantidade;
            Produto = produto;
        }

        public PedidoItem(int quantidade, Produto produto, Dinheiro valorProdutoNessePedido)
        {
            Quantidade = quantidade;
            Produto = produto;
            ValorProdutoNessePedido = valorProdutoNessePedido;
        }
    }
}
