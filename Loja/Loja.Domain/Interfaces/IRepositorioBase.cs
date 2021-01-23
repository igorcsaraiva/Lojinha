using Loja.Domain.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IRepositorioBase<T> where T : Entidade
    {
        Task<T> BuscarPorId(int id);
        Task<IEnumerable<T>> BuscarTodos();
        void Adicionar(T Obj);
        void Remover(T Obj);
        void Atualizar(T Obj);
    }
}
