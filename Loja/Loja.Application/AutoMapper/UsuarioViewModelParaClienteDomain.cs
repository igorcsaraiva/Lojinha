using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class UsuarioViewModelParaClienteDomain : Profile
    {
        public UsuarioViewModelParaClienteDomain()
        {
            CreateMap<UsuarioViewModel, Cliente>().ConstructUsing(c => new Cliente(c.CPF, c.DataNascimento, c.Codigo, c.Senha, c.Nome, c.TipoUsuario, c.ID));
        }
    }
}
