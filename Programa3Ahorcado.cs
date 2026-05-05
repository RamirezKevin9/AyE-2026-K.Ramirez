    
Console.WriteLine("Juego de adivinanza de palabras:");
Console.Write("Ingrese la palabra a adivinar:");
string palabra = Console.ReadLine().ToUpper();
string palabraAdivinada = new string('_', palabra.Length);
int intentos = 7;
 
    while (intentos > 0 && palabraAdivinada.Contains('_'))
{
    Console.WriteLine($"Palabra: {palabraAdivinada}");
    Console.WriteLine($"Intentos restantes: {intentos}");
    Console.WriteLine("Ingrese una letra:");
    char letra = Console.ReadLine()[0];
    if (palabra.Contains(letra))
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            if (palabra[i] == letra)
            {
                palabraAdivinada = palabraAdivinada.Remove(i, 1).Insert(i, letra.ToString());
            }
        }
    }
    else
    {
        intentos--;
    }
}
if (palabraAdivinada == palabra)
{
    Console.WriteLine($"¡Felicidades! Adivinaste la palabra: {palabra}");
}
else
{
    Console.WriteLine($"Se acabaron los intentos. La palabra era: {palabra}");
}
