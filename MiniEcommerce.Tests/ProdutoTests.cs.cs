using MiniEcommerce.Console;

namespace MiniEcommerce.Tests;

public class ProdutoTests
{
    [Fact]
    public void DeveCriarProdutoComDadosValidos()
    {
        var produto = new Produto("Teclado", 150m, 10);

        Assert.Equal("Teclado", produto.Nome);
        Assert.Equal(150m, produto.Preco);
        Assert.Equal(10, produto.QuantidadeEstoque);
    }

    [Fact]
    public void NaoDeveCriarProdutoComPrecoNegativo()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Produto("Teclado", -10m, 10));
    }

    [Fact]
    public void NaoDeveCriarProdutoComEstoqueNegativo()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Produto("Teclado", 150m, -5));
    }
}