using System;
using Newtonsoft.Json;

public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }
}

class Program
{
    static void Main()
    {
        var livro = new Livro
        {
            Titulo = "Clean Code",
            Autor = "Robert C. Martin",
            Ano = 2008
        };

        string json = JsonConvert.SerializeObject(livro, Formatting.Indented);
        Console.WriteLine(json);
    }
}
