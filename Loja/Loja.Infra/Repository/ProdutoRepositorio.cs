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
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly LojaContexto _lojaContexto;

        public ProdutoRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
        }
        public void Adicionar(Produto Obj)
        {
            _lojaContexto.Produtos.Add(Obj);
            _lojaContexto.SaveChanges();
        }

        public void Atualizar(Produto Obj)
        {
            _lojaContexto.Produtos.Update(Obj);
            _lojaContexto.SaveChanges();
        }

        public async Task<Produto> BuscarPorId(int id)
        {
            return await _lojaContexto.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<Produto>> BuscarTodos()
        {
            return await _lojaContexto.Produtos.ToListAsync();
        }

        public void Remover(Produto Obj)
        {
            _lojaContexto.Produtos.Remove(Obj);
            _lojaContexto.SaveChanges();
        }
    }
}
