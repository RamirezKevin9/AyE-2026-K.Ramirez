Console.WriteLine("bienvenido a juagar el tateti");

int jugadores;
while (true)
{
    Console.WriteLine("Cuantos jugadores van a jugar? (1 o 2)");
    string inputJugadores = Console.ReadLine();
    if (int.TryParse(inputJugadores, out jugadores) && (jugadores == 1 || jugadores == 2))
        break;
    Console.WriteLine("Entrada inválida. Introduzca 1 o 2.");
}

int[,] tablero = new int[3, 3];
int turno = 1;
Random rnd = new Random();

static void ImprimirTablero(int[,] tablero)
{
    Console.WriteLine();
    Console.WriteLine("   0 1 2");
    for (int i = 0; i < 3; i++)
    {
        Console.Write(i + "  ");
        for (int j = 0; j < 3; j++)
        {
            char c = tablero[i, j] == 0 ? '.' : (tablero[i, j] == 1 ? 'X' : 'O');
            Console.Write(c);
            if (j < 2) Console.Write(' ');
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

static bool VerificarGanador(int[,] tablero, int turno)
{
    for (int i = 0; i < 3; i++)
    {
        if ((tablero[i, 0] == turno && tablero[i, 1] == turno && tablero[i, 2] == turno) ||
            (tablero[0, i] == turno && tablero[1, i] == turno && tablero[2, i] == turno))
        {
            return true;
        }
    }
    if ((tablero[0, 0] == turno && tablero[1, 1] == turno && tablero[2, 2] == turno) ||
        (tablero[0, 2] == turno && tablero[1, 1] == turno && tablero[2, 0] == turno))
    {
        return true;
    }
    return false;
}

static void JugadaMaquina(int[,] tablero, int turno, Random rnd)
{
    if (tablero[1, 1] == 0)
    {
        tablero[1, 1] = turno;
        Console.WriteLine("Máquina jugó en 1,1");
        return;
    }

    (int r, int c)[] libres = new (int, int)[9];
    int count = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (tablero[i, j] == 0)
            {
                libres[count++] = (i, j);
            }
        }
    }

    if (count == 0) return;

    var pick = libres[rnd.Next(count)];
    tablero[pick.r, pick.c] = turno;
    Console.WriteLine($"Máquina jugó en {pick.r},{pick.c}");
}

ImprimirTablero(tablero);

while (true)
{
    try
    {
        Console.WriteLine($"Turno del jugador {turno}");

        if (jugadores == 1 && turno == 2)
        {
            JugadaMaquina(tablero, turno, rnd);
            ImprimirTablero(tablero);

            if (VerificarGanador(tablero, turno))
            {
                Console.WriteLine($"¡Jugador {turno} gana!");
                break;
            }

            bool lleno = true;
            for (int i = 0; i < 3 && lleno; i++)
                for (int j = 0; j < 3 && lleno; j++)
                    if (tablero[i, j] == 0) lleno = false;
            if (lleno)
            {
                Console.WriteLine("Empate. No hay más movimientos.");
                break;
            }
            turno = (turno == 1) ? 2 : 1;
            continue;
        }

        int fila;
        while (true)
        {
            Console.WriteLine("Ingrese la fila (0, 1 o 2):");
            string sf = Console.ReadLine();
            if (int.TryParse(sf, out fila) && fila >= 0 && fila <= 2) 
                break;
            Console.WriteLine("Fila inválida. Ingrese 0, 1 o 2.");
        }

        int columna;
        while (true)
        {
            Console.WriteLine("Ingrese la columna (0, 1 o 2):");
            string sc = Console.ReadLine();
            if (int.TryParse(sc, out columna) && columna >= 0 && columna <= 2) 
                break;
            Console.WriteLine("Columna inválida. Ingrese 0, 1 o 2.");
        }

        if (tablero[fila, columna] == 0)
        {
            tablero[fila, columna] = turno;
            ImprimirTablero(tablero);
            if (VerificarGanador(tablero, turno))
            {
                Console.WriteLine($"¡Jugador {turno} gana!");
                break;
            }

            bool lleno = true;
            for (int i = 0; i < 3 && lleno; i++)
                for (int j = 0; j < 3 && lleno; j++)
                    if (tablero[i, j] == 0) lleno = false;
            if (lleno)
            {
                Console.WriteLine("Empate. No hay más movimientos.");
                break;
            }
            turno = (turno == 1) ? 2 : 1;
        }
        else
        {
            Console.WriteLine("Esa posición ya está ocupada. Intente de nuevo.");
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("Coordenadas fuera de rango. Use valores entre 0 y 2.");
    }
    catch (FormatException)
    {
        Console.WriteLine("Formato no válido en la entrada. Intente de nuevo.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error inesperado: {ex.Message}");
    }
}
