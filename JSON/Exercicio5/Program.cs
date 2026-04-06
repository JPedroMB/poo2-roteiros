using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Produto
{
    [JsonProperty(Order = 1)]
    public int Id { get; set; }

    [JsonProperty("product_name", Order = 2, Required = Required.Always)]
    public string Nome { get; set; }

    [JsonProperty("product_price", Order = 3, Required = Required.Always)]
    public double Preco { get; set; }

    [JsonProperty(Order = 4)]
    public int Estoque { get; set; }

    [JsonProperty(Order = 5, NullValueHandling = NullValueHandling.Ignore)]
    public string Fornecedor { get; set; }

    [JsonIgnore]
    public string CodigoInterno { get; set; }
}

class Program
{
    static void Main()
    {
        var produtos = new List<Produto>
        {
            new Produto
            {
                Id = 1,
                Nome = "Notebook",
                Preco = 3500,
                Estoque = 10,
                Fornecedor = "Dell",
                CodigoInterno = "NTB-001"
            },
            new Produto
            {
                Id = 2,
                Nome = "Mouse",
                Preco = 80,
                Estoque = 50,
                Fornecedor = null,
                CodigoInterno = "MSE-002"
            },
            new Produto
            {
                Id = 3,
                Nome = "Teclado",
                Preco = 150,
                Estoque = 30,
                Fornecedor = "Logitech",
                CodigoInterno = "TEC-003"
            }
        };

        var settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Ignore
        };

        string json = JsonConvert.SerializeObject(produtos, settings);
        File.WriteAllText("produtos.json", json);
        Console.WriteLine("Arquivo produtos.json criado:");
        Console.WriteLine(json);

        Console.WriteLine("\n--- Lendo produtos.json ---\n");

        string jsonLido = File.ReadAllText("produtos.json");
        var produtosLidos = JsonConvert.DeserializeObject<List<Produto>>(jsonLido);

        foreach (var p in produtosLidos)
        {
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"Nome: {p.Nome}");
            Console.WriteLine($"Preco: {p.Preco}");
            Console.WriteLine($"Estoque: {p.Estoque}");
            Console.WriteLine($"Fornecedor: {p.Fornecedor ?? "N/A"}");
            Console.WriteLine();
        }

        Console.WriteLine("--- Teste Parte 6: JSON sem campos obrigatorios ---");
        try
        {
            string jsonInvalido = @"[{ ""Id"": 99, ""Estoque"": 5 }]";
            var teste = JsonConvert.DeserializeObject<List<Produto>>(jsonInvalido);
        }
        catch (JsonSerializationException ex)
        {
            Console.WriteLine($"Erro esperado: {ex.Message}");
        }
    }
}
