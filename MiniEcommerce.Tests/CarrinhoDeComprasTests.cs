using MiniEcommerce.Console;

namespace MiniEcommerce.Tests;

public class CarrinhoDeComprasTests
{
    [Fact]
    public void DeveAdicionarProdutoAoCarrinhoECalcularSubtotal()
    {
        // Arrange
        var produto = new Produto("Teclado", 150m, 10);
        var carrinho = new CarrinhoDeCompras();

        // Act
        carrinho.AdicionarProduto(produto, 2);

        // Assert
        Assert.Equal(300m, carrinho.CalcularSubtotal());
    }

    [Fact]
    public void NaoDeveAdicionarQuantidadeSuperiorAoEstoque()
    {
        // Arrange
        var produto = new Produto("Mouse", 80m, 3);
        var carrinho = new CarrinhoDeCompras();

        // Act e Assert
        Assert.Throws<InvalidOperationException>(() =>
            carrinho.AdicionarProduto(produto, 4));
    }
}