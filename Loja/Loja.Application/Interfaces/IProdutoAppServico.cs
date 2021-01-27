using Loja.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IProdutoAppServico
    {
        Task<IEnumerable<ProdutoViewModel>> BuscarTodos();
        Task<ProdutoViewModel> BuscarPorId(int id);
        void Adicionar(ProdutoViewModel produtoViewModel);
        void Atualizar(ProdutoViewModel produtoViewModel);
        void Remover(ProdutoViewModel produtoViewModel);
    }
}
