using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            _lojaContexto.Entry(Obj.Cliente).State = EntityState.Detached;
            foreach (var item in Obj.PedidoItems)
            {
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

        public async Task<Pedidos> BuscarPorId(int? id)
        {
            return await _lojaContexto.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<Pedidos>> BuscarTodos()
        {
            return await _lojaContexto.Pedidos.ToListAsync();
        }

        public void Remover(Pedidos Obj)
        {
            _lojaContexto.Pedidos.Remove(Obj);
            _lojaContexto.SaveChanges();
        }
    }
}
