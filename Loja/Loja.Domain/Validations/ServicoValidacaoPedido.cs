using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Loja.Domain.Validations
{
    public class ServicoValidacaoPedido : IValidarPedido
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;
        public IList<Erro> Erros { get; private set; }
        public ServicoValidacaoPedido(IProdutoRepositorio produtoRepositorio, IClienteRepositorio clienteRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _clienteRepositorio = clienteRepositorio;
            Erros = new List<Erro>();
        }
        public void ValidarCadastro(Pedidos Obj)
        {
            ValidarItensDoPedido(Obj);
        }

        private void ValidarItensDoPedido(Pedidos pedidos)
        {
            if (pedidos.PedidoItems is null)
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Não foi possivel cadastrar o pedido pois o mesmo não tem produtos associados a ele" });
           
            if (pedidos.PedidoItems.Select(pi => pi.ValidarQuantidadeNoEstoque()).Contains(false))
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Quantidade pedida maior do que quantidade em estoque" });

            if(pedidos.PedidoItems.Select(pi=> pi.ValidarQauntidadeMaiorQueZero()).Contains(false))
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Quantidade pedida não é valida" });
        }

        public void ValidarEdicao(Pedidos Obj)
        {
            throw new NotImplementedException();
        }

        public void ValidarRemocao(Pedidos Obj)
        {
            throw new NotImplementedException();
        }
    }
}
