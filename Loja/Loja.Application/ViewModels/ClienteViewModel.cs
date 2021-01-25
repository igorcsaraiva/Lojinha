using Loja.Domain.Validations.Annotations;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Loja.Application.ViewModels
{
    public class ClienteViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo código é obrigatório")]
        [DisplayName("Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data nascimento")]
        [ValidarSeMaiorDeIdade]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo cpf é obrigatório")]
        [ValidarCpf]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Senha")]
        public string Senha { get; set; }

    }
}
