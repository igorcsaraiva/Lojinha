using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Loja.Domain.Validations
{
    public class ServicoValidacaoPedido : IValidarPedido
    {
        public IList<Erro> Erros { get; private set; }
        public ServicoValidacaoPedido()
        {
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
