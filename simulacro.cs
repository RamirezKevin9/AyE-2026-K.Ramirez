// programa 1
Console.WriteLine("Programa 1:Generando dos equipos de 23 jugadores...");
Console.WriteLine("");

string[] nombres =
{
    "Sergio","Diego","Lucas","Mateo","Nicolás","Javier","Pablo","Enzo","Álvaro","Héctor",
    "Adrián","Marcos","Iván","Gabriel","Antonio"
};
string[] posiciones =  { "Delantero" , "Mediocampista" ,  "Defensor" ,  "Arquero"  };
Random rnd = new Random();

string[,] equipoA = GenerarPlantilla(rnd, nombres, posiciones);
string[,] equipoB = GenerarPlantilla(rnd, nombres, posiciones);

int totalA = CalcularValoracionTotal(equipoA);
int totalB = CalcularValoracionTotal(equipoB);

Console.WriteLine($"Valoración total Equipo A: {totalA}");
Console.WriteLine("");
Console.WriteLine($"Valoración total Equipo B: {totalB}");
Console.WriteLine("");

if (totalA == totalB)
{
    Console.WriteLine("Empate técnico: mismas valoraciones.");
}
else if (totalA > totalB)
{
    Console.WriteLine("Equipo A tiene más probabilidades de ganar.");
}
else
{
    Console.WriteLine("Equipo B tiene más probabilidades de ganar.");
}

static string[,] GenerarPlantilla(Random rnd, string[] nombres, string[] posiciones)
{
    int jugadores = 23;
    string[,] plantilla = new string[jugadores, 3];

    for (int i = 0; i < jugadores; i++)
    {
        string nombre = nombres[rnd.Next(nombres.Length)];
        int valoracion = rnd.Next(50, 101);
        string posicion = posiciones[rnd.Next(posiciones.Length)];

        plantilla[i, 0] = nombre;
        plantilla[i, 1] = valoracion.ToString();
        plantilla[i, 2] = posicion;
    }

    return plantilla;
}

static int CalcularValoracionTotal(string[,] plantilla)
{
    int total = 0;
    for (int i = 0; i < plantilla.GetLength(0); i++)
    {
        if (int.TryParse(plantilla[i, 1], out int v))
        {
            total += v;
        }
    }
    return total;
}

static int EncontrarJugadorMejorValoracion(string[,] plantilla)
{
    int mejorValoracion = 0;
    int indiceMejor = 0;
    for (int i = 0; i < plantilla.GetLength(0); i++)
    {
        if (int.TryParse(plantilla[i, 1], out int v) && v > mejorValoracion)
        {
            mejorValoracion = v;
            indiceMejor = i;
        }
    }
    return indiceMejor;
}

Console.WriteLine("");
Console.WriteLine("Los Jugadores con mayor valoración de cada equipo es:");
Console.WriteLine("");
int indiceMejorA = EncontrarJugadorMejorValoracion(equipoA);
int indiceMejorB = EncontrarJugadorMejorValoracion(equipoB);
Console.WriteLine($"Equipo A: {equipoA[indiceMejorA, 0]} con valoración {equipoA[indiceMejorA, 1]}");
Console.WriteLine("");
Console.WriteLine($"Equipo B: {equipoB[indiceMejorB, 0]} con valoración {equipoB[indiceMejorB, 1]}");

//programa 2

Console.WriteLine("");
Console.WriteLine("Programa 2: Potencia de un número usando recursividad...");
Console.WriteLine("");
Console.Write("Ingrese la base: ");
int baseNum = Convert.ToInt32(Console.ReadLine());
Console.Write("Ingrese el exponente: ");
int exponente = Convert.ToInt32(Console.ReadLine());

int Potencia(int b, int e)
{
    if (e == 0) return 1;
    return b * Potencia(b, e - 1);
}

int resultado = Potencia(baseNum, exponente);
Console.WriteLine($"El resultado de {baseNum}^{exponente} es: {resultado}");