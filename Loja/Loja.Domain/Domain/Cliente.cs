using Loja.Domain.Extensions;
using Loja.Domain.Shared;
using Loja.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Domain.Domain
{
    public class Cliente : Entidade
    {
        public CPF Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Codigo { get; set; }
        public string Senha { get; set; }
        public string DataNascimentoFormatada { get => DataNascimento.ToShortDateString(); }

        public Cliente()
        {
        }

        public Cliente(CPF cpf, DateTime dataNascimento, int codigo, string senha, int id) : base(id)
        {
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Codigo = codigo;
            Senha = senha;
            ID = id;
        }

        public bool MaiorDeIdade()
        {
            return DataNascimento.CalculaAnosEntreDatas() >= 18;
        }
    }
}
