# BibliotecaCalculo

DLL para calculo de areas de formas geometricas.

## Como usar

1. Adicione a referencia da DLL BibliotecaCalculo.dll no seu projeto.
2. Adicione o using:
   using BibliotecaCalculo;
3. Crie uma instancia da classe:
   var calc = new CalculadoraArea();

## Metodos disponiveis

### AreaCirculo(double raio)
Calcula a area de um circulo.
Exemplo: calc.AreaCirculo(5) retorna 78.54

### AreaRetangulo(double largura, double altura)
Calcula a area de um retangulo.
Exemplo: calc.AreaRetangulo(4, 6) retorna 24

### AreaTriangulo(double baseTriangulo, double altura)
Calcula a area de um triangulo.
Exemplo: calc.AreaTriangulo(10, 5) retorna 25

## Exemplo completo

using BibliotecaCalculo;

var calc = new CalculadoraArea();
Console.WriteLine(calc.AreaCirculo(5));
Console.WriteLine(calc.AreaRetangulo(4, 6));
Console.WriteLine(calc.AreaTriangulo(10, 5));
