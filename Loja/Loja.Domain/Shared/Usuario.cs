using Loja.Domain.Enuns;

namespace Loja.Domain.Shared
{
    public abstract class Usuario : Entidade
    {
        public ETipoUsuario TipoUsuario { get; set; }

        protected Usuario(ETipoUsuario tipoUsuario, int id) : base(id)
        {
            TipoUsuario = tipoUsuario;
        }

        protected Usuario()
        {
        }
    }
}
