using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Loja.Infra.Repository
{
    public class PedidoRepositorio : IPedidosRepositorio
    {
        private readonly LojaContexto _lojaContexto;

        public PedidoRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
        }

        public void Adicionar(Pedidos Obj)
        {
            Obj.AtualizarEstoque();
            _lojaContexto.Entry(Obj.Cliente).State = EntityState.Detached;
            foreach (var item in Obj.PedidoItems)
            {
                _lojaContexto.Produtos.Update(item.Produto);
                _lojaContexto.PedidoItem.Add(item);
            }
            _lojaContexto.Entry(Obj).State = EntityState.Added;
            _lojaContexto.SaveChanges();
        }

        public void Atualizar(Pedidos Obj)
        {
            _lojaContexto.Pedidos.Update(Obj);
            _lojaContexto.SaveChanges();
        }

        public async Task<IEnumerable<PedidoItem>> BuscarItensDoPedido(int? id)
        {
            return await _lojaContexto.PedidoItem.Where(pi => pi.PedidosID == id)
                .Include(p => p.Produto)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Pedidos> BuscarPorId(int? id)
        {
            return await _lojaContexto.Pedidos.Include(p => p.Cliente)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<Pedidos>> BuscarTodos()
        {
            return await _lojaContexto.Pedidos.Include(p => p.Cliente)
               .Include(p => p.PedidoItems)
               .ThenInclude(pi => pi.Produto)
               .ToListAsync();
        }

        public async Task<IEnumerable<Pedidos>> BuscarPedidosPorFiltro(string valor, DateTime? dataInicio, DateTime? dataFim)
        {
            var pedidosPorCodigoOuCpfCliente = PedidosPorCodigoOuCpfCliente(valor);

            var pedidosEntreDatas = PedidosEntreDatas(dataInicio, dataFim);

            if (dataInicio is null && dataFim is null)
                return await pedidosPorCodigoOuCpfCliente.ToListAsync();
            else if (valor is null)
                return await pedidosEntreDatas.ToListAsync();
            else
                return await pedidosPorCodigoOuCpfCliente.Where(p => p.DataPedido >= dataInicio && p.DataPedido <= dataFim).ToListAsync();
        }

        private IQueryable<Pedidos> PedidosPorCodigoOuCpfCliente(string valor)
        {
            return _lojaContexto.Pedidos.Include(p => p.Cliente)
                   .Include(p => p.PedidoItems)
                   .Where(p => p.Cliente.Cpf.Cpf == valor || p.Codigo == valor);
        }

        private IQueryable<Pedidos> PedidosEntreDatas(DateTime? dataInicio, DateTime? dataFim)
        {
            return _lojaContexto.Pedidos.Include(p => p.Cliente)
                   .Include(p => p.PedidoItems)
                   .Where(p => p.DataPedido >= dataInicio && p.DataPedido <= dataFim);
        }

        public void Remover(Pedidos Obj)
        {
            _lojaContexto.Pedidos.Remove(Obj);
            _lojaContexto.SaveChanges();
        }

     
    }
}
