using Xunit;
using AulaTestes;
using System;

namespace AulaTestes.Tests
{
    public class DescontoServiceTests
    {
        // Parte A - testes individuais com [Fact]

        [Fact]
        public void AplicarDesconto_DeveRetornar90_QuandoValor100Percentual10()
        {
            var service = new DescontoService();
            var resultado = service.AplicarDesconto(100, 10);
            Assert.Equal(90, resultado);
        }

        [Fact]
        public void AplicarDesconto_DeveRetornar100_QuandoValor200Percentual50()
        {
            var service = new DescontoService();
            var resultado = service.AplicarDesconto(200, 50);
            Assert.Equal(100, resultado);
        }

        [Fact]
        public void AplicarDesconto_DeveRetornar80_QuandoValor80Percentual0()
        {
            var service = new DescontoService();
            var resultado = service.AplicarDesconto(80, 0);
            Assert.Equal(80, resultado);
        }

        [Fact]
        public void AplicarDesconto_DeveLancarExcecao_QuandoValorNegativo()
        {
            var service = new DescontoService();
            Assert.Throws<ArgumentException>(() => service.AplicarDesconto(-10, 10));
        }

        [Fact]
        public void AplicarDesconto_DeveLancarExcecao_QuandoPercentualMenorQueZero()
        {
            var service = new DescontoService();
            Assert.Throws<ArgumentException>(() => service.AplicarDesconto(100, -5));
        }

        [Fact]
        public void AplicarDesconto_DeveLancarExcecao_QuandoPercentualMaiorQue100()
        {
            var service = new DescontoService();
            Assert.Throws<ArgumentException>(() => service.AplicarDesconto(100, 150));
        }

        // Parte B - testes com [Theory] e [InlineData] para valores validos

        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(200, 50, 100)]
        [InlineData(80, 0, 80)]
        public void AplicarDesconto_DeveRetornarValorCorreto(double valor, double percentual, double esperado)
        {
            var service = new DescontoService();
            var resultado = service.AplicarDesconto(valor, percentual);
            Assert.Equal(esperado, resultado);
        }
    }
}
