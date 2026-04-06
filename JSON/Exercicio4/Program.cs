using System;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        string jsonConfig = @"{
            ""Servidor"": ""192.168.1.100"",
            ""Porta"": 3306,
            ""Usuario"": ""admin""
        }";

        JObject config = JObject.Parse(jsonConfig);

        Console.WriteLine("Antes:");
        Console.WriteLine(config.ToString());

        config["Porta"] = 5432;

        Console.WriteLine("\nDepois:");
        Console.WriteLine(config.ToString());
    }
}
