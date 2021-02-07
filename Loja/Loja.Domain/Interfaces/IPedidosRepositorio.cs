using Loja.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IPedidosRepositorio : IRepositorioBase<Pedidos>
    {
        Task<IEnumerable<PedidoItem>> BuscarItensDoPedido(int? id);

        Task<IEnumerable<Pedidos>> BuscarPedidosPorFiltro(string valor, DateTime? dataInicio, DateTime? dataFim);
    }
}
