var VendasCreate = {
    init: function () {

        $("#IdProduto").change(function () {
            var selectedProductId = $(this).val();

            $.ajax({
                url: '/Vendas/ObterValorUnitario',
                type: 'GET',
                data: { productId: selectedProductId },
                success: function (response) {
                    $("#VlrUnitarioVenda").val(response.valorUnitario);
                },
                error: function () {
                    console.error('Erro ao obter o valor unitário do produto');
                }
            });
        });

        $('#QtdVenda, #VlrUnitarioVenda').change(function () {
            var qtdVenda= parseFloat($('#QtdVenda').val());
            var valorUnitario = parseFloat($('#VlrUnitarioVenda').val());

            if (!isNaN(qtdVenda) && !isNaN(valorUnitario)) {
                var total = qtdVenda * valorUnitario;
                $('#VlrTotalVenda').val(total);
            }
        });        
        
    }
};