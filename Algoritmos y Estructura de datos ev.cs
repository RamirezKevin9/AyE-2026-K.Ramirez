// ejercicio 1: calcular el salario de obrero
Console.WriteLine("ejercicio 1: calcular el salario de obrero");
Console.WriteLine("Ingrese la cantidad de horas trabajadas: ");
int horasTrabajadas = 0;
try
{
     horasTrabajadas = Convert.ToInt32(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("¡Error! Por favor, ingresa un número válido.");
}
void CalcularSalario(int horasTrabajadas)
{
    if (horasTrabajadas <= 40)
    {
        int salarioSemanal = (horasTrabajadas * 16) * 7;
        Console.WriteLine("El salario semanal del obrero es: $" + salarioSemanal);
    }
    else
    {
        int salarioSemanal = ((40 * 16) + ((horasTrabajadas - 40) * 20)) * 7;
        Console.WriteLine("El salario semanal del obrero es: $" + salarioSemanal);
    }
}
CalcularSalario(horasTrabajadas);


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
        try
        {
            numero = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("¡Error! Por favor, ingresa un número válido.");
        }

        numeroGuardado = numero;
        suma += numeroGuardado;
    }
    Console.WriteLine("La suma de los numeros ingresados es: " + suma);
}
    SumarNumeros();

// Ejercicio 3:contar vocales en una palabra
Console.WriteLine("ejercicio 3: Contar vocales en una palabra");

    void ContarVocales()
    {
        Console.WriteLine("Ingrese una palabra: ");
        string palabra = "";
    try
    {
        palabra = Console.ReadLine();
    }
    catch (FormatException)
    {
        Console.WriteLine("¡Error! Por favor, ingresa una palabra válida.");
    }
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

// Ejercicio 4: palindromo
Console.WriteLine("ejercicio 4: Palindromo");


    void VerificarPalindromo()
    {
        string palabra2="";
        while (true)
        {
            Console.WriteLine("Ingrese una palabra: ");
        try
        {
            palabra2 = Console.ReadLine().ToLower();
        }
        catch (FormatException)
        {
            Console.WriteLine("¡Error! Por favor, ingresa una palabra válida.");
        }
        string palabraReversa = "";
            for (int i = palabra2.Length - 1; i >= 0; i--)
            {
                palabraReversa += palabra2[i];
            }
            if (palabra2 == palabraReversa)
            {
                Console.WriteLine("La palabra es un palíndromo: " + palabra2);
                break;
            }
            else
            {
                Console.WriteLine("La palabra no es un palíndromo. Intente nuevamente.");
            }
        }
    }
VerificarPalindromo();
