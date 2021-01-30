using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Produto> BuscarPorId(int? id)
        {
            return await _lojaContexto.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IEnumerable<Produto>> BuscarTodos()
        {
            return await _lojaContexto.Produtos.ToListAsync();
        }

        public async Task<Produto> CodigoExiste(Produto Obj)
        {
            return await _lojaContexto.Produtos.Where(p => p.Codigo == Obj.Codigo)
                .Select(p => new Produto { ID = p.ID })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Produto> CodigoBarrasExiste(Produto Obj)
        {
            return await _lojaContexto.Produtos.Where(p => p.CodigoBarras.Codigo == Obj.CodigoBarras.Codigo)
                .Select(p => new Produto { ID = p.ID })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public void Remover(Produto Obj)
        {
            _lojaContexto.Produtos.Remove(Obj);
            _lojaContexto.SaveChanges();
        }
    }
}
