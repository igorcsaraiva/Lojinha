
function ValidarProdutoSelecionado(quantidadeDoProduto, input, chek) {

    var quantidadeRequerida = $('#' + input).val();

    if (quantidadeRequerida != null) {
        if (quantidadeDoProduto < quantidadeRequerida || quantidadeRequerida <= 0) {
            $("#" + input).val(null);
            quantidadeRequerida = null;
        }
    }

    if (quantidadeRequerida == null) {
        alert("Informe uma quantidade válida");
        $("#" + chek).prop('checked', false);
    }

    $("#" + input).css('border-color', 'black');
}

function ValidarEnvio() {
    var colunaInput = document.getElementsByClassName('input')
    var colunacheck = document.getElementsByClassName('chek')
    var valorQuantidade = [];
    var valorChek = [];
    var inputId = [];

    for (var i = 0; i < colunaInput.length; i++) {
        inputQuantidade = colunaInput[i].children;
        inputChek = colunacheck[i].children;

        for (var j = 0; j < inputQuantidade.length; j++) {
            if (inputQuantidade[j].value != null || inputQuantidade[j].value != "") {
                valorQuantidade.push(inputQuantidade[j].value);
            }
            inputId.push(inputQuantidade[j].id);
            valorChek.push(inputChek[j].checked);
        }
    }

    for (var i = 0; i < valorQuantidade.length; i++) {
        if (valorQuantidade[i] != "" && valorChek[i] == false) {
            document.getElementById(inputId[i]).style.borderColor = 'red'
            alert("A quantidade do produto foi preenchida mas o mesmo não foi marcado como selecionado")
            return false;
        }
    }

    return true;
}

$(document).ready(function () {
    $('.detalhe').click(function () {
        var id = $(this).val();

        $('#conteudo').load("/Pedido/ItemPedidoIndex/" + id, function () {
            $('.modal').modal('show');
        });
    });
});













