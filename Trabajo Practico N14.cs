//Ejercicio 1:Carga y Recorrido Básico
Console.WriteLine("Ejercicio 1: Carga y Recorrido Básico");
Console.WriteLine("Ingrese 5 números:");
List<int> numeros = new List<int> {0, 0, 0, 0, 0};
for (int i = 0; i < 5; i++)
{
    Console.Write($"Número {i + 1}: ");
    int numero = int.Parse(Console.ReadLine());
    numeros[i] = numero;
}
Console.WriteLine("Los números ingresados son:");
foreach (int numero in numeros)
{
    Console.WriteLine(numero);
}

//Ejercicio 2: Búsqueda y Conteo
Console.WriteLine("Ejercicio 2: Búsqueda y Conteo");
List<string> frutas = new List<string> { "manzana", "banana", "naranja", "uva", "pera" };
Console.WriteLine("Ingrese el nombre de una fruta:");
string frutaBuscada = Console.ReadLine();
int indice = frutas.IndexOf(frutaBuscada);
if (indice != -1)
{
    Console.WriteLine($"La fruta {frutaBuscada} se encuentra en la posición {indice}.");
}
else
{
    Console.WriteLine($"La fruta {frutaBuscada} no fue encontrada.");
}

//Ejercicio 3: Suma y Promedio
Console.WriteLine("Ejercicio 3: Suma y Promedio");
List<double> notas = new List<double> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
Console.WriteLine("Ingrese las notas de los estudiantes:");
for (int i = 0; i < 10; i++)
{
    Console.Write($"Nota {i + 1}: ");
    double nota = double.Parse(Console.ReadLine());
    notas[i] = nota;
}
double suma = 0;
foreach (double nota in notas)
{
    suma += nota;
}
double promedio = suma / 10;
Console.WriteLine($"La suma total de las notas es: {suma}");
Console.WriteLine($"El promedio de las notas es: {promedio}");

//Ejercicio 4: Encontrar el Valor Máximo y Mínimo
//Escribí un programa que, a partir de una lista de temperaturas diarias,
//encuentre y muestre la temperatura máxima y la temperatura mínima
//registradas.

Console.WriteLine("Ejercicio 4: Encontrar el Valor Máximo y Mínimo");
List<double> temperaturas = new List<double> {32, 28, 30, 35, 31, 29, 27};
double max = temperaturas[0];
double min = temperaturas[0];
foreach (double temp in temperaturas)
{
    if (temp > max) max = temp;
    if (temp < min) min = temp;
}
Console.WriteLine($"La temperatura máxima es: {max}");
Console.WriteLine($"La temperatura mínima es: {min}");

//Ejercicio 5: Ordenamiento
//Crea un programa que tenga una lista de números desordenados. El programa
//debe ordenar esta lista de forma ascendente y luego imprimirla
//sin .Sort() tampoco .Count
Console.WriteLine("Ejercicio 5: Ordenamiento");
List<int> numerosDesordenados = new List<int> { 5, 2, 9, 1, 4, 6 };
for (int i = 0; i < numerosDesordenados.Count; i++)
{
    for (int j = 0; j < numerosDesordenados.Count - 1; j++)
    {
        if (numerosDesordenados[j] > numerosDesordenados[j + 1])
        {
            int temp = numerosDesordenados[j];
            numerosDesordenados[j] = numerosDesordenados[j + 1];
            numerosDesordenados[j + 1] = temp;
        }
    }
}
Console.WriteLine("Números ordenados:");
foreach (int numero in numerosDesordenados)
{
    Console.WriteLine(numero);
}

//Ejercicio 6: Pares e Impares
Console.WriteLine("Ejercicio 6: Pares e Impares");
List<int> numerosEnteros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
int pares = 0;
int impares = 0;
foreach (int numero in numerosEnteros)
{
    if (numero % 2 == 0) pares++;
    else impares++;
}
Console.WriteLine($"Cantidad de números pares: {pares}");
Console.WriteLine($"Cantidad de números impares: {impares}");
