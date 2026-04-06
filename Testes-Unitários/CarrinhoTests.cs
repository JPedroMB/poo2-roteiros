using Xunit;
using AulaTestes;

namespace AulaTestes.Tests
{
    public class CarrinhoTests
    {
        [Fact]
        public void Total_DeveSomarCorretamente_QuandoAdicionarItens()
        {
            var carrinho = new Carrinho();
            carrinho.Adicionar(new Item { Nome = "Arroz", Preco = 25.90 });
            carrinho.Adicionar(new Item { Nome = "Feijao", Preco = 8.50 });

            var total = carrinho.Total();

            Assert.Equal(34.40, total, 2);
        }

        [Fact]
        public void Limpar_DeveZerarCarrinho()
        {
            var carrinho = new Carrinho();
            carrinho.Adicionar(new Item { Nome = "Arroz", Preco = 25.90 });
            carrinho.Adicionar(new Item { Nome = "Feijao", Preco = 8.50 });

            carrinho.Limpar();

            Assert.Equal(0, carrinho.Quantidade());
            Assert.Equal(0, carrinho.Total());
        }

        [Fact]
        public void Quantidade_DeveRetornarNumeroCorretoDeItens()
        {
            var carrinho = new Carrinho();
            carrinho.Adicionar(new Item { Nome = "Arroz", Preco = 25.90 });
            carrinho.Adicionar(new Item { Nome = "Feijao", Preco = 8.50 });
            carrinho.Adicionar(new Item { Nome = "Macarrao", Preco = 5.00 });

            Assert.Equal(3, carrinho.Quantidade());
        }
    }
}
