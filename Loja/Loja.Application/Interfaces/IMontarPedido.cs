using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.Interfaces
{
    public interface IMontarPedido
    {
        Pedidos Montar(PedidoViewModelCadastro pedidoViewModelCadastro);
    }
}
