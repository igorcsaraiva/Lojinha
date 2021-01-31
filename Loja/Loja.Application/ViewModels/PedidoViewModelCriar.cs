using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Loja.Application.ViewModels
{
    public class PedidoViewModelCriar
    {
        [Required(ErrorMessage ="Selecione um cliente")]
        public int ClienteID { get; set; }

        [Required]
        public int[] ProdutosID { get; set; }
       
        [Required]
        public int[] Quantidade { get; set; }
    }
}
