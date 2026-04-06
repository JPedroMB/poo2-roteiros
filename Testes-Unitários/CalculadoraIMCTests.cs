using Xunit;
using AulaTestes;
using System;

namespace AulaTestes.Tests
{
    public class CalculadoraIMCTests
    {
        [Fact]
        public void Calcular_DeveRetornarAproximadamente22_86_QuandoPeso70Altura1_75()
        {
            var calc = new CalculadoraIMC();
            var resultado = calc.Calcular(70, 1.75);
            Assert.Equal(22.86, resultado, 2);
        }

        [Fact]
        public void Classificar_DeveRetornarAbaixoDoPeso_QuandoIMC17()
        {
            var calc = new CalculadoraIMC();
            var resultado = calc.Classificar(17);
            Assert.Equal("Abaixo do peso", resultado);
        }

        [Fact]
        public void Classificar_DeveRetornarSobrepeso_QuandoIMC26()
        {
            var calc = new CalculadoraIMC();
            var resultado = calc.Classificar(26);
            Assert.Equal("Sobrepeso", resultado);
        }

        [Fact]
        public void Calcular_DeveLancarExcecao_QuandoAlturaMenorOuIgualZero()
        {
            var calc = new CalculadoraIMC();
            Assert.Throws<ArgumentException>(() => calc.Calcular(70, 0));
        }
    }
}
