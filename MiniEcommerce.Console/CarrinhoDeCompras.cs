namespace MiniEcommerce.Console;

public class CarrinhoDeCompras
{
    private readonly Dictionary<Produto, int> _itens = new();

    public IReadOnlyDictionary<Produto, int> Itens => _itens;

    public void AdicionarProduto(Produto produto, int quantidade)
    {
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade), "A quantidade deve ser maior que zero.");

        int quantidadeAtual = _itens.GetValueOrDefault(produto, 0);

        if (quantidadeAtual + quantidade > produto.QuantidadeEstoque)
            throw new InvalidOperationException("Quantidade solicitada superior ao estoque disponível.");

        _itens[produto] = quantidadeAtual + quantidade;
    }

    public decimal CalcularSubtotal()
    {
        decimal subtotal = 0;

        foreach (var item in _itens)
        {
            subtotal += item.Key.Preco * item.Value;
        }

        return subtotal;
    }
}