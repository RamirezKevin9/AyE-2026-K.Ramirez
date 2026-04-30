// ejercicio 1

Console.Write("Ingrese 0 o 1, si se ingresa otro número, pedir otra vez: ");
int numero = Convert.ToInt32(Console.ReadLine());
while (numero != 0 && numero != 1)
{
    Console.Write("Número inválido. Ingrese 0 o 1: ");
    numero = Convert.ToInt32(Console.ReadLine());
}

// ejercicio 2

Console.Write("Ingrese un número de 2 dígitos:");
int numero2 = Convert.ToInt32(Console.ReadLine());
while ((numero2 < 10 && numero2 > -10) || (numero2 > 99 || numero2 < -99))
{
    Console.Write("Número inválido. Ingrese un número de 2 dígitos: ");
    numero2 = Convert.ToInt32(Console.ReadLine());
}
