using Loja.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loja.Application.Interfaces
{
    public interface IValidarView<T>
    {
        IList<Erro> Erros { get; }
        void Validar(T Obj);
    }
}
