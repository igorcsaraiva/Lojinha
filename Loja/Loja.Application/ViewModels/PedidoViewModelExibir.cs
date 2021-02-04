using System;
using System.ComponentModel;

namespace Loja.Application.ViewModels
{
    public class PedidoViewModelExibir
    {
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Cliente")]
        public string NomeCliente { get; set; }

        public int IdCliente { get; set; }
        public int ID { get; set; }

        [DisplayName("Data do pedido")]
        public DateTime DataPedido { get; set; }
    }
}
