using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Carro
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
}

class Program
{
    static void Main()
    {
        var carros = new List<Carro>
        {
            new Carro { Marca = "Toyota", Modelo = "Corolla", Ano = 2022 },
            new Carro { Marca = "Honda", Modelo = "Civic", Ano = 2023 },
            new Carro { Marca = "Volkswagen", Modelo = "Golf", Ano = 2021 }
        };

        string json = JsonConvert.SerializeObject(carros, Formatting.Indented);
        File.WriteAllText("carros.json", json);
        Console.WriteLine("Arquivo carros.json criado.");

        string jsonLido = File.ReadAllText("carros.json");
        var carrosLidos = JsonConvert.DeserializeObject<List<Carro>>(jsonLido);

        foreach (var c in carrosLidos)
        {
            Console.WriteLine($"Marca: {c.Marca} | Modelo: {c.Modelo} | Ano: {c.Ano}");
        }
    }
}
