using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Loja.Application.ViewModels
{
    public class PedidoViewModelCadastrar
    {
        public int IdPedido { get; set; }
        public string Codigo { get; set; }
        public string valorPedido { get; set; }
        public string NomeCliente { get; set; }
        public int IdCliente { get; set; }
        public DateTime DataPedido { get; set; }
    }
}
