// Ejercicio 1
Console.WriteLine("Ejercicio 1");

void MostrarNumeros(int x)
{
    if (x <= 10)
    {
        Console.WriteLine(x);
        MostrarNumeros(x + 1);
    }
}

MostrarNumeros(0);


// Ejercicio 2
Console.WriteLine("Ejercicio 2");

void HolaMundo(int x)
{
    if (x < 5)
    {
        Console.WriteLine("Hola Mundo");
        HolaMundo(x + 1);
    }
}

HolaMundo(0);


// Ejercicio 3
Console.WriteLine("Ejercicio 3");

void Pares(int x)
{
    if (x <= 20)
    {
        Console.WriteLine(x);
        Pares(x + 2);
    }
}

Pares(2);


// Ejercicio 4
Console.WriteLine("Ejercicio 4");

void MultiplosDe7(int x)
{
    if (x <= 70)
    {
        Console.WriteLine(x);
        MultiplosDe7(x + 7);
    }
}

MultiplosDe7(7);


// Ejercicio 5
Console.WriteLine("Ejercicio 5");

void SumaRecursiva(int numero, int suma)
{
    if (numero <= 5)
    {
        suma += numero;
        Console.WriteLine(suma);
        SumaRecursiva(numero + 1, suma);
    }
}

SumaRecursiva(1, 0);
