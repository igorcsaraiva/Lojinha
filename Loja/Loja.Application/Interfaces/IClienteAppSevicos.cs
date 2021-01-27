using FluentValidation.Results;
using Loja.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IClienteAppSevicos
    {
        Task<IEnumerable<ClienteViewModel>> BuscarTodos();
        Task<ClienteViewModel> BuscarPorId(int id);
        void Adicionar(ClienteViewModel clienteViewModel);
        void Atualizar(ClienteViewModel clienteViewModel);
        void Remover(ClienteViewModel clienteViewModel);
    }
}
