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
string vocales = "aeiouAEIOU";

foreach (char c in frase)
{
    if (vocales.IndexOf(c) >= 0)
    {
        contadorVocales++;
    }
}

Console.WriteLine("Cantidad de vocales: " + contadorVocales);

// ejercicio k
Console.WriteLine("Ejercicio K");
Console.Write("Ingrese un número: ");
int numero = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Tabla de multiplicar del " +numero+":");
for (int i = 1; i <= 12; i++)
 {
 Console.WriteLine(numero + "x" + i + "=" + numero * i);
 }

// ejercicio l
Console.WriteLine("Ejercicio L");
Console.WriteLine("Contador acumulativo. Ingrese números para acumular un total mayor a 100.");
int acumulado = 0;
while (acumulado <= 100)
{
    Console.Write("Ingrese un número: ");
    int numero2 = Convert.ToInt32(Console.ReadLine());
    acumulado += numero2;
    Console.WriteLine("Total acumulado: " + acumulado);
}
Console.WriteLine("¡Has superado el total de 100!");

// ejercicio m
Console.WriteLine("Ejercicio M");
Console.Write("Ingrese una palabra: ");
string palabra = Console.ReadLine();

foreach (char letra in palabra)
{
    Console.WriteLine(letra);
}

// ejercicio n
Console.WriteLine("Ejercicio N");
Console.Write("Ingrese su edad: ");
int edad = Convert.ToInt32(Console.ReadLine());

if (edad >= 18)
{
    Console.WriteLine("Puede votar y manejar.");
}
else if (edad >= 16)
{
    Console.WriteLine("Puede manejar, pero no puede votar.");
}
else
{
    Console.WriteLine("No puede votar ni manejar.");
}

// ejercicio o
Console.WriteLine("Ejercicio O");
Console.WriteLine("Números del 50 al 0 de forma descendente, de cinco en cinco:");
for (int i = 50; i >= 0; i -= 5)
{
    Console.WriteLine(i);
}

// ejercicio p
Console.WriteLine("Ejercicio P");
string contraseña = "";
string confirmacion = "";
Console.Write("Ingrese una contraseña: ");
contraseña = Console.ReadLine();
Console.Write("Confirme la contraseña: ");
confirmacion = Console.ReadLine();
while (contraseña != confirmacion)
{
    Console.WriteLine("Las contraseñas no coinciden. Intente nuevamente.");
    Console.Write("Ingrese una contraseña: ");
    contraseña = Console.ReadLine();

    Console.Write("Confirme la contraseña: ");
    confirmacion = Console.ReadLine();
}
Console.WriteLine("Acceso permitido.");

// ejercicio q
Console.WriteLine("Ejercicio Q");
string nombre = "";
Console.Write("Ingrese un nombre: ");
nombre = Console.ReadLine();
while (nombre.Length <= 10)
{
    Console.WriteLine("Nombre ingresado: " + nombre);
    Console.Write("Ingrese un nombre: ");
    nombre = Console.ReadLine();
}
Console.WriteLine("El nombre tiene más de 10 caracteres. Fin del programa.");

// ejercicio r
Console.WriteLine("Ejercicio R");
Console.Write("Ingrese una oración: ");
string oracion = Console.ReadLine();
int contadorA = 0;
foreach (char letra in oracion)
{
    if (letra == 'a' || letra == 'A')
    {
        contadorA++;
    }
}
Console.WriteLine("La oración tiene " + contadorA + " letras 'a'.");
