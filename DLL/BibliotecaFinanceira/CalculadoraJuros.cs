namespace BibliotecaFinanceira
{
    public class CalculadoraJuros
    {
        public double JurosSimples(double capital, double taxa, int meses)
        {
            return capital * (1 + (taxa / 100) * meses);
        }

        internal double CalculoInterno(double valor)
        {
            return valor * 1.05;
        }
    }
}
