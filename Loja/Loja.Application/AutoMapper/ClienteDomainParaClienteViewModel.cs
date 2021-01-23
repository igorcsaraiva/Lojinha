using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class ClienteDomainParaClienteViewModel : Profile
    {
        public ClienteDomainParaClienteViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
