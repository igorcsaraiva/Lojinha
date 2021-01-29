using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ProdutoAppService : IProdutoAppServico
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoAppService(IMapper mapper, IProdutoRepositorio produtoRepositorio)
        {
            _mapper = mapper;
            _produtoRepositorio = produtoRepositorio;
        }
        public void Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepositorio.Adicionar(produto);
        }

        public void Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepositorio.Atualizar(produto);
        }

        public async Task<ProdutoViewModel> BuscarPorId(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepositorio.BuscarPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> BuscarTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepositorio.BuscarTodos());
        }

        public void Remover(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepositorio.Remover(produto);
        }
    }
}
