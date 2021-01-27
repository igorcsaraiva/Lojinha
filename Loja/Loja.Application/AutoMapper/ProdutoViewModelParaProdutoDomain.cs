using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;
using System;

namespace Loja.Application.AutoMapper
{
    public class ProdutoViewModelParaProdutoDomain : Profile
    {
        public ProdutoViewModelParaProdutoDomain()
        {
            CreateMap<ProdutoViewModel, Produto>().ForMember(dest => dest.ValorDeVenda, opt => opt.MapFrom(src => decimal.Parse(src.ValorDeVenda)))
                .ConstructUsing(p => new Produto());
        }
    }
}
