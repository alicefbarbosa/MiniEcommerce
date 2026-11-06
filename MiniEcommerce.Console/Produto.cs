namespace MiniEcommerce.Console;

public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }

    public Produto(string nome, decimal preco, int quantidadeEstoque)
    {
        if (preco < 0)
            throw new ArgumentOutOfRangeException(nameof(preco), "O preço não pode ser negativo.");

        if (quantidadeEstoque < 0)
            throw new ArgumentOutOfRangeException(nameof(quantidadeEstoque), "O estoque não pode ser negativo.");

        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
    }
}