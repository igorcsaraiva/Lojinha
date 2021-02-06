using Loja.Application.Interfaces;
using Loja.Application.ViewModels;
using Loja.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Loja.Application.ViewModelValidation
{
    public class ValidarPedidoViewModelCadastro : IValidarView<PedidoViewModelCadastro>
    {
        public IList<Erro> Erros { get; private set; }

        public ValidarPedidoViewModelCadastro()
        {
            Erros = new List<Erro>();
        }
        public void Validar(PedidoViewModelCadastro Obj)
        {
            ValidarItensDoPedido(Obj);
        }

        private void ValidarItensDoPedido(PedidoViewModelCadastro obj)
        {
            if (obj.IdProdutosDoPedido is null || obj.QuantidadeDoPedido?.Length == 0)
                Erros.Add(new Erro { Propriedade = "IdProdutosDoPedido", MensagemErro = "Selecione um item da lista" });
            if (obj.ClienteDoPedido is null)
                Erros.Add(new Erro { Propriedade = "ClienteDoPedido", MensagemErro = "Selecione um cliente" });
            if(obj.IdProdutosDoPedido?.Length != obj.QuantidadeDoPedido?.Length)
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Produtos e quantidades estão inconsistentes" });
            if (obj.QuantidadeDoPedido.Where(x => x < 0).Count() > 0)
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Quantidade inválida" });

        }
    }
}
