using Loja.Domain.Shared;
using Loja.Domain.ValueObjects;

namespace Loja.Domain.Domain
{
    public class Produto : Entidade
    {
        public int Codigo { get; set; }
        public CodigoBarras CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public Dinheiro ValorDeVenda { get; set; }
        public int Quantidade { get; set; }

        public Produto()
        {
        }

        public Produto(int codigo, CodigoBarras codigoBarras, string descricao, Dinheiro valorDeVenda, int quantidade, int id) : base(id)
        {
            Codigo = codigo;
            CodigoBarras = codigoBarras;
            Descricao = descricao;
            ValorDeVenda = valorDeVenda;
            ID = id;
            Quantidade = quantidade;
        }

        public bool QuantidadeValida(int quantidadeRequisitada)
        {
            return Quantidade >= quantidadeRequisitada;
        }
    }
}
