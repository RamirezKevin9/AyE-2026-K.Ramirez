using System;

Console.WriteLine("Bienvenido al juego de Balatro");

const int posiciones = 8;

string[,] cartas = new string[posiciones, 2];
int[,] valores_cartas = new int[posiciones, 1];
Random generador_aleatorio = new Random();

string[,] palos = new string[1, 4] { { "Corazones", "Diamantes", "Tréboles", "Picas" } };
string[,] valores = new string[1, 13] { { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" } };

while (true)
{
    Console.WriteLine();
    Console.WriteLine("1) Pedir cartas  2) Descartar  3) Mostrar mano  4) Salir");
    Console.Write("> ");
    string opcion = LeerLineaConTryCatch();

    if (opcion == "1")
    {
        for (int i = 0; i < posiciones; i++)
        {
            GenerarYAsignarCarta(generador_aleatorio, valores, palos, cartas, valores_cartas, i);
        }
        MostrarMano(cartas, valores_cartas);
    }
    else if (opcion == "2")
    {
        int cartas_disponibles = CantidadCartasEnMano(cartas);
        if (cartas_disponibles == 0)
        {
            Console.WriteLine("No tienes cartas. Primero pide cartas (opción 1).");
        }
        else
        {
            MostrarMano(cartas, valores_cartas);
            Console.Write($"¿Cuántas cartas quieres descartar? (1-{cartas_disponibles}): ");
            string entrada_cantidad = LeerLineaConTryCatch();
            bool parseo_cantidad = int.TryParse(entrada_cantidad, out int cantidad_a_descartar);
            if (!parseo_cantidad || cantidad_a_descartar < 1 || cantidad_a_descartar > cartas_disponibles)
            {
                Console.WriteLine("Cantidad inválida.");
            }
            else
            {
                for (int iteracion = 0; iteracion < cantidad_a_descartar; iteracion++)
                {
                    int indice_valido = -1;
                    bool entrada_valida = false;
                    while (!entrada_valida)
                    {
                        Console.Write($"Número de carta a descartar #{iteracion + 1} (1-{posiciones}): ");
                        string entrada_numero = LeerLineaConTryCatch();
                        bool parseo_numero = int.TryParse(entrada_numero, out int numero_posicion);
                        if (!parseo_numero)
                        {
                            Console.WriteLine("Entrada inválida. Intenta de nuevo.");
                        }
                        else if (numero_posicion < 1 || numero_posicion > posiciones)
                        {
                            Console.WriteLine("Número fuera de rango. Intenta de nuevo.");
                        }
                        else
                        {
                            int indice = numero_posicion - 1;
                            if (string.IsNullOrEmpty(cartas[indice, 0]))
                            {
                                Console.WriteLine("Esa posición está vacía. Elige otra.");
                            }
                            else
                            {
                                indice_valido = indice;
                                entrada_valida = true;
                            }
                        }
                    }

                    GenerarYAsignarCarta(generador_aleatorio, valores, palos, cartas, valores_cartas, indice_valido);
                    Console.WriteLine($"{indice_valido + 1}. {cartas[indice_valido, 0]} de {cartas[indice_valido, 1]} (valor {valores_cartas[indice_valido, 0]})");
                }
                MostrarMano(cartas, valores_cartas);
            }
        }
    }
    else if (opcion == "3")
    {
        MostrarMano(cartas, valores_cartas);
    }
    else if (opcion == "4")
    {
        Console.WriteLine("Hasta luego.");
        break;
    }
    else
    {
        Console.WriteLine("Opción inválida.");
    }
}

static string LeerLineaConTryCatch()
{
    try
    {
        string? entrada = Console.ReadLine();
        if (entrada is null)
        {
            throw new InvalidOperationException("La lectura de la consola devolvió null.");
        }
        return entrada;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Entrada nula: {ex.Message}");
        return string.Empty;
    }
    catch (System.IO.IOException ex)
    {
        Console.WriteLine($"Error de E/S al leer la entrada: {ex.Message}");
        return string.Empty;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al leer la entrada: {ex.Message}");
        return string.Empty;
    }
}

static void GenerarYAsignarCarta(Random generador, string[,] valores, string[,] palos, string[,] cartas, int[,] valores_cartas, int posicion)
{
    int columnas_valores = valores.GetLength(1);
    int columnas_palos = palos.GetLength(1);

    string valor_texto = valores[0, generador.Next(columnas_valores)];
    string palo_texto = palos[0, generador.Next(columnas_palos)];
    int valor_numerico = ValorDesdeString(valor_texto);

    cartas[posicion, 0] = valor_texto;
    cartas[posicion, 1] = palo_texto;
    valores_cartas[posicion, 0] = valor_numerico;
}

static int ValorDesdeString(string texto_valor)
{
    if (int.TryParse(texto_valor, out int numero)) return numero;
    return texto_valor switch
    {
        "J" => 11,
        "Q" => 12,
        "K" => 13,
        "A" => 14,
        _ => 0
    };
}

static void MostrarMano(string[,] cartas, int[,] valores_cartas)
{
    Console.WriteLine("Mano:");
    for (int i = 0; i < cartas.GetLength(0); i++)
    {
        string valor_texto = cartas[i, 0];
        if (string.IsNullOrEmpty(valor_texto))
        {
            Console.WriteLine($"{i + 1}. (vacía)");
        }
        else
        {
            Console.WriteLine($"{i + 1}. {valor_texto} de {cartas[i, 1]} (valor {valores_cartas[i, 0]})");
        }
    }
}

static int CantidadCartasEnMano(string[,] cartas)
{
    int total_en_mano = 0;
    for (int i = 0; i < cartas.GetLength(0); i++)
    {
        if (!string.IsNullOrEmpty(cartas[i, 0])) total_en_mano++;
    }
    return total_en_mano;
}
