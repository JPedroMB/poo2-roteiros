namespace BibliotecaCalculo
{
    public class CalculadoraArea
    {
        public double AreaCirculo(double raio)
        {
            return Math.PI * raio * raio;
        }

        public double AreaRetangulo(double largura, double altura)
        {
            return largura * altura;
        }

        public double AreaTriangulo(double baseTriangulo, double altura)
        {
            return (baseTriangulo * altura) / 2;
        }
    }
}
