using MiniEcommerce.Console;

namespace MiniEcommerce.Tests;

public class PedidoTests
{
    [Fact]
    public void DeveFinalizarPedidoEAtualizarEstoque()
    {
        // Arrange
        var produto = new Produto("Teclado", 150m, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.AdicionarProduto(produto, 2);

        var pedido = new Pedido(carrinho);

        // Act
        pedido.Finalizar();

        // Assert
        Assert.Equal(8, produto.QuantidadeEstoque);
    }

    [Fact]
    public void DeveCalcularValorTotalDoPedido()
    {
        // Arrange
        var produto = new Produto("Teclado", 150m, 10);
        var carrinho = new CarrinhoDeCompras();

        carrinho.AdicionarProduto(produto, 2);

        var pedido = new Pedido(carrinho);

        // Act
        decimal total = pedido.Finalizar();

        // Assert
        Assert.Equal(300m, total);
    }
}