Console.WriteLine("Programa 2: Calculadora de factoriales con intentos limitados.");

int intentos = 3;

while (true)
{
    Console.WriteLine("Ingrese un número entero positivo:");
    string entrada = Console.ReadLine();

    bool valido = true;

    // Validar que todos sean números
    for (int i = 0; i < entrada.Length; i++)
    {
        if (entrada[i] < '0' || entrada[i] > '9')
        {
            valido = false;
            break;
        }
    }

    if (valido)
    {
        long numero = Convert.ToInt64(entrada);

        long factorial = 1;
        for (long i = 1; i <= numero; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("El factorial es: " + factorial);
        intentos = 3; // reset
    }
    else
    {
        intentos--;
        if (intentos > 0)
        {
            Console.WriteLine("No es válido (" + intentos + " intentos restantes)");
        }
        else
        {
            Console.WriteLine("No tiene más intentos");
            break;
        }
    }
}
