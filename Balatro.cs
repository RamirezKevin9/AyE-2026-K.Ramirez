//Programa 4: Balatro parte 1

Console.WriteLine("Bienvenido al juego de Balatro");
string[] cartas = new string[8];
Random random = new Random();
string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
string[] valores = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
while (true)
{
    Console.WriteLine("¿Qué quieres hacer?");
    Console.WriteLine("1. Pedir cartas");
    Console.WriteLine("2. Descartar cartas");
    Console.WriteLine("3. Salir");
    string opcion = Console.ReadLine();
    if (opcion == "1")
    {
        for (int i = 0; i < 8; i++)
        {
            string carta = valores[random.Next(valores.Length)] + " de " + palos[random.Next(palos.Length)];
            cartas[i] = carta;
            Console.WriteLine("Carta obtenida: " + carta);
        }
        Console.WriteLine("Cartas en tu mano:");
        foreach (string carta in cartas)
        {
            Console.WriteLine(carta);
        }
    }
    else if (opcion == "2")
    {
        Console.WriteLine("¿Cuántas cartas quieres descartar?");
        int cantidadDescartar = int.Parse(Console.ReadLine());
        for (int i = 0; i < cantidadDescartar; i++)
        {
            Console.WriteLine("¿Cuál carta quieres descartar? (Escribe el número de la carta)");
            for (int j = 0; j < cartas.Length; j++)
            {
                Console.WriteLine((j + 1) + ". " + cartas[j]);
            }
            int cartaDescartada = int.Parse(Console.ReadLine()) - 1;
            if (cartaDescartada >= 0 && cartaDescartada < cartas.Length)
            {
                cartas[cartaDescartada] = valores[random.Next(valores.Length)] + " de " + palos[random.Next(palos.Length)];
                Console.WriteLine("Carta obtenida: " + cartas[cartaDescartada]);
            }
            else
            {
                Console.WriteLine("Número de carta inválido.");
            }
        }
        Console.WriteLine("Cartas en tu mano:");
        foreach (string carta in cartas)
        {
            Console.WriteLine(carta);
        }
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