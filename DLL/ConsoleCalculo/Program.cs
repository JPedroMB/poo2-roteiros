using System;
using BibliotecaCalculo;

class Program
{
    static void Main()
    {
        var calc = new CalculadoraArea();

        Console.WriteLine("=== Calculadora de Areas ===\n");

        Console.Write("Digite o raio do circulo: ");
        double raio = double.Parse(Console.ReadLine());
        Console.WriteLine($"Area do circulo: {calc.AreaCirculo(raio):F2}\n");

        Console.Write("Digite a largura do retangulo: ");
        double largura = double.Parse(Console.ReadLine());
        Console.Write("Digite a altura do retangulo: ");
        double alturaRet = double.Parse(Console.ReadLine());
        Console.WriteLine($"Area do retangulo: {calc.AreaRetangulo(largura, alturaRet):F2}\n");

        Console.Write("Digite a base do triangulo: ");
        double baseTri = double.Parse(Console.ReadLine());
        Console.Write("Digite a altura do triangulo: ");
        double alturaTri = double.Parse(Console.ReadLine());
        Console.WriteLine($"Area do triangulo: {calc.AreaTriangulo(baseTri, alturaTri):F2}");
    }
}
