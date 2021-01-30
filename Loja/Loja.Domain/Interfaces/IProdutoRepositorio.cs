using Loja.Domain.Domain;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        Task<Produto> CodigoBarrasExiste(Produto Obj);
        Task<Produto> CodigoExiste(Produto Obj);
    }
}
