using Xunit;
using AulaTestes;

namespace AulaTestes.Tests
{
    public class ConversorTemperaturaTests
    {
        [Fact]
        public void CelsiusParaFahrenheit_DeveRetornar32_QuandoReceber0()
        {
            var conversor = new ConversorTemperatura();
            var resultado = conversor.CelsiusParaFahrenheit(0);
            Assert.Equal(32, resultado, 2);
        }

        [Fact]
        public void CelsiusParaFahrenheit_DeveRetornar212_QuandoReceber100()
        {
            var conversor = new ConversorTemperatura();
            var resultado = conversor.CelsiusParaFahrenheit(100);
            Assert.Equal(212, resultado, 2);
        }

        [Fact]
        public void FahrenheitParaCelsius_DeveRetornar0_QuandoReceber32()
        {
            var conversor = new ConversorTemperatura();
            var resultado = conversor.FahrenheitParaCelsius(32);
            Assert.Equal(0, resultado, 2);
        }

        [Fact]
        public void FahrenheitParaCelsius_DeveRetornar100_QuandoReceber212()
        {
            var conversor = new ConversorTemperatura();
            var resultado = conversor.FahrenheitParaCelsius(212);
            Assert.Equal(100, resultado, 2);
        }
    }
}
