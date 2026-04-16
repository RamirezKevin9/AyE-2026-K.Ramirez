// 1 Primer bloque - Ejercicios básicos
// ejercicio a
Console.WriteLine("Ejercicio a: Imprimir los números del 1 al 100 que son múltiplos de 3.");
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0)
    {
        Console.WriteLine(i);
    }
}

// ejercicio b
Console.WriteLine();
Console.WriteLine("Ejercicio b: Ingrese su edad:");
int edad = Convert.ToInt32(Console.ReadLine());
if (edad == 18)
{
    Console.WriteLine("Tienes justo 18 años.");
}
else if (edad < 18)
{
    Console.WriteLine("Es menor de edad.");
}
else
{
    Console.WriteLine("Es mayor de edad.");
}

// ejercicio c
Console.WriteLine();
Console.WriteLine("Ejercicio c: Ingrese una palabra:");
Console.Write("Palabra: ");
string palabra = Console.ReadLine();
if (palabra == "")
{
    Console.WriteLine("Entrada inválida. Introduzca una palabra.");
}
else
{
    int letras = palabra.Length;

    Console.WriteLine("La palabra " + palabra + " tiene " + letras + " letras.");
}

// ejercicio d
Console.WriteLine();
Console.WriteLine("Ejercicio d: Adivine la contraseña secreta. Tiene 5 intentos.");
string secreto = "secreto123";
int intentosMax = 5;
bool acertado = false;

for (int intento = 1; intento <= intentosMax; intento++)
{
    Console.Write("Intento: " + intento + "/" + intentosMax + ": ");
    string intentoUsuario = Console.ReadLine();

    if (intentoUsuario == secreto)
    {
        Console.WriteLine("¡Correcto! Ha adivinado la contraseña.");
        acertado = true;
        break;
    }
}
Console.WriteLine("Ha agotado los intentos.");

// ejercicio e
Console.WriteLine();
Console.WriteLine("Ejercicio e: Ingrese 10 números y mostrar cuál fue el más alto.");
int cantidad = 10;
int maximo = 0;

for (int i = 1; i <= cantidad; i++)
{
    Console.Write("Ingrese un número: ");
    int numero = Convert.ToInt32(Console.ReadLine());
    if (numero > maximo)
    {
        maximo = numero;
    }
}

Console.WriteLine("El número más alto ingresado es: " + maximo);

// ejercicio f
Console.WriteLine();
Console.WriteLine("Ejercicio f: Ingrese su nombre y será saludado:");
Console.Write("Nombre: ");
string nombre = Console.ReadLine();
Console.WriteLine("Hola, " + nombre + "!");

// ejercicio g
Console.WriteLine();
Console.WriteLine("Ejercicio g: Tabla del 7 del 1 al 10:");
int multiplicando = 7;
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(multiplicando * i);
}


// ejercicio h
Console.WriteLine();
Console.WriteLine("Ejercicio h: Cuenta regresiva del 10 al 1:");
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine(i);
}

// ejercicio i
Console.WriteLine();
Console.WriteLine("Ejercicio i: Ingrese un número para determinar si es par o impar:");
Console.Write("Número: ");
int numeroIngresado = Convert.ToInt32(Console.ReadLine());
if (numeroIngresado % 2 == 0)
{
 Console.WriteLine("par");
}
else
{
 Console.WriteLine("impar");
}

// ejercicio j
Console.WriteLine();
Console.WriteLine("Ejercicio j: Ingrese una frase y se mostrará la cantidad de vocales:");
Console.Write("Frase: ");
string frase = Console.ReadLine();
int contadorVocales = 0;
string vocales = "aeiouáéíóúAEIOUÁÉÍÓÚüÜ";

foreach (char c in frase)
{
    if (vocales.IndexOf(c) >= 0)
    {
        contadorVocales++;
    }
}

Console.WriteLine("Cantidad de vocales: " + contadorVocales);