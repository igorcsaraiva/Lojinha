using Loja.Application.ViewModels;
using Loja.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IClienteAppSevicos
    {
        Task<IEnumerable<ClienteViewModel>> BuscarTodos();
        Task<ClienteViewModel> BuscarPorId(int id);
        IList<Erro> Adicionar(ClienteViewModel clienteViewModel);
        void Atualizar(ClienteViewModel clienteViewModel);
        void Remover(ClienteViewModel clienteViewModel);
        bool CpfExiste(ClienteViewModel clienteViewModel);
    }
}
