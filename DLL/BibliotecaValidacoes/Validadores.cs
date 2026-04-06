using System.Text.RegularExpressions;

namespace BibliotecaValidacoes
{
    public class ValidadorCPF
    {
        public bool Validar(string cpf)
        {
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11) return false;

            bool todosIguais = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    todosIguais = false;
                    break;
                }
            }
            if (todosIguais) return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digito1) return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[10].ToString()) != digito2) return false;

            return true;
        }
    }

    public class ValidadorEmail
    {
        public bool Validar(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }

    public class ValidadorSenha
    {
        public bool Validar(string senha)
        {
            if (string.IsNullOrEmpty(senha)) return false;
            if (senha.Length < 8) return false;
            bool temLetra = Regex.IsMatch(senha, "[A-Za-z]");
            bool temNumero = Regex.IsMatch(senha, "[0-9]");
            return temLetra && temNumero;
        }
    }
}
