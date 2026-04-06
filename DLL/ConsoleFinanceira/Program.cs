using System;
using BibliotecaFinanceira;

class Program
{
    static void Main()
    {
        var calc = new CalculadoraJuros();

        Console.Write("Digite o capital: ");
        double capital = double.Parse(Console.ReadLine());
        Console.Write("Digite a taxa (%): ");
        double taxa = double.Parse(Console.ReadLine());
        Console.Write("Digite os meses: ");
        int meses = int.Parse(Console.ReadLine());

        double resultado = calc.JurosSimples(capital, taxa, meses);
        Console.WriteLine($"Montante com juros simples: {resultado:F2}");

        // calc.CalculoInterno(100); // ERRO: nao compila
    }
}

// Resposta da questao 6a:
// O metodo internal nao aparece porque ele so pode ser acessado dentro do mesmo assembly (DLL).
// Como o projeto Console e um assembly diferente da BibliotecaFinanceira, ele nao consegue
// enxergar metodos marcados como internal. Somente metodos public ficam visiveis para
// projetos externos que referenciam a DLL.
