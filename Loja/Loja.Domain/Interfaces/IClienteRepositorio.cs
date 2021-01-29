using Loja.Domain.Domain;

namespace Loja.Domain.Interfaces
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        bool CpfExiste(Cliente Obj);
        bool CodigoExiste(Cliente Obj);
    }
}
