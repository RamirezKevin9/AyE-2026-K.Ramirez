Console.WriteLine("Ingrese un número de dos cifras:");
int numero = int.Parse(Console.ReadLine());

int unidades = numero % 10;
int decenas = numero / 10;

Console.WriteLine("Cifra de las unidades: " + unidades);
Console.WriteLine("Cifra de las decenas: " + decenas);  