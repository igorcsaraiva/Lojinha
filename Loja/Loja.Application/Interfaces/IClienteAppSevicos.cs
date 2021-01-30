using Loja.Application.ViewModels;
using Loja.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IClienteAppSevicos
    {
        Task<IEnumerable<ClienteViewModel>> BuscarTodos();
        Task<ClienteViewModel> BuscarPorId(int? id);
        IList<Erro> Adicionar(ClienteViewModel clienteViewModel);
        IList<Erro> Atualizar(ClienteViewModel clienteViewModel);
        IList<Erro> Remover(ClienteViewModel clienteViewModel);
    }
}
