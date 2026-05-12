try
{
    Console.WriteLine("ejercicio 1: calcular el salario de obrero");
    Console.WriteLine("Ingrese la cantidad de horas trabajadas: ");
    int horasTrabajadas = Convert.ToInt32(Console.ReadLine());
    if (horasTrabajadas <= 40)
    {
        int salarioSemanal = horasTrabajadas * 16;
        Console.WriteLine("El salario semanal del obrero es: $" + salarioSemanal);
    }
    else
    {
        int salarioSemanal = (40 * 16) + ((horasTrabajadas - 40) * 20);
        Console.WriteLine("El salario semanal del obrero es: $" + salarioSemanal);
    }
} catch (InvalidCastException)
{
    Console.WriteLine("¡Error! Por favor, ingresa un número válido.");
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("¡Error! Por favor, ingresa un número válido.");
}
catch (FormatException)
{
    Console.WriteLine("¡Error! Por favor, ingresa un número válido.");
}
catch (OverflowException)
{
    Console.WriteLine("¡Error! Por favor, ingresa un número válido.");
}
// Ejercicio 2:Suma de numeros ingresados por el usuario
Console.WriteLine("ejercicio 2: Suma de numeros ingresados por el usuario");
Console.WriteLine("Ingrese numeros (ingrese 0 para finalizar): ");
void SumarNumeros()
{
    int suma = 0;
    int numeroGuardado = 0;
    int numero = 1;
    while (numero != 0)
    {
        numero = Convert.ToInt32(Console.ReadLine());
        numeroGuardado = numero;
        suma += numeroGuardado;
        numero += numeroGuardado;
    }
    Console.WriteLine("La suma de los numeros ingresados es: " + suma);
}
SumarNumeros();

// Ejercicio 3:contar vocales en una palabra
Console.WriteLine("ejercicio 3: Contar vocales en una palabra");
void ContarVocales()
{
    Console.WriteLine("Ingrese una palabra: ");
    string palabra = Console.ReadLine();
    int contadorVocales = 0;
    foreach (char letra in palabra)
    {
        if ("aeiouáéíóúAEIOUÁÉÍÓÚ".Contains(letra))
        {
            contadorVocales++;
        }
    }
    Console.WriteLine("La cantidad de vocales en la palabra es: " + contadorVocales);
}
ContarVocales();

// Ejercicio 4:Hacer una funcion que le pida al usuario una palabra, si la palabra es un palindromo devolver la palabra,
// si no lo es volver a pedir la palabra hasta que lo sea. La funcion no recibe parametros. (3 puntos)
Console.WriteLine("ejercicio 4: Palindromo");
void VerificarPalindromo()
{
    string palabra;
    while (true)
    {
        Console.WriteLine("Ingrese una palabra: ");
        palabra = Console.ReadLine().ToLower();
        string palabraReversa = "";
        for (int i = palabra.Length - 1; i >= 0; i--)
        {
            palabraReversa += palabra[i];
        }
        if (palabra == palabraReversa)
        {
            Console.WriteLine("La palabra es un palíndromo: " + palabra);
            break;
        }
        else
        {
            Console.WriteLine("La palabra no es un palíndromo. Intente nuevamente.");
        }
    }
}
VerificarPalindromo();