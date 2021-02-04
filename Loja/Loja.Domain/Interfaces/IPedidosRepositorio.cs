using Loja.Domain.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IPedidosRepositorio : IRepositorioBase<Pedidos>
    {
        Task<IEnumerable<PedidoItem>> BuscarItensDoPedido(int? id);
    }
}
