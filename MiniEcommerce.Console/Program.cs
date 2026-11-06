using System.Globalization;
using MiniEcommerce.Console;

var produtos = new List<Produto>();
var carrinho = new CarrinhoDeCompras();

bool executando = true;

while (executando)
{
    System.Console.WriteLine("\n================================");
    System.Console.WriteLine("       MINI E-COMMERCE");
    System.Console.WriteLine("================================");
    System.Console.WriteLine("1 - Cadastrar produto");
    System.Console.WriteLine("2 - Listar produtos");
    System.Console.WriteLine("3 - Adicionar produto ao carrinho");
    System.Console.WriteLine("4 - Finalizar pedido");
    System.Console.WriteLine("0 - Sair");
    System.Console.Write("\nEscolha uma opção: ");

    string? opcao = System.Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarProduto();
            break;

        case "2":
            ListarProdutos();
            break;

        case "3":
            AdicionarAoCarrinho();
            break;

        case "4":
            FinalizarPedido();
            break;

        case "0":
            executando = false;
            System.Console.WriteLine("\nEncerrando o Mini Ecommerce...");
            break;

        default:
            System.Console.WriteLine("\nOpção inválida!");
            break;
    }
}

void CadastrarProduto()
{
    System.Console.Write("\nNome do produto: ");
    string? nome = System.Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nome))
    {
        System.Console.WriteLine("Nome inválido!");
        return;
    }

    System.Console.Write("Preço: ");
    string? entradaPreco = System.Console.ReadLine();

    string precoFormatado = (entradaPreco ?? "").Replace(',', '.');

    if (!decimal.TryParse(
        precoFormatado,
        NumberStyles.Number,
        CultureInfo.InvariantCulture,
        out decimal preco))
    {
        System.Console.WriteLine("Preço inválido!");
        return;
    }

    System.Console.Write("Quantidade em estoque: ");

    if (!int.TryParse(System.Console.ReadLine(), out int estoque))
    {
        System.Console.WriteLine("Quantidade inválida!");
        return;
    }

    try
    {
        var produto = new Produto(nome, preco, estoque);

        produtos.Add(produto);

        System.Console.WriteLine("\nProduto cadastrado com sucesso!");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        System.Console.WriteLine($"\nErro ao cadastrar produto: {ex.Message}");
    }
}

void ListarProdutos()
{
    System.Console.WriteLine("\n========== CATÁLOGO ==========");

    if (produtos.Count == 0)
    {
        System.Console.WriteLine("Nenhum produto cadastrado.");
        return;
    }

    for (int i = 0; i < produtos.Count; i++)
    {
        var produto = produtos[i];

        System.Console.WriteLine(
            $"{i + 1} - {produto.Nome} | " +
            $"Preço: R$ {produto.Preco:F2} | " +
            $"Estoque: {produto.QuantidadeEstoque}");
    }
}

void AdicionarAoCarrinho()
{
    ListarProdutos();

    if (produtos.Count == 0)
        return;

    System.Console.Write("\nDigite o número do produto: ");

    if (!int.TryParse(System.Console.ReadLine(), out int indice) ||
        indice < 1 ||
        indice > produtos.Count)
    {
        System.Console.WriteLine("Produto inválido!");
        return;
    }

    System.Console.Write("Quantidade desejada: ");

    if (!int.TryParse(System.Console.ReadLine(), out int quantidade))
    {
        System.Console.WriteLine("Quantidade inválida!");
        return;
    }

    try
    {
        var produto = produtos[indice - 1];

        carrinho.AdicionarProduto(produto, quantidade);

        System.Console.WriteLine("\nProduto adicionado ao carrinho!");
        System.Console.WriteLine(
            $"Subtotal: R$ {carrinho.CalcularSubtotal():F2}");
    }
    catch (Exception ex) when (
        ex is InvalidOperationException ||
        ex is ArgumentOutOfRangeException)
    {
        System.Console.WriteLine($"\nNão foi possível adicionar: {ex.Message}");
    }
}

void FinalizarPedido()
{
    if (carrinho.Itens.Count == 0)
    {
        System.Console.WriteLine("\nO carrinho está vazio!");
        return;
    }

    var pedido = new Pedido(carrinho);

    decimal total = pedido.Finalizar();

    System.Console.WriteLine("\n========== PEDIDO FINALIZADO ==========");
    System.Console.WriteLine($"Total da compra: R$ {total:F2}");
    System.Console.WriteLine("Obrigado pela preferência!");

    carrinho = new CarrinhoDeCompras();
}