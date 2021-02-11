using System.Collections.Generic;

namespace Loja.Application.ViewModels
{
    public class PedidoViewModelCadastro
    {
        public IEnumerable<UsuarioViewModel> Clientes { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public int? ClienteDoPedido { get; set; }
        public int[] QuantidadeDoPedido { get; set; }
        public int[] IdProdutosDoPedido { get; set; }
    }
}
