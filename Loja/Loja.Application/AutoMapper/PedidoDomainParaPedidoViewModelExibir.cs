using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class PedidoDomainParaPedidoViewModelExibir : Profile
    {
        public PedidoDomainParaPedidoViewModelExibir()
        {
            CreateMap<Pedidos, PedidoViewModelExibir>().ForMember(dest => dest.NomeCliente, ori => ori.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.IdCliente, ori => ori.MapFrom(src => src.Cliente.ID));
        }
    }
}
