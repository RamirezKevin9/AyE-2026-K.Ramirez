
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("POKEDEX");
                Console.WriteLine("1. Consultar pokemon");
                Console.WriteLine("2. Agregar pokemon");
                Console.WriteLine("3. Actualizar pokemon");
                Console.WriteLine("4. Eliminar pokemon");
                Console.WriteLine("5. Buscar pokemon en el arbol");
                Console.WriteLine("6. Salir");
                Console.Write("Elegir opcion: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        ConsultarPokemons();
                        break;

                    case 2:
                        AgregarPokemon();
                        break;

                    case 3:
                        ActualizarPokemon();
                        break;

                    case 4:
                        EliminarPokemon();
                        break;

                    case 5:
                        BuscarPokemon(arbol);
                        break;

                    case 6:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcion != 6);
        }

        static void ConsultarPokemons()
        {
            using (var db = new AppDbContext())
            {
                Console.Write("Ingrese el ID del pokemon: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string consulta = "SELECT * FROM pokemon WHERE id = {0}";

                pokedex pokemon = db.pokemon
                    .FromSqlRaw(consulta, id)
                    .FirstOrDefault();

                if (pokemon == null)
                {
                    Console.WriteLine("No existe un pokemon con ese ID.");
                    return;
                }

                MostrarPokemon(pokemon);
            }
        }

        static void AgregarPokemon()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("AGREGAR POKEMON");

                Console.Write("ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string buscar = "SELECT * FROM pokemon WHERE id = {0}";

                pokedex existente = db.pokemon
                    .FromSqlRaw(buscar, id)
                    .FirstOrDefault();

                if (existente != null)
                {
                    Console.WriteLine("Ya existe un pokemon con ese ID.");
                    return;
                }

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Tipo 1: ");
                string tipo1 = Console.ReadLine();

                Console.Write("Tipo 2: ");
                string tipo2 = Console.ReadLine();

                Console.Write("HP: ");
                int hp = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ataque: ");
                int ataque = Convert.ToInt32(Console.ReadLine());

                Console.Write("Defensa: ");
                int defensa = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ataque especial: ");
                int ataqueEspecial = Convert.ToInt32(Console.ReadLine());

                Console.Write("Defensa especial: ");
                int defensaEspecial = Convert.ToInt32(Console.ReadLine());

                Console.Write("Velocidad: ");
                int velocidad = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nivel: ");
                int nivel = Convert.ToInt32(Console.ReadLine());

                string consulta = "INSERT INTO pokemon " +
                    "(id, nombre, tipo_1, tipo_2, hp, ataque, defensa, ataque_especial, defensa_especial, velocidad, nivel) " +
                    "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})";

                db.Database.ExecuteSqlRaw(
                    consulta,
                    id,
                    nombre,
                    tipo1,
                    tipo2,
                    hp,
                    ataque,
                    defensa,
                    ataqueEspecial,
                    defensaEspecial,
                    velocidad,
                    nivel
                );

                Console.WriteLine("Pokemon agregado correctamente.");
            }
        }

        static void ActualizarPokemon()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("ACTUALIZAR POKEMON");

                Console.Write("Ingrese el ID del pokemon: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string buscar = "SELECT * FROM pokemon WHERE id = {0}";

                pokedex pokemon = db.pokemon
                    .FromSqlRaw(buscar, id)
                    .FirstOrDefault();

                if (pokemon == null)
                {
                    Console.WriteLine("No existe un pokemon con ese ID.");
                    return;
                }

                Console.WriteLine("Pokemon actual:");
                MostrarPokemon(pokemon);

                Console.WriteLine("Ingrese los nuevos datos.");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Tipo 1: ");
                string tipo1 = Console.ReadLine();

                Console.Write("Tipo 2: ");
                string tipo2 = Console.ReadLine();

                Console.Write("HP: ");
                int hp = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ataque: ");
                int ataque = Convert.ToInt32(Console.ReadLine());

                Console.Write("Defensa: ");
                int defensa = Convert.ToInt32(Console.ReadLine());

                Console.Write("Ataque especial: ");
                int ataqueEspecial = Convert.ToInt32(Console.ReadLine());

                Console.Write("Defensa especial: ");
                int defensaEspecial = Convert.ToInt32(Console.ReadLine());

                Console.Write("Velocidad: ");
                int velocidad = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nivel: ");
                int nivel = Convert.ToInt32(Console.ReadLine());

                string consulta = "UPDATE pokemon SET " +
                    "nombre = {0}, tipo_1 = {1}, tipo_2 = {2}, hp = {3}, " +
                    "ataque = {4}, defensa = {5}, ataque_especial = {6}, " +
                    "defensa_especial = {7}, velocidad = {8}, nivel = {9} " +
                    "WHERE id = {10}";

                db.Database.ExecuteSqlRaw(
                    consulta,
                    nombre,
                    tipo1,
                    tipo2,
                    hp,
                    ataque,
                    defensa,
                    ataqueEspecial,
                    defensaEspecial,
                    velocidad,
                    nivel,
                    id
                );

                Console.WriteLine("Pokemon actualizado correctamente.");
            }
        }

        static void EliminarPokemon()
        {
            using (var db = new AppDbContext())
            {
                Console.WriteLine("===== ELIMINAR POKEMON =====");

                Console.Write("Ingrese el ID del pokemon: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string consulta = "SELECT * FROM pokemon WHERE id = {0}";

                pokedex pokemon = db.pokemon
                    .FromSqlRaw(consulta, id)
                    .FirstOrDefault();

                if (pokemon == null)
                {
                    Console.WriteLine("No existe un pokemon con ese ID.");
                    return;
                }

                Console.WriteLine("Pokemon encontrado:");
                MostrarPokemon(pokemon);

                Console.Write("Seguro que quiere eliminarlo? (s/n): ");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() == "s")
                {
                    db.Database.ExecuteSqlRaw(
                        "DELETE FROM pokemon WHERE id = {0}", id
                    );

                    Console.WriteLine("Pokemon eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Eliminacion cancelada.");
                }
            }
        }

        static void BuscarPokemon(ArbolBinario arbol)
        {
            using (var db = new AppDbContext())
            {
                arbol.raiz = null;

                var pokemons = db.pokemon
                    .ToList();

                foreach (var pokemon in pokemons)
                {
                    arbol.Insertar(pokemon);
                }
            }

            Console.WriteLine("BUSCAR EN EL ARBOL");

            Console.Write("Ingrese el ID que quiere buscar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            pokedex pokemonEncontrado = arbol.Buscar(id);

            if (pokemonEncontrado == null)
            {
                Console.WriteLine("No se encontro ningun pokemon con ese ID.");
            }
            else
            {
                Console.WriteLine("Pokemon encontrado:");
                MostrarPokemon(pokemonEncontrado);
            }
        }

        static void MostrarPokemon(pokedex pokemon)
        {
            Console.WriteLine("ID: " + pokemon.id);
            Console.WriteLine("Nombre: " + pokemon.nombre);
            Console.WriteLine("Tipo 1: " + pokemon.tipo_1);
            Console.WriteLine("Tipo 2: " + pokemon.tipo_2);
            Console.WriteLine("HP: " + pokemon.hp);
            Console.WriteLine("Ataque: " + pokemon.ataque);
            Console.WriteLine("Defensa: " + pokemon.defensa);
            Console.WriteLine("Ataque especial: " + pokemon.ataque_especial);
            Console.WriteLine("Defensa especial: " + pokemon.defensa_especial);
            Console.WriteLine("Velocidad: " + pokemon.velocidad);
            Console.WriteLine("Nivel: " + pokemon.nivel);
        }
    }
}