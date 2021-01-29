using Loja.Domain.Shared;
using System;

namespace Loja.Domain.ValueObjects
{
    public class CPF : ObjetosValor, IEquatable<CPF>
    {
        private const int NumeroPadraoDaDivisao = 11;
        private const int TamanhoDoCpfComMascara = 14;
        private const int TamanhoDoCpfSemMascara = 11;
        private const char ponto = '.';
        private const char traco = '-';

        private string cpf;
        public string CpfComMascara => AtribuirMascaraCPF();
        public string Cpf
        {
            get => cpf;
            set
            {
                if (ValidarCPF(value))
                    cpf = RetirarMascaraCPF(value);
                else
                    throw new Exception("Cpf inválido");
            }
        }

        public CPF()
        {
        }

        private CPF(string cpf)
        {
            Cpf = cpf;
        }
        public static implicit operator CPF(string value) => new CPF(value);

        /// <summary>
        /// Retorna falso se um cpf não for valido
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool ValidarCPF(string cpf)
        {
            Span<int> NumerosDoCpf = stackalloc int[11];

            if ((cpf?.Length == TamanhoDoCpfSemMascara || cpf?.Length == TamanhoDoCpfComMascara) && VerificaSeTodosOsDigitosSaoDiferentes(cpf))
            {
                int j = 0;
                for (int i = 0; i < cpf.Length; i++)
                {
                    if (cpf[i] != ponto && cpf[i] != traco)
                    {
                        NumerosDoCpf[j] = cpf[i] - '0';
                        j++;
                    }
                }
            }
            else
                return false;

            ReadOnlySpan<int> MultiplicadoresParaValidacaoPrimeiroDigito = stackalloc int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            ReadOnlySpan<int> MultiplicadoresParaValidacaoSegundoDigito = stackalloc int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var primeiroDigitoVerificador = CalcularDigitosVerificadores(NumerosDoCpf, MultiplicadoresParaValidacaoPrimeiroDigito);
            var segundoDigitoVerificador = CalcularDigitosVerificadores(NumerosDoCpf, MultiplicadoresParaValidacaoSegundoDigito, 10);

            if (primeiroDigitoVerificador == NumerosDoCpf[9] && segundoDigitoVerificador == NumerosDoCpf[10])
                return true;

            return false;
        }

        /// <summary>
        /// Calcula os digitos verificadores do cpf de acordo com a regra "https://pt.wikipedia.org/wiki/Cadastro_de_pessoas_f%C3%ADsicas"
        /// </summary>
        /// <param name="numerosDoCpf"></param>
        /// <param name="multiplicador"></param>
        /// <param name="primeirosNumerosDoCpf"></param>
        /// <returns></returns>
        private static int CalcularDigitosVerificadores(Span<int> numerosDoCpf, ReadOnlySpan<int> multiplicador, int primeirosNumerosDoCpf = 9)
        {
            int resultado = 0;

            for (int i = 0; i < primeirosNumerosDoCpf; i++)
            {
                resultado += multiplicador[i] * numerosDoCpf[i];
            }

            var digitoVerificador = NumeroPadraoDaDivisao - (resultado % NumeroPadraoDaDivisao);

            if (digitoVerificador == 10 || digitoVerificador == 11)
                return 0;
            else
                return digitoVerificador;
        }

        private string RetirarMascaraCPF(string cpf)
        {
            return cpf?.Length == TamanhoDoCpfComMascara ? cpf?.Replace(".", string.Empty).Replace("-", string.Empty) : cpf;
        }

        private string AtribuirMascaraCPF()
        {
            return cpf?.Length == TamanhoDoCpfSemMascara ? cpf?.Insert(3, ".").Insert(7, ".").Insert(11, "-") : cpf;
        }

        /// <summary>
        /// Cpfs inválidos para o governo, mas que são validos segundo a regra de validação de cpfs.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        private static bool VerificaSeTodosOsDigitosSaoDiferentes(string cpf)
        {
            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" ||
                cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999" ||
                cpf == "000.000.000-00" || cpf == "111.111.111-11" || cpf == "222.222.222-22" || cpf == "333.333.333-33" || cpf == "444.444.444-44" ||
                cpf == "555.555.555-55" || cpf == "666.666.666-66" || cpf == "777.777.777-77" || cpf == "888.888.888-88" || cpf == "999.999.999-99")
                return false;

            return true;
        }

        public bool Equals(CPF other)
        {
            return this == other;
        }

        public override string ToString()
        {
            return AtribuirMascaraCPF();
        }
    }
}
