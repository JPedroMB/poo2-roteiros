using System;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        string xml = @"<alunos>
            <aluno>
                <nome>Maria</nome>
                <curso>Sistemas de Informacao</curso>
            </aluno>
            <aluno>
                <nome>Joao</nome>
                <curso>Engenharia de Software</curso>
            </aluno>
        </alunos>";

        XDocument doc = XDocument.Parse(xml);

        foreach (var aluno in doc.Descendants("aluno"))
        {
            string nome = aluno.Element("nome").Value;
            string curso = aluno.Element("curso").Value;
            Console.WriteLine($"Nome: {nome} - Curso: {curso}");
        }
    }
}
