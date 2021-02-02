using AutoMapper;
using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using Loja.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loja.Application.Services
{
    public class ProdutoAppService : IProdutoAppServicos
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IValidarProduto _validarProduto;

        public ProdutoAppService(IMapper mapper, IProdutoRepositorio produtoRepositorio, IValidarProduto validarProduto)
        {
            _mapper = mapper;
            _produtoRepositorio = produtoRepositorio;
            _validarProduto = validarProduto;
        }
        public IList<Erro> Adicionar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _validarProduto.ValidarCadastro(produto);

            if (_validarProduto.Erros.Count == 0)
                _produtoRepositorio.Adicionar(produto);

            return _validarProduto.Erros;
        }

        public IList<Erro> Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _validarProduto.ValidarEdicao(produto);

            if (_validarProduto.Erros.Count == 0)
                _produtoRepositorio.Atualizar(produto);

            return _validarProduto.Erros;
        }

        public async Task<ProdutoViewModel> BuscarPorId(int id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepositorio.BuscarPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> BuscarTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepositorio.BuscarTodos());
        }

        public IList<Erro> Remover(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            _validarProduto.ValidarRemocao(produto);

            if (_validarProduto.Erros.Count == 0)
                _produtoRepositorio.Remover(produto);

            return _validarProduto.Erros;
        }
    }
}
