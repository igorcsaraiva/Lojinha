using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System.Collections.Generic;

namespace Loja.Domain.Validations
{
    public class ServicosValidacaoCliente : IValidarCliente
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public IList<Erro> Erros { get; private set; }

        public ServicosValidacaoCliente(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            Erros = new List<Erro>();
        }

        public void Validar(Cliente cliente)
        {
            CpfExiste(cliente);
            Codigo(cliente);
        }

        private void CpfExiste(Cliente cliente)
        {
            if (_clienteRepositorio.CpfExiste(cliente))
                Erros.Add(new Erro { Propriedade = "CPF", MensagemErro = "Cpf já cadastrado" });
        }

        private void Codigo(Cliente cliente)
        {
            if (_clienteRepositorio.CodigoExiste(cliente))
                Erros.Add(new Erro { Propriedade = "Codigo", MensagemErro = "Código já cadastrado" });
        }
    }
}
