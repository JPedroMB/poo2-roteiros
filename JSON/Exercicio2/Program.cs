using System;
using System.IO;
using Newtonsoft.Json;

public class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Curso { get; set; }
}

class Program
{
    static void Main()
    {
        string jsonAluno = @"{
            ""Nome"": ""Carlos Silva"",
            ""Idade"": 22,
            ""Curso"": ""Sistemas de Informacao""
        }";

        File.WriteAllText("aluno.json", jsonAluno);

        string json = File.ReadAllText("aluno.json");
        Aluno aluno = JsonConvert.DeserializeObject<Aluno>(json);

        Console.WriteLine($"Nome: {aluno.Nome}");
        Console.WriteLine($"Idade: {aluno.Idade}");
        Console.WriteLine($"Curso: {aluno.Curso}");
    }
}
