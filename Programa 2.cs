Console.WriteLine("Programa 2: Calculadora de factoriales con intentos limitados.");
Console.WriteLine("Ingrese un número entero positivo para calcular su factorial:");
string frase = Console.ReadLine();
int numero = Convert.ToInt32(frase);
int factorial = 1;
int intentos = 3;
intentos = intentos - 1;
Console.WriteLine("intentos restantes:" + intentos);

while (intentos > 0)
{

    bool tieneEspecial = false;
    for (int i = 0; i < frase.Length; i++)
    {
        char letra = frase[i];
        if ((letra < '0' || letra > '9'))
        {
            for (int f = 1; f <= numero; f++)
            {
                factorial = factorial * f;

            }
            Console.WriteLine($"El factorial de {numero} es: {factorial}");
            Console.WriteLine("ingrese otro numero para calcular su factorial:");
            numero = Convert.ToInt32(Console.ReadLine());
            intentos = 3;
        }
    }

    if (tieneEspecial)
    {
        Console.WriteLine("La frase contiene caracteres especiales o numeros negativos. Por favor, ingrese un numero entero positivo sin caracteres especiales.");
        intentos--;
        continue;
    }

    break;
}


while (intentos > 0)
{
    if (numero < 0)
    {
        intentos--;
        Console.WriteLine("Número inválido. Por favor, ingrese un número entero positivo:");
        numero = Convert.ToInt32(Console.ReadLine());
    }
    else
    {
        for (int f = 1; f <= numero; f++)
        {
            factorial = factorial * f;

        }
        Console.WriteLine($"El factorial de {numero} es: {factorial}");
        Console.WriteLine("ingrese otro numero para calcular su factorial:");
        numero = Convert.ToInt32(Console.ReadLine());
        intentos = 3;
    }
    Console.WriteLine("intentos restantes:" + intentos);
}