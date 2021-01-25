using Loja.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Validations.Annotations
{
    public class ValidarCpf : ValidationAttribute
    {
        public ValidarCpf()
        {
            ErrorMessage = "CPF Inválido";
        }
        public override bool IsValid(object value)
        {
            if (value is null)
                return false;

            var cpf = (string)value;

            return CPF.ValidarCPF(cpf);
        }
    }
}
