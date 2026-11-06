namespace MiniEcommerce.Console;

public class Pedido
{
    private readonly CarrinhoDeCompras _carrinho;

    public Pedido(CarrinhoDeCompras carrinho)
    {
        _carrinho = carrinho;
    }

    public decimal Finalizar()
    {
        decimal total = _carrinho.CalcularSubtotal();

        foreach (var item in _carrinho.Itens)
        {
            item.Key.QuantidadeEstoque -= item.Value;
        }

        return total;
    }
}