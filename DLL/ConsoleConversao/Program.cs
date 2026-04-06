using System;
using BibliotecaConversao;

class Program
{
    static void Main()
    {
        Conversor conversor = new Conversor();

        Console.WriteLine("=== Conversor ===\n");

        Console.Write("Digite a temperatura em Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        double fahrenheit = conversor.CelsiusParaFahrenheit(celsius);
        Console.WriteLine($"{celsius} C = {fahrenheit} F\n");

        Console.Write("Digite o valor em metros: ");
        double metros = double.Parse(Console.ReadLine());
        double km = conversor.MetrosParaQuilometros(metros);
        Console.WriteLine($"{metros} m = {km} km\n");

        Console.Write("Digite o valor em reais: ");
        double valor = double.Parse(Console.ReadLine());
        Console.Write("Digite a taxa de cambio: ");
        double taxa = double.Parse(Console.ReadLine());
        double convertido = conversor.ConverterMoeda(valor, taxa);
        Console.WriteLine($"R$ {valor} = {convertido} na moeda destino");
    }
}
