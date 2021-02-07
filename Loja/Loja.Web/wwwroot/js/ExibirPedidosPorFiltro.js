$(document).ready(function () {
    $('.pesquisar').click(function () {
        var cpfOuCodigo = $('.cpfOuCodigo').val();
        var dataInicio = $('.dataInicio').val();
        var dataFim = $('.dataFim').val();

        $(".ListarPedidos").load("/Pedido/ListarPedidosPorFiltro?dataInicio=" + dataInicio + "&dataFim=" + dataFim + "&valor=" + cpfOuCodigo);
    });
});