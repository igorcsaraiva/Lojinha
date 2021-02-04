using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class PedidoItemDomainParaPedidoItemViewModel : Profile
    {
        public PedidoItemDomainParaPedidoItemViewModel()
        {
            CreateMap<PedidoItem, PedidoItemViewModel>().ForMember(dest => dest.Descricao, ori => ori.MapFrom(src => src.Produto.Descricao))
                .ForMember(dest => dest.IDProduto, ori => ori.MapFrom(src => src.Produto.ID))
                .ForMember(dest => dest.IDPedido, ori => ori.MapFrom(src => src.PedidosID))
                .ForMember(dest => dest.TotalItem, ori => ori.MapFrom(src => src.TotalItemPedido))
                .ForMember(dest => dest.ValorUnitario, ori => ori.MapFrom(src => src.ValorProdutoNessePedido.Valor))
                .ForMember(dest => dest.Codigo, ori => ori.MapFrom(src => src.Produto.Codigo));
        }
    }
}
