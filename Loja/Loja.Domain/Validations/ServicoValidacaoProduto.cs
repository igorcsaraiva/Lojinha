using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System.Collections.Generic;

namespace Loja.Domain.Validations
{
    public class ServicoValidacaoProduto : IValidarProduto
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public IList<Erro> Erros { get; private set; }

        public ServicoValidacaoProduto(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            Erros = new List<Erro>();
        }

        public void ValidarCadastro(Produto Obj)
        {
            CodigoExiste(Obj);
            CodigoBarrasExiste(Obj);
        }

        public void ValidarEdicao(Produto Obj)
        {
            ProdutoNaoExiste(Obj);
            CodigoExiste(Obj);
            CodigoBarrasExiste(Obj);
        }

        public void ValidarRemocao(Produto Obj)
        {
            ProdutoNaoExiste(Obj);
        }

        private void CodigoExiste(Produto produto)
        {
            var pro = _produtoRepositorio.CodigoExiste(produto).Result;

            if (pro != null && pro.ID != produto.ID)
                Erros.Add(new Erro { Propriedade = "Codigo", MensagemErro = "Código já cadastrado" });
        }

        private void CodigoBarrasExiste(Produto produto)
        {
            var pro = _produtoRepositorio.CodigoBarrasExiste(produto).Result;

            if (pro != null && pro.ID != produto.ID)
                Erros.Add(new Erro { Propriedade = "CodigoBarras", MensagemErro = "Código de barras já cadastrado" });
        }

        private void ProdutoNaoExiste(Produto produto)
        {
            if (_produtoRepositorio.BuscarPorId(produto.ID).Result == null)
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Esse produto não existe" });
        }
    }
}
