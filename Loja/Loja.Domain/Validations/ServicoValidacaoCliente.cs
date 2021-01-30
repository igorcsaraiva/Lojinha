using Loja.Domain.Domain;
using Loja.Domain.Interfaces;
using System.Collections.Generic;

namespace Loja.Domain.Validations
{
    public class ServicoValidacaoCliente : IValidarCliente
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public IList<Erro> Erros { get; private set; }

        public ServicoValidacaoCliente(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
            Erros = new List<Erro>();
        }

        public void ValidarCadastro(Cliente Obj)
        {
            CpfExiste(Obj);
            CodigoExiste(Obj);
        }

        public void ValidarEdicao(Cliente Obj)
        {
            ClienteNaoExiste(Obj);
            CpfExiste(Obj);
            CodigoExiste(Obj);
        }

        public void ValidarRemocao(Cliente Obj)
        {
            ClienteNaoExiste(Obj);
        }

        private void CpfExiste(Cliente cliente)
        {
            var cli = _clienteRepositorio.CpfExiste(cliente).Result;

            if (cli != null && cli.ID != cliente.ID)
                Erros.Add(new Erro { Propriedade = "CPF", MensagemErro = "CPF já cadastrado" });
        }

        private void CodigoExiste(Cliente cliente)
        {
            var cli = _clienteRepositorio.CodigoExiste(cliente).Result;
            
            if (cli != null && cli.ID != cliente.ID)
                Erros.Add(new Erro { Propriedade = "Codigo", MensagemErro = "Código já cadastrado" });
        }

        private void ClienteNaoExiste(Cliente cliente)
        {
            if (_clienteRepositorio.BuscarPorId(cliente.ID).Result == null)
                Erros.Add(new Erro { Propriedade = string.Empty, MensagemErro = "Esse cliente não existe" });
        }
    }
}
