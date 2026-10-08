using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp22
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using var db = new AppDbContext();

            // Insertar

            var nuevo = new Jugador
            {
                nombre = "Juan",
                apellido = "Perez",
                pais = "Argentina",
                posicion = "Delantero",
                goles = 5,
                mundiales_jugados = 2
            };

            db.goleadores_mundial.Add(nuevo);

            await db.SaveChangesAsync();


            // Consultar

            var todos = await db.goleadores_mundial.ToListAsync();

            foreach (var jugador in todos)
            {
                Console.WriteLine(jugador.nombre + " " + jugador.apellido);
            }


            // Ejecutar una linea de SQL

            string sql = "SELECT id, nombre, apellido, pais, posicion, goles, mundiales_jugados FROM goleadores_mundial";

            var lista = await db.goleadores_mundial.FromSqlRaw(sql).ToListAsync();


            // Buscar un jugador en especifico

            int id = 1;

            var jugadorBuscado = await db.goleadores_mundial.FindAsync(id);


            // Update

            if (jugadorBuscado != null)
            {
                jugadorBuscado.nombre = "Lionel";

                await db.SaveChangesAsync();
            }


            // Delete

            if (jugadorBuscado != null)
            {
                db.goleadores_mundial.Remove(jugadorBuscado);

                await db.SaveChangesAsync();
            }


            // Vector con todos los jugadores

            Jugador[] jugadores = await db.goleadores_mundial.ToArrayAsync();


            // Ordenar por orden alfabetico

            OrdenarAlfabeticamente(jugadores);

            Console.WriteLine();

            Console.WriteLine("Jugadores ordenados alfabeticamente:");

            for (int i = 0; i < jugadores.Length; i++)
            {
                Console.WriteLine(jugadores[i].apellido + " " + jugadores[i].nombre);
            }


            // Ordenar por cantidad de mundiales jugados

            OrdenarPorMundiales(jugadores);

            Console.WriteLine();

            Console.WriteLine("Jugadores ordenados por mundiales jugados:");

            for (int i = 0; i < jugadores.Length; i++)
            {
                Console.WriteLine(
                    jugadores[i].nombre + " " +
                    jugadores[i].apellido + " - Mundiales: " +
                    jugadores[i].mundiales_jugados
                );
            }
        }

        static void OrdenarAlfabeticamente(Jugador[] jugadores)
        {
            for (int i = 0; i < jugadores.Length - 1; i++)
            {
                for (int j = 0; j < jugadores.Length - 1 - i; j++)
                {
                    string actual = jugadores[j].apellido + " " + jugadores[j].nombre;
                    string siguiente = jugadores[j + 1].apellido + " " + jugadores[j + 1].nombre;

                    if (actual.CompareTo(siguiente) > 0)
                    {
                        Jugador auxiliar = jugadores[j];
                        jugadores[j] = jugadores[j + 1];
                        jugadores[j + 1] = auxiliar;
                    }
                }
            }
        }

        static void OrdenarPorMundiales(Jugador[] jugadores)
        {
            for (int i = 0; i < jugadores.Length - 1; i++)
            {
                for (int j = 0; j < jugadores.Length - 1 - i; j++)
                {
                    if (jugadores[j].mundiales_jugados < jugadores[j + 1].mundiales_jugados)
                    {
                        Jugador auxiliar = jugadores[j];
                        jugadores[j] = jugadores[j + 1];
                        jugadores[j + 1] = auxiliar;
                    }
                }
            }
        }
    }
}