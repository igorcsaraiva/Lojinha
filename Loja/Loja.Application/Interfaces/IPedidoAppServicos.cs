using Loja.Application.ViewModels;
using Loja.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application.Interfaces
{
    public interface IPedidoAppServicos
    {
        Task<IEnumerable<PedidoViewModelCadastro>> BuscarTodos();
        Task<PedidoViewModelCadastro> BuscarPorId(int id);
        IList<Erro> Adicionar(PedidoViewModelCadastro pedidoViewModel);
        IList<Erro> Atualizar(PedidoViewModelCadastro pedidoViewModel);
        IList<Erro> Remover(PedidoViewModelCadastro pedidoViewModel);
    }
}
