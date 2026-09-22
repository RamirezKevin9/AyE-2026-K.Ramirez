using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp16
{
    internal class Program
    {
        struct Punto2D
        {
            public int x;
            public int y;
            public Punto2D(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void Mostrar()
            {
                Console.WriteLine($"({x}, {y})");
            }
            public void ingresar()
            {
                Console.Write("Ingrese coordenada x: ");
                x = int.Parse(Console.ReadLine());
                Console.Write("Ingrese coordenada y: ");
                y = int.Parse(Console.ReadLine());
            }
        }

        static async Task Main(string[] args)
        {
            Punto2D puntoinsert = new Punto2D();
            puntoinsert.ingresar();
            puntoinsert.Mostrar();

            using var vector = new AppDbContext();
            //Insertar

            var punto = new vector
            {
                x = 3,
                y = 2
            };

            var punto2 = new vector
            {
                x = 4,
                y = 6
            };

            var punto3 = new vector
            {
                x = 8,
                y = 1
            };

            vector.vector.Add(punto);
            vector.vector.Add(punto2);
            vector.vector.Add(punto3);
            await vector.SaveChangesAsync();

            var puntoBuscado3 = await vector.vector.FindAsync(punto3.Id);
            if (puntoBuscado3 != null)
            {
                puntoBuscado3.x = puntoinsert.x;
                puntoBuscado3.y = puntoinsert.y;
                await vector.SaveChangesAsync();
            }

            var puntoBuscado1 = await vector.vector.FindAsync(punto.Id);
            if (puntoBuscado1 != null)
            {
                vector.vector.Remove(puntoBuscado1);
                await vector.SaveChangesAsync();
            }

            Console.WriteLine("\nPuntos en la base de datos:");
            var todos = await vector.vector.ToListAsync();
            foreach (var e in todos)
            {
                Console.WriteLine($"ID: {e.Id} -> ({e.x}, {e.y})");
            }
        }
    }
}