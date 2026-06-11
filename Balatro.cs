Console.WriteLine("Bienvenido al juego de Balatro");
string[] cartas = new string[8];
int[] valoresCartas = new int[8];
Random rnd = new Random();
string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
string[] valores = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

while (true)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("1) Pedir cartas  2) Descartar  3) Mostrar mano  4) Salir");
        Console.Write("> ");
        string opc = Console.ReadLine();

        if (opc == "1")
        {
            for (int i = 0; i < cartas.Length; i++)
            {
                cartas[i] = GenerarCarta(rnd, valores, palos, out int val);
                valoresCartas[i] = val;
            }
            MostrarMano(cartas, valoresCartas);
        }
        else if (opc == "2")
        {
            int disponibles = CantidadCartasEnMano(cartas);
            if (disponibles == 0)
            {
                Console.WriteLine("No tienes cartas. Primero pide cartas (opción 1).");
                continue;
            }

            MostrarMano(cartas, valoresCartas);
            Console.Write($"¿Cuántas cartas quieres descartar? (1-{disponibles}): ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad) || cantidad < 1 || cantidad > disponibles)
            {
                Console.WriteLine("Cantidad inválida.");
                continue;
            }

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Número de carta a descartar #{i + 1} (1-8): ");
                if (!int.TryParse(Console.ReadLine(), out int n) || n < 1 || n > cartas.Length)
                {
                    Console.WriteLine("Entrada inválida. Intenta de nuevo esta carta.");
                    i--;
                    continue;
                }

                int idx = n - 1;
                if (string.IsNullOrEmpty(cartas[idx]))
                {
                    Console.WriteLine("Esa posición está vacía. Elige otra.");
                    i--;
                    continue;
                }

                cartas[idx] = GenerarCarta(rnd, valores, palos, out int nuevoVal);
                valoresCartas[idx] = nuevoVal;
                Console.WriteLine($"Reemplazada posición {n}: {cartas[idx]} (valor {valoresCartas[idx]})");
            }

            MostrarMano(cartas, valoresCartas);
        }
        else if (opc == "3")
        {
            MostrarMano(cartas, valoresCartas);
        }
        else if (opc == "4")
        {
            Console.WriteLine("Hasta luego.");
            break;
        }
        else
        {
            Console.WriteLine("Opción inválida.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

static string GenerarCarta(Random rnd, string[] valores, string[] palos, out int valorNum)
{
    string v = valores[rnd.Next(valores.Length)];
    string p = palos[rnd.Next(palos.Length)];
    valorNum = ValorDesdeString(v);
    return $"{v} de {p}";
}

static int ValorDesdeString(string s)
{
    if (int.TryParse(s, out int n)) return n;
    return s switch
    {
        "J" => 11,
        "Q" => 12,
        "K" => 13,
        "A" => 14,
        _ => 0
    };
}

static void MostrarMano(string[] cartas, int[] valores)
{
    Console.WriteLine("Mano:");
    for (int i = 0; i < cartas.Length; i++)
    {
        string c = string.IsNullOrEmpty(cartas[i]) ? "(vacía)" : cartas[i];
        int v = valores[i];
        Console.WriteLine($"{i + 1}. {c} {(string.IsNullOrEmpty(cartas[i]) ? "" : $"(valor {v})")}");
    }
}

static int CantidadCartasEnMano(string[] cartas)
{
    int cnt = 0;
    for (int i = 0; i < cartas.Length; i++)
    {
        if (!string.IsNullOrEmpty(cartas[i])) cnt++;
    }
    return cnt;
}
