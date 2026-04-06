using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string xmlOriginal = @"<estoque>
            <item>
                <nome>Teclado</nome>
                <quantidade>5</quantidade>
            </item>
            <item>
                <nome>Mouse</nome>
                <quantidade>3</quantidade>
            </item>
        </estoque>";

        XDocument doc = XDocument.Parse(xmlOriginal);

        var mouse = doc.Descendants("item")
            .FirstOrDefault(i => i.Element("nome").Value == "Mouse");

        if (mouse != null)
        {
            mouse.Element("quantidade").Value = "10";
        }

        doc.Save("estoque.xml");

        string conteudo = System.IO.File.ReadAllText("estoque.xml");
        Console.WriteLine(conteudo);
    }
}
