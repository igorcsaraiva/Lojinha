
//debugger;
//var selectbox
//var token = $('input[name="__RequestVerificationToken"]').val();
//var tokenadr = $('form[action="/Pedido/Create"] input[name="__RequestVerificationToken"]').val();
//var headers = {};
//var headersadr = {};
//headers['__RequestVerificationToken'] = token;
//headersadr['__RequestVerificationToken'] = tokenadr;



$.ajax({
    type: "GET",
    url: "/Pedido/CarregarClientes",
    contentType: 'application/json; charset=utf-8',
    data: { Clientes: $("#Clientes").val() },
    success: function (data) {
        if (data != null) {
            selectbox = $('#Clientes');
            $.each(data.listaCliente, function (i, Cliente) {
                $('<option>').val(Cliente.id).text(Cliente.nome + "  (" + Cliente.codigo + ")").appendTo(selectbox);
            });
        }
    }
});

$.ajax({
    type: "GET",
    url: "/Pedido/CarregarProdutos",
    contentType: 'application/json; charset=utf-8',
    data: { Produtos: $("#Clientes").val() },
    success: function (data) {
        if (data != null) {
            Linhatabela = '';
            $.each(data.listaProduto, function (i, produto) {
                Linhatabela += '<tr>'
                Linhatabela += '<td>' + produto.descricao + '</td>'
                Linhatabela += '<td>' + produto.valorDeVenda + '</td>'
                Linhatabela += '<td>' + produto.quantidade + '</td>'
                Linhatabela += "<td><input type='number' name='Quantidade'  id=campo" + produto.id + " onchange=validarQuantidadepProdutoMaiorQueRequerida(" + produto.quantidade + "," + "'campo" + produto.id + "') /></td>"
                Linhatabela += "<td><input type='checkbox' value =" + produto.id + " name= 'ProdutosID' id='chek" + produto.id + "' onchange='validarSeQuantidadeFoiPreenchida'(input_" + produto.id + ",chek" + produto.id +")'/></td>"
                Linhatabela += '</tr>'
            });

            $('#Produtos').append(Linhatabela);
        }
    }
});

function validarQuantidadepProdutoMaiorQueRequerida(quantidadeDoProduto, campo) {


    var quantidadeRequerida = $('#'+campo).val();

    if (quantidadeDoProduto < quantidadeRequerida) {
        $("#" + campo).val(null);
    }
}

//function validarSeQuantidadeFoiPreenchida(input,chek) {
//    var quantidadeRequerida = $("#" + input).val();

//    if (quantidadeRequerida == 0 || quantidadeRequerida == nul) {
//        $("#" + chek).val(false);
//    }
//}








