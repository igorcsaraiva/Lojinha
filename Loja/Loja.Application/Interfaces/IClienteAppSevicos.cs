using Loja.Application.ViewModels;
using Loja.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IClienteAppSevicos
    {
        Task<IEnumerable<UsuarioViewModel>> BuscarTodos();
        Task<UsuarioViewModel> BuscarPorId(int? id);
        Task<UsuarioViewModel> BuscarPeloLoginSenha(string login, string senha);
        IList<Erro> Adicionar(UsuarioViewModel clienteViewModel);
        IList<Erro> Atualizar(UsuarioViewModel clienteViewModel);
        IList<Erro> Remover(UsuarioViewModel clienteViewModel);
    }
}
