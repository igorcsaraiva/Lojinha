using Loja.Domain.Validations.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Loja.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [ValidarCodigoBarras]
        [DisplayName("Código de barras")]
        public string CodigoBarras { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [DisplayName("Valor de venda")]
        public string ValorDeVenda { get; set; }

        public int ID { get; set; }

        [Required]
        public int Quantidade { get; set; }
    }
}
