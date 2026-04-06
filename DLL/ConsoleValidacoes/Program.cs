using System;
using BibliotecaValidacoes;

class Program
{
    static void Main()
    {
        var validadorCPF = new ValidadorCPF();
        var validadorEmail = new ValidadorEmail();
        var validadorSenha = new ValidadorSenha();

        Console.WriteLine("=== Validacoes ===\n");

        Console.Write("Digite um CPF: ");
        string cpf = Console.ReadLine();
        Console.WriteLine($"CPF valido: {validadorCPF.Validar(cpf)}\n");

        Console.Write("Digite um email: ");
        string email = Console.ReadLine();
        Console.WriteLine($"Email valido: {validadorEmail.Validar(email)}\n");

        Console.Write("Digite uma senha: ");
        string senha = Console.ReadLine();
        Console.WriteLine($"Senha valida: {validadorSenha.Validar(senha)}");
    }
}

// Respostas das questoes e, f, g:
//
// O que quebrou?
// Ao alterar a assinatura de um metodo na DLL (por exemplo, mudar Validar(string cpf)
// para Validar(string cpf, bool formatado)), o projeto console que ja usava a versao
// antiga do metodo para de compilar, porque a chamada nao bate mais com a nova assinatura.
// O compilador mostra um erro dizendo que nao existe um metodo com aqueles parametros.
//
// Breaking Change:
// Breaking change e qualquer alteracao em uma biblioteca ou API que faz com que o codigo
// que ja a utilizava pare de funcionar. Exemplos de breaking changes incluem:
// - mudar o nome de um metodo
// - mudar o tipo ou quantidade de parametros
// - mudar o tipo de retorno
// - remover um metodo publico
// - mudar o namespace
//
// Por isso e importante ter cuidado ao alterar DLLs que ja estao sendo usadas por outros
// projetos. Uma boa pratica e manter a assinatura antiga e criar uma sobrecarga (overload)
// com os novos parametros, assim o codigo antigo continua funcionando.
