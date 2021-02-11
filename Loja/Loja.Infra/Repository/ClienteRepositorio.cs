using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using Loja.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja.Infra.Repository
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly LojaContexto _lojaContexto;

        public ClienteRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
        }
        public void Adicionar(Cliente Obj)
        {
            _lojaContexto.Clientes.Add(Obj);
            _lojaContexto.SaveChanges();
        }

        public void Atualizar(Cliente Obj)
        {
            _lojaContexto.Clientes.Update(Obj);
            _lojaContexto.SaveChanges();
        }

        public async Task<Cliente> BuscarPeloLoginSenha(string login, string senha)
        {
            return await _lojaContexto.Clientes.AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(c => c.Codigo.ToString() == login && c.Senha == senha);
        }

        public async Task<Cliente> BuscarPorId(int? id)
        {
            return await _lojaContexto.Clientes.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<IEnumerable<Cliente>> BuscarTodos()
        {
            return await _lojaContexto.Clientes.ToListAsync();
        }

        public async Task<Cliente> CodigoExiste(Cliente Obj)
        {
            return await _lojaContexto.Clientes.Where(c => c.Codigo == Obj.Codigo)
                .Select(c => new Cliente { ID = c.ID })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Cliente> CpfExiste(Cliente Obj)
        {
            return await _lojaContexto.Clientes.Where(c => c.Cpf.Cpf == Obj.Cpf.Cpf)
                .Select(c => new Cliente { ID = c.ID })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public void Remover(Cliente Obj)
        {
            _lojaContexto.Clientes.Remove(Obj);
            _lojaContexto.SaveChanges();
        }
    }
}
