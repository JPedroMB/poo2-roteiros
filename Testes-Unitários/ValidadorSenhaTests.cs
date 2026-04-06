using Xunit;
using AulaTestes;

namespace AulaTestes.Tests
{
    public class ValidadorSenhaTests
    {
        [Fact]
        public void EhValida_DeveRetornarTrue_QuandoSenhaForSenha123()
        {
            var validador = new ValidadorSenha();
            var resultado = validador.EhValida("Senha123");
            Assert.True(resultado);
        }

        [Fact]
        public void EhValida_DeveRetornarFalse_QuandoSenhaForApenasNumeros()
        {
            var validador = new ValidadorSenha();
            var resultado = validador.EhValida("12345678");
            Assert.False(resultado);
        }

        [Fact]
        public void EhValida_DeveRetornarFalse_QuandoSenhaForVazia()
        {
            var validador = new ValidadorSenha();
            var resultado = validador.EhValida("");
            Assert.False(resultado);
        }

        [Fact]
        public void EhValida_DeveRetornarFalse_QuandoSenhaForApenasLetras()
        {
            var validador = new ValidadorSenha();
            var resultado = validador.EhValida("abcdEFGH");
            Assert.False(resultado);
        }
    }
}
