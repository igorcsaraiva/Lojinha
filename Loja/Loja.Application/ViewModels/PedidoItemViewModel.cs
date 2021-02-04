using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Loja.Application.ViewModels
{
    public class PedidoItemViewModel
    {
        public int ID { get; set; }
        public int IDProduto { get; set; }
        public int IDPedido { get; set; }
        public int Quantidade { get; set; }

        [DisplayName("Código")]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        
        [DisplayName("Valor unitario")]
        public string ValorUnitario { get; set; }

        [DisplayName("Valor")]
        public string TotalItem { get; set; }
    }
}
