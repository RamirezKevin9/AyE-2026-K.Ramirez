//Ejercicio 1:
Console.WriteLine("Ejercicio 1:");
string[,] matriz =
{
    { "1", "2", "3", "4" },
    { "5", "6", "7", "8" },
    { "9", "10", "11", "12" },
    { "13", "14", "15", "16" }
};
int sumaEsquinas = int.Parse(matriz[0, 0]) + int.Parse(matriz[0, 3]) + int.Parse(matriz[3, 0]) + int.Parse(matriz[3, 3]);
Console.WriteLine("La suma de las esquinas es: " + sumaEsquinas);

//Ejercicio 2:

Console.WriteLine("Ejercicio 2:");
string[,] matriz2 =
{
    { "1", "2", "3" },
    { "4", "5", "6" },
    { "7", "8", "9" }
};
int sumaDiagonalPrincipal = int.Parse(matriz2[0, 0]) + int.Parse(matriz2[1, 1]) + int.Parse(matriz2[2, 2]);
int sumaDiagonalSecundaria = int.Parse(matriz2[0, 2]) + int.Parse(matriz2[1, 1]) + int.Parse(matriz2[2, 0]);
Console.WriteLine("La suma de la diagonal principal es: " + sumaDiagonalPrincipal);
Console.WriteLine("La suma de la diagonal secundaria es: " + sumaDiagonalSecundaria);

//Ejercicio 3:

Console.WriteLine("Ejercicio 3:");
Console.Write("Ingrese el tamaño de la matriz de identidad: ");
int tamaño = int.Parse(Console.ReadLine());
int[,] matrizIdentidad = new int[tamaño, tamaño];
for (int i = 0; i < tamaño; i++)
{
    for (int j = 0; j < tamaño; j++)
    {
        if (i == j)
        {
            matrizIdentidad[i, j] = 1;
        }
        else
        {
            matrizIdentidad[i, j] = 0;
        }
    }
}
Console.WriteLine("Matriz de identidad:");
for (int i = 0; i < tamaño; i++)
{
    for (int j = 0; j < tamaño; j++)
    {
        Console.Write(matrizIdentidad[i, j] + " ");
    }
    Console.WriteLine();
}