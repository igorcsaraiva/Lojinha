using Loja.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Loja.Domain.Validations.Annotations
{
    public class ValidarCodigoBarras : ValidationAttribute
    {
        public ValidarCodigoBarras()
        {
            ErrorMessage = "Código de barras inválido";
        }

        public override bool IsValid(object value)
        {
            if (value is null)
                return false;

            var codigo = (string)value;

            return CodigoBarras.ValidaCodigoBarras(codigo);
        }
    }
}
