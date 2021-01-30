using Loja.Application.ViewModels;
using Loja.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IProdutoAppServico
    {
        Task<IEnumerable<ProdutoViewModel>> BuscarTodos();
        Task<ProdutoViewModel> BuscarPorId(int id);
        IList<Erro> Adicionar(ProdutoViewModel produtoViewModel);
        IList<Erro> Atualizar(ProdutoViewModel produtoViewModel);
        IList<Erro> Remover(ProdutoViewModel produtoViewModel);
    }
}
