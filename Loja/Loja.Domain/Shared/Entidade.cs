namespace Loja.Domain.Shared
{
    public abstract class Entidade
    {
        public int ID { get; set; }
        public Entidade(int id)
        {
            ID = id;
        }
        protected Entidade()
        {
        }
    }
}
