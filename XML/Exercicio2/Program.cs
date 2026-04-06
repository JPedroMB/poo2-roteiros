using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}

[XmlRoot("Produtos")]
public class ListaProdutos
{
    [XmlElement("Produto")]
    public List<Produto> Itens { get; set; }
}

class Program
{
    static void Main()
    {
        var lista = new ListaProdutos
        {
            Itens = new List<Produto>
            {
                new Produto { Nome = "Mouse Gamer", Preco = 149.90 },
                new Produto { Nome = "Teclado Mecanico", Preco = 289.90 },
                new Produto { Nome = "Monitor 24pol", Preco = 899.90 }
            }
        };

        XmlSerializer serializer = new XmlSerializer(typeof(ListaProdutos));

        using (StreamWriter writer = new StreamWriter("produtos.xml"))
        {
            serializer.Serialize(writer, lista);
        }

        string conteudo = File.ReadAllText("produtos.xml");
        Console.WriteLine(conteudo);
    }
}
