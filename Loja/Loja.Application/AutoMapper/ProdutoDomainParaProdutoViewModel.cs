using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class ProdutoDomainParaProdutoViewModel : Profile
    {
        public ProdutoDomainParaProdutoViewModel()
        {
            CreateMap<Produto, ProdutoViewModel>().ForMember(dest => dest.CodigoBarras, opt => opt.MapFrom(src => src.CodigoBarras.Codigo));
        }
    }
}
