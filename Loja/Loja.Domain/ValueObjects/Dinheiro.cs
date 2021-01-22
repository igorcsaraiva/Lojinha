using Loja.Domain.Shared;
using System;

namespace Loja.Domain.ValueObjects
{
    public class Dinheiro : ObjetosValor
    {
        public decimal Real => Convert.ToDecimal(Centavos) / 100;

        public string ValorFormatoTexto => RetornarValor();

        private long Centavos { get; set; }

        public string Valor
        {
            get => Real + "";
            set
            {
                Centavos = (long)(Convert.ToDecimal(value) * 100);
            }
        }

        public Dinheiro()
        {
        }

        private Dinheiro(decimal valor)
        {
            if (valor >= long.MaxValue / 100 || valor <= long.MinValue / 100)
                throw new Exception("Valor acima ou abaixo do suportado");

            Centavos = (long)(valor * 100);
        }

        public static implicit operator Dinheiro(decimal valor) => new Dinheiro(valor);

        private string RetornarValor()
        {
            var valor = (Convert.ToDecimal(Centavos) / 100) + string.Empty;
            return valor;
        }
        public override string ToString()
        {
            return RetornarValor();
        }

        public decimal[] AlocarDinheiroEmPArcelas(int parcelas)
        {
            var Parcelas = new decimal[parcelas];

            decimal ValorParcela = Centavos / parcelas;

            for (int i = 0; i < Parcelas.Length - 1; i++)
                Parcelas[i] = (Math.Round(ValorParcela, 0)) / 100;

            Parcelas[Parcelas.Length - 1] = (Centavos - (Math.Round(ValorParcela, 0) * (parcelas - 1))) / 100;

            return Parcelas;
        }

        // Sobrecarga de operadores de adição
        #region Adição
        public static Dinheiro operator +(Dinheiro d1, Dinheiro d2)
        {
            if (d1 != null && d2 != null)
                return new Dinheiro(d1.Real + d2.Real);

            return null;
        }

        public static Dinheiro operator +(decimal valor, Dinheiro d1)
        {
            if (d1 != null)
            {
                return new Dinheiro(d1.Real + valor);
            }
            return null;
        }

        public static Dinheiro operator +(Dinheiro d1, decimal valor)
        {
            if (d1 != null)
            {
                return new Dinheiro(d1.Real + valor);
            }
            return null;
        }
        #endregion

        // Sobrecarga de operadores de subtração
        #region Subtração
        public static Dinheiro operator -(Dinheiro d1, Dinheiro d2)
        {
            if (d1 != null && d2 != null)
                return new Dinheiro(d1.Real - d2.Real);

            return null;
        }
        public static Dinheiro operator -(decimal valor, Dinheiro d1)
        {
            if (d1 != null)
            {
                return new Dinheiro(d1.Real - valor);
            }
            return null;
        }
        public static Dinheiro operator -(Dinheiro d1, decimal valor)
        {
            if (d1 != null)
            {
                return new Dinheiro(d1.Real - valor);
            }
            return null;
        }
        #endregion

        // Sobrecarga de operadores de multiplicação
        #region Multiplicação
        public static Dinheiro operator *(Dinheiro d1, decimal parcela)
        {
            if (d1 != null)
                return new Dinheiro(d1.Real * parcela);

            return null;
        }
        public static Dinheiro operator *(decimal parcela, Dinheiro d1)
        {
            if (d1 != null)
                return new Dinheiro(d1.Real * parcela);

            return null;
        }
        #endregion

        public static bool FormatoValido(string valor)
        {
            decimal result;
            if (decimal.TryParse(valor, out result))
                return true;

            return false;
        }
    }
}
