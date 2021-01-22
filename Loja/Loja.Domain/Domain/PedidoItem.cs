using Loja.Domain.Shared;
using Loja.Domain.ValueObjects;

namespace Loja.Domain.Domain
{
    public class PedidoItem : Entidade
    {
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public Dinheiro TotalItemPedido => Produto.ValorDeVenda * Quantidade;

        public PedidoItem()
        {
        }

        public PedidoItem(int id, int quantidade, Produto produto) : base(id)
        {
            Quantidade = quantidade;
            Produto = produto;
        }

        public PedidoItem(int quantidade, Produto produto)
        {
            Quantidade = quantidade;
            Produto = produto;
        }
    }
}
