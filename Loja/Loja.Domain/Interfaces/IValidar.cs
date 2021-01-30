using Loja.Domain.Shared;
using Loja.Domain.Validations;
using System.Collections.Generic;

namespace Loja.Domain.Interfaces
{
    public interface IValidar<T> where T : Entidade
    {
        IList<Erro> Erros { get; }
        void ValidarCadastro(T Obj);
        void ValidarEdicao(T Obj);
        void ValidarRemocao(T Obj);
    }
}
