$(document).ready(function () {
    $('.detalhe').click(function () {
        var id = $(this).val();

        $('#conteudo').load("/Pedido/ItemPedidoIndex/" + id, function () {
            $('.modal').modal('show');
        });
    });
});