// Ejercicio A
Console.WriteLine("Ejercicio A: Simulación de votación y que termine cuando coloque terminar");
Console.WriteLine("1. Nicolas Maduro");
Console.WriteLine("2. Adolf Hitler");
Console.WriteLine("3. Claudia Sheinbaum");
int votoNicolas = 0;
int votoAdolf = 0;
int votoClaudia = 0;
bool continuarVotando = true;
while (continuarVotando)
{
    Console.WriteLine("Ingrese su voto (1, 2, 3) o 'terminar' para finalizar:");
    string input = Console.ReadLine();
    if (input.ToLower() == "terminar")
    {
        continuarVotando = false;
    }
    else
    {
        switch (input)
        {
            case "1":
                votoNicolas++;
                break;
            case "2":
                votoAdolf++;
                break;
            case "3":
                votoClaudia++;
                break;
            default:
                Console.WriteLine("Voto no válido. Por favor, ingrese 1, 2, 3 o 'terminar'.");
                break;
        }
    }
}
Console.WriteLine("Resultados de la votación:");
Console.WriteLine($"Nicolas Maduro: {votoNicolas} votos");
Console.WriteLine($"Adolf Hitler: {votoAdolf} votos");
Console.WriteLine($"Claudia Sheinbaum: {votoClaudia} votos");

// Ejercicio B
Console.WriteLine("Ejercicio B: Mostrar números impares desde 1 hasta el número ingresado");
Console.WriteLine("Ingrese un número:");
int numero = Convert.ToInt32(Console.ReadLine());
if (numero < 1)
{
    Console.WriteLine("No se puede ingresar un número menor que 1.");
}
else
{
    Console.WriteLine($"Números impares desde 1 hasta {numero}:");
    for (int i = 1; i <= numero; i++)
    {
        if (i % 2 != 0)
        {
            Console.WriteLine(i);
        }
    }
}

// Ejercicio C
Console.WriteLine("Ejercicio C: Contar la cantidad de veces que aparece una letra en una palabra");
Console.WriteLine("Ingrese una palabra:");
string palabra = Console.ReadLine();
Console.WriteLine("Ingrese una letra:");
char letra = Console.ReadLine()[0];
int contador = 0;
foreach (char c in palabra)
{
    if (c == letra)
    {
        contador++;
    }
}
Console.WriteLine($"La letra '{letra}' aparece {contador} veces en la palabra '{palabra}'.");

// Ejercicio D
Console.WriteLine("Ejercicio D: Simulación de una cuenta bancaria");
int saldo = 1000;
bool continuar = true;
while (continuar)
{
    Console.WriteLine($"Saldo actual: ${saldo}");
    Console.WriteLine("Seleccione una opción: 1. Depositar dinero 2. Retirar dinero 3. Salir");
    string opcion = Console.ReadLine();
    switch (opcion)
    {
        case "1":
            Console.WriteLine("Ingrese la cantidad a depositar:");
            int deposito = Convert.ToInt32(Console.ReadLine());
            saldo += deposito;
            break;
        case "2":
            Console.WriteLine("Ingrese la cantidad a retirar:");
            int retiro = Convert.ToInt32(Console.ReadLine());
            if (retiro > saldo)
            {
                Console.WriteLine("No se puede retirar más de lo que tiene en el saldo.");
            }
            else
            {
                saldo -= retiro;
            }
            break;
        case "3":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción no válida. Por favor, seleccione 1, 2 o 3.");
            break;
    }
}

// Ejercicio E

Console.WriteLine("Ejercicio E: ");
int contador2 = 0;
int numeroE = 1;
while (contador < 50)
{
    if ((numeroE % 2 == 0 || numeroE % 5 == 0) && !(numeroE % 2 == 0 && numeroE % 5 == 0))
    {
        Console.WriteLine(numeroE);
        contador++;
    }
    numeroE++;
}