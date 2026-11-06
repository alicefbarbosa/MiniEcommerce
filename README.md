# MiniEcommerce 🛒

Projeto de um sistema de e-commerce desenvolvido em C# com .NET 10, aplicando os princípios de Desenvolvimento Orientado a Testes (TDD).

O sistema permite cadastrar produtos, consultar o catálogo, adicionar produtos ao carrinho de compras e finalizar pedidos, realizando a atualização automática do estoque.

## 🚀 Tecnologias utilizadas

- C#
- .NET 10
- xUnit
- Git e GitHub
- Visual Studio Code

## 📁 Estrutura do projeto

```text
MiniEcommerce/
│
├── MiniEcommerce.Console/
│   ├── Program.cs
│   ├── Produto.cs
│   ├── CarrinhoDeCompras.cs
│   └── Pedido.cs
│
├── MiniEcommerce.Tests/
│   ├── ProdutoTests.cs
│   ├── CarrinhoDeComprasTests.cs
│   └── PedidoTests.cs
│
├── MiniEcommerce.sln
└── .gitignore
```

## ⚙️ Funcionalidades

- Cadastro de produtos com nome, preço e quantidade em estoque.
- Listagem dos produtos cadastrados.
- Adição de produtos ao carrinho de compras.
- Validação da quantidade disponível em estoque.
- Cálculo do subtotal do carrinho.
- Finalização de pedidos.
- Atualização automática do estoque após a compra.

## 🧪 Testes automatizados

O projeto utiliza o framework xUnit para a criação e execução de testes automatizados.

A implementação segue a metodologia TDD (Test-Driven Development), baseada no ciclo:

1. **RED:** escrever um teste que inicialmente falha.
2. **GREEN:** implementar o código necessário para fazer o teste passar.
3. **REFACTOR:** melhorar o código preservando o comportamento esperado.

Para executar os testes, utilize:

```bash
dotnet test
```

## ▶️ Como executar o projeto

### Pré-requisitos

- .NET 10 SDK instalado.
- Git instalado.

### Clonar o repositório

```bash
git clone https://github.com/alicefbarbosa/MiniEcommerce.git
```

### Acessar a pasta do projeto

```bash
cd MiniEcommerce
```

### Executar a aplicação

```bash
dotnet run --project MiniEcommerce.Console/MiniEcommerce.Console.csproj
```

### Executar os testes

```bash
dotnet test
```

## 👩‍💻 Autora

Alice Fernandes Barbosa - 326128348

Projeto acadêmico desenvolvido para praticar conceitos de programação orientada a objetos, testes automatizados e desenvolvimento orientado a testes (TDD).
