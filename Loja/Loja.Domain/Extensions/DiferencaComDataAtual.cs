using System;

namespace Loja.Domain.Extensions
{
    public static class DiferencaComDataAtual
    {
        public static int CalculaAnosEntreDatas(this DateTime data)
        {
            TimeSpan tempo = DateTime.Today - data;

            if (tempo.Days <= 365)
                return 0;

            return (new DateTime() + tempo).AddYears(-1).AddDays(-1).Year;
        }
    }
}
