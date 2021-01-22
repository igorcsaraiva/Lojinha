using Loja.Domain.Shared;
using System;

namespace Loja.Domain.ValueObjects
{
    public class CodigoBarras : ObjetosValor
    {
        private string codigo;
        public string Codigo
        {
            get => codigo;
            set
            {
                if (ValidaCodigoBarras(value))
                    codigo = value;
                else
                    throw new Exception("Código barras inválido");
            }
        }

        public CodigoBarras()
        {
        }

        private CodigoBarras(string codigo)
        {
            Codigo = codigo;
        }

        public static implicit operator CodigoBarras(string value) => new CodigoBarras(value);

        /// <summary>
        /// Por enquanto uma simples validação, mas pra frente implementar outras validação.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public static bool ValidaCodigoBarras(string codigo)
        {
            return codigo.Length >= 3;
        }
    }
}
