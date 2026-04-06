// Exercicio 0 - Identificar e corrigir erros nos testes

// Questao A
// ERRO: Assert.Equal(4, resultado) - o esperado deveria ser 5, pois 2 + 3 = 5, nao 4.
// CORRECAO:
[Fact]
public void Somar_DeveRetornar5()
{
    var calc = new Calculadora();
    var resultado = calc.Somar(2, 3);
    Assert.Equal(5, resultado);
}

// Questao B
// ERRO: o teste espera uma excecao de divisao por zero, mas passa 10 e 2 como parametros.
// Dividir(10, 2) nao lanca excecao, pois o divisor nao e zero. O correto seria passar 0 como divisor.
// CORRECAO:
[Fact]
public void Dividir_DeveLancarExcecao()
{
    var calc = new Calculadora();
    Assert.Throws<DivideByZeroException>(() => calc.Dividir(10, 0));
}

// Questao C
// ERRO: o teste adiciona um item ao carrinho mas depois verifica uma lista nova criada na hora,
// em vez de verificar os itens do proprio carrinho. Alem disso, Assert.Empty espera que a colecao
// esteja vazia, mas o carrinho tem um item adicionado.
// Se o objetivo e testar que o carrinho comeca vazio, nao deveria adicionar nada.
// CORRECAO:
[Fact]
public void Carrinho_DeveEstarVazio()
{
    var carrinho = new Carrinho();
    Assert.Equal(0, carrinho.Quantidade());
}

// Questao D
// ERRO: Classificar(31) retorna "Obesidade" (pois 31 >= 30), nao "Peso normal".
// Para retornar "Peso normal", o IMC precisa estar entre 18.5 e 24.9.
// CORRECAO:
[Fact]
public void Classificar_DeveRetornarPesoNormal()
{
    var calc = new CalculadoraIMC();
    var resultado = calc.Classificar(22);
    Assert.Equal("Peso normal", resultado);
}
