using Loja.Domain.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace Loja.Application.Annotations
{
    public class ValidarSeMaiorDeIdade : ValidationAttribute
    {
        public ValidarSeMaiorDeIdade()
        {
            ErrorMessage = "Deve ser maior que 18 anos";
        }

        public override bool IsValid(object value)
        {
            if (value is null)
                return false;

            var data = (DateTime)value;

            Cliente cliente = new Cliente();
            cliente.DataNascimento = data;

            return cliente.MaiorDeIdade();
        }
    }
}
