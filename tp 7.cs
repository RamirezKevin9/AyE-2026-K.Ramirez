// ejercicio 1
Console.WriteLine("ejercicio 1: Numero Primo");
Console.WriteLine("Ingrese un numero para ver si es primo o no");
bool esPrimo = true;
int numero = Convert.ToInt32(Console.ReadLine());
for (int i = 2; i < numero; i++)
{
    if (numero % i == 0)
    {
        esPrimo = false;
        break;
    }
}
if (esPrimo)
    {
    Console.WriteLine("El numero es primo");
}
else
{
    Console.WriteLine("El numero no es primo");
}

// ejercicio 2
Console.WriteLine("ejercicio 2: Factorial");
Console.WriteLine("Ingrese un numero para ver su factorial");
int numero2 = Convert.ToInt32(Console.ReadLine());
int factorial = 1;
for (int i = 1; i <= numero2; i++)
{
    factorial *= i;
}
Console.WriteLine("El factorial de " + numero2 + " es " + factorial);

// ejercicio 3
Console.WriteLine("ejercicio 3: Secuencia Fibonacci");
Console.WriteLine("Ingrese un numero para ver la secuencia Fibonacci hasta ese numero");
int numero3 = Convert.ToInt32(Console.ReadLine());
int a = 0, b = 1, c = 0;
for (int i = 0; i < numero3; i++)
    {
    Console.Write(a + " ");
    c = a + b;
    a = b;
    b = c;
}
// ejercicio 4
Console.WriteLine("Ejercicio 4: Menú interactivo");
Console.WriteLine("Seleccione una opción:");
Console.WriteLine("1. Saludar");
Console.WriteLine("2. Despedirse");
Console.WriteLine("3. Salir");
bool salir = false;
while (salir == false)
{
    int opcion = Convert.ToInt32(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("¡Hola! ¿Cómo estás?");
            break;
        case 2:
            Console.WriteLine("¡Adiós! Que tengas un buen día.");
            break;
        case 3:
            Console.WriteLine("Saliendo del programa...");
            salir = true;
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción del 1 al 3.");
            break;
    }
}   
