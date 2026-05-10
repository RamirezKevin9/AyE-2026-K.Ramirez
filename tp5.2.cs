// Ejercicio 1
Console.WriteLine("Ejercicio 1");

void Contraseña()
{
    string correcta = "777";
    string ingresada = Console.ReadLine();

    if (ingresada == correcta)
    {
        Console.WriteLine("Contraseña correcta");
    }
    else
    {
        Console.WriteLine("Intente otra vez");
        Contraseña();
    }
}

Contraseña();


// Ejercicio 2
Console.WriteLine("Ejercicio 2");

void Cuenta(int numero)
{
    if (numero >= 1)
    {
        Console.WriteLine(numero);
        Cuenta(numero - 1);
    }
    else
    {
        Console.WriteLine("¡Despegue!");
    }
}

Cuenta(5);


// Ejercicio 3
Console.WriteLine("Ejercicio 3");

void Adivinar()
{
    int numero = Convert.ToInt32(Console.ReadLine());

    if (numero == 7)
    {
        Console.WriteLine("¡Correcto!");
    }
    else
    {
        Console.WriteLine("Pruebe otra vez");
        Adivinar();
    }
}

Adivinar();


// Ejercicio 4
Console.WriteLine("Ejercicio 4");

void Suma(int total)
{
    int numero = Convert.ToInt32(Console.ReadLine());

    if (numero == 0)
    {
        Console.WriteLine(total);
    }
    else
    {
        Suma(total + numero);
    }
}

Suma(0);
