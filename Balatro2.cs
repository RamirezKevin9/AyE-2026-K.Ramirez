// Programa 4 parte 2

Console.WriteLine("Bienvenido al juego de Balatro");
string[] cartas = new string[8];
Random random = new Random();
string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
string[] valores = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

while (true)
{
    Console.WriteLine();
    Console.WriteLine("¿Qué quieres hacer?");
    Console.WriteLine("1. Pedir cartas");
    Console.WriteLine("2. Descartar cartas");
    Console.WriteLine("3. Salir");
    Console.Write("> ");
    string opcion = Console.ReadLine();

    if (opcion == "1")
    {
        for (int i = 0; i < cartas.Length; i++)
        {
        cartas[i] = GenerarCarta(random, valores, palos);
        Console.WriteLine("Carta obtenida: " + cartas[i]);
        }

    Console.WriteLine("Cartas en tu mano:");
    MostrarMano(cartas);
    }
        else if (opcion == "2")
        {
            if (ManoVacia(cartas))
            {
             Console.WriteLine("No tienes cartas. Primero pide cartas (opción 1).");
            }

            Console.WriteLine("¿Cuántas cartas quieres descartar?");
            Console.Write("> ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadDescartar) || cantidadDescartar <= 0)
            {
             Console.WriteLine("Cantidad inválida.");
            }

                for (int i = 0; i < cantidadDescartar; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("¿Cuál carta quieres descartar? (Escribe el número de la carta)");
                    MostrarMano(cartas);
                    Console.Write("> ");

                    if (!int.TryParse(Console.ReadLine(), out int cartaIndex) ||
                        cartaIndex < 1 || cartaIndex > cartas.Length)
                    {
                        Console.WriteLine("Número de carta inválido.");
                        i--; 
                    }

                    int idx = cartaIndex - 1;
                    cartas[idx] = GenerarCarta(random, valores, palos);
                    Console.WriteLine("Carta obtenida: " + cartas[idx]);
                }

                Console.WriteLine("Cartas en tu mano:");
                MostrarMano(cartas);
        }
            else if (opcion == "3")
            {
                Console.WriteLine("Gracias por jugar. ¡Hasta luego!");
                break;
            }
            else
            {
                Console.WriteLine("Opción inválida. Por favor, elige una opción válida.");
            }
}

static string GenerarCarta(Random random, string[] valores, string[] palos)
{
        string valor = valores[random.Next(valores.Length)];
        string palo = palos[random.Next(palos.Length)];
        return $"{valor} de {palo}";
}

static void MostrarMano(string[] mano)
{
        for (int i = 0; i < mano.Length; i++)
        {
            string carta = mano[i] ?? "(vacía)";
            Console.WriteLine($"{i + 1}. {carta}");
        }
}

static bool ManoVacia(string[] mano)
{
        for (int i = 0; i < mano.Length; i++)
        {
            if (mano[i] != null) return false;
        }
        return true;
}