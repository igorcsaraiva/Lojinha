using AutoMapper;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;

namespace Loja.Application.AutoMapper
{
    public class ClienteViewModelParaClienteDomain : Profile
    {
        public ClienteViewModelParaClienteDomain()
        {
            CreateMap<ClienteViewModel, Cliente>().ConstructUsing(c => new Cliente(c.CPF, c.DataNascimento, c.Codigo, c.Senha, c.Nome, c.ID));
        }
    }
}
