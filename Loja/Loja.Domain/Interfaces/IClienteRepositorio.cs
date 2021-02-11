using Loja.Domain.Domain;
using System.Threading.Tasks;

namespace Loja.Domain.Interfaces
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        Task<Cliente> CpfExiste(Cliente Obj);
        Task<Cliente> CodigoExiste(Cliente Obj);
        Task<Cliente> BuscarPeloLoginSenha(string login,string senha);
    }
}
