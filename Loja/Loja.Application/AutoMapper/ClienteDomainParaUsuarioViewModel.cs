using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class ClienteDomainParaUsuarioViewModel : Profile
    {
        public ClienteDomainParaUsuarioViewModel()
        {
            CreateMap<Cliente, UsuarioViewModel>();
        }
    }
}
