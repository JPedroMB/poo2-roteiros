using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

public class Food
{
    public string Name { get; set; }
    public string Price { get; set; }
}

class Program
{
    static async Task Main()
    {
        HttpClient client = new HttpClient();
        string url = "https://www.w3schools.com/xml/simple.xml";

        string response = await client.GetStringAsync(url);
        XDocument doc = XDocument.Parse(response);

        List<Food> cardapio = new List<Food>();

        foreach (var food in doc.Descendants("food"))
        {
            string name = food.Element("name").Value;
            string price = food.Element("price").Value;

            cardapio.Add(new Food { Name = name, Price = price });

            Console.WriteLine($"Nome: {name} - Preco: {price}");
        }
    }
}
