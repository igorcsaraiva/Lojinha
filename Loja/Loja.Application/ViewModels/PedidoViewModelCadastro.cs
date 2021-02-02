using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.ViewModels
{
    public class PedidoViewModelCadastro
    {
        public IEnumerable<ClienteViewModel> Clientes { get; set; }
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
        public int? ClienteDoPedido { get; set; }
        public int[] QuantidadeDoPedido { get; set; }
        public int[] IdProdutosDoPedido { get; set; }
    }
}
