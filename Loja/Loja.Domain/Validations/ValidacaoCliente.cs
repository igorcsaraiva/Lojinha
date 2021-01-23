using FluentValidation;
using Loja.Domain.Domain;
using Loja.Domain.ValueObjects;
using System;

namespace Loja.Domain.Validations
{
    public class ValidacaoCliente : AbstractValidator<Cliente>
    {
        public ValidacaoCliente()
        {
            RuleFor(c => c.Codigo).NotEmpty().WithMessage("O campo código é obrigatório");

            RuleFor(c => c.Cpf).NotEmpty().WithMessage("O campo cpf é obrigatório");

            RuleFor(c => c.DataNascimento).NotEmpty().WithMessage("O campo data de nascimento é obrigatório")
                .Must(MenorDeIdade).WithMessage("O cliente deve ter mais de 18 anos");

            RuleFor(c => c.Senha).NotEmpty().WithMessage("O campo senha é obrigatório");
        }

        private static bool MenorDeIdade(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Now.AddYears(-18);
        }
    }
}
