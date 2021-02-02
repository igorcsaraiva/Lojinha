
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
}










