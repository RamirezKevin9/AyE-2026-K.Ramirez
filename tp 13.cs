// Ejercicio 1:
Console.WriteLine("Ejercicio 1:");
string[] nombres = { "canser testicular", "canser de pancreas", "canser de prostata", "canservero", "tienes canser andi", "Cáncer de pulmón", "Cáncer colorrectal", "Cáncer de mama triple negativo", "Cáncer de hígado", "Geografia" };
string palabraMasLarga = "";
for (int i = 0; i < nombres.Length; i++)
{
    if (nombres[i].Length > palabraMasLarga.Length)
    {
        palabraMasLarga = nombres[i];
    }
}
Console.WriteLine("La palabra con la mayor cantidad de caracteres es: " + palabraMasLarga);

// Ejercicio 2:
Console.WriteLine("Ejercicio 2:");
int cantidadVocales = 0;
for (int i = 0; i < nombres.Length; i++)
{
    string palabra = nombres[i].ToLower();
    for (int j = 0; j < palabra.Length; j++)
    {
        char letra = palabra[j];
        if (letra == 'a' || letra == 'e' || letra == 'i' || letra == 'o' || letra == 'u')
        {
            cantidadVocales++;
        }
    }
}
Console.WriteLine("La cantidad total de vocales en todas las palabras es: " + cantidadVocales);

// Ejercicio 3:
Console.WriteLine("Ejercicio 3:");
int[] numeros = { 1, 2, 3, 4, 5, 6, 7 };
int factor = 3;
int[] nuevaLista = new int[numeros.Length];
for (int i = 0; i < numeros.Length; i++)
{
    nuevaLista[i] = numeros[i] * factor;
}
Console.WriteLine("La nueva lista con los números multiplicados por el factor es:");
for (int i = 0; i < nuevaLista.Length; i++)
{
    Console.Write(nuevaLista[i] + " ");
}
