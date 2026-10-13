using System;
using System.Collections.Generic;
using System.Linq;

namespace Prueba_Base_de_Datos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;

            while (opcion != 8)
            {
                Console.WriteLine("1. Consultar agentes");
                Console.WriteLine("2. Agregar agente");
                Console.WriteLine("3. Actualizar agente");
                Console.WriteLine("4. Eliminar agente");
                Console.WriteLine("5. Buscar agente en el arbol");
                Console.WriteLine("6. Mostrar arbol");
                Console.WriteLine("7. Ordenar alfabeticamente");
                Console.WriteLine("8. Salir");
                Console.Write("Opcion: ");

                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MostrarAgentes(CargarLista());
                        break;

                    case 2:
                        Agregar();
                        break;

                    case 3:
                        Actualizar();
                        break;

                    case 4:
                        Eliminar();
                        break;

                    case 5:
                        Buscar();
                        break;

                    case 6:
                        MostrarArbol();
                        break;

                    case 7:
                        List<datos> agentes = CargarLista();

                        OrdenarBurbuja(agentes);

                        MostrarAgentes(agentes);
                        break;

                    case 8:
                        Console.WriteLine("Programa terminado.");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static List<datos> CargarLista()
        {
            using var db = new AppDbContext();

            return db.agentes_valorant.ToList();
        }

        static void MostrarAgentes(List<datos> agentes)
        {
            foreach (datos agente in agentes)
            {
                Console.WriteLine(agente.id + " - " + agente.nombre_agente + " - " + agente.tipo_agente + " - " + agente.nacionalidad + " - " + agente.fecha_lanzamiento);
            }
        }

        static void Agregar()
        {
            using var db = new AppDbContext();

            datos agente = new datos();

            Console.Write("Nombre: ");
            agente.nombre_agente = Console.ReadLine();

            Console.Write("Tipo: ");
            agente.tipo_agente = Console.ReadLine();

            Console.Write("Nacionalidad: ");
            agente.nacionalidad = Console.ReadLine();

            Console.Write("Fecha de lanzamiento: ");
            agente.fecha_lanzamiento = Console.ReadLine();

            db.agentes_valorant.Add(agente);
            db.SaveChanges();

            Console.WriteLine("Agente agregado.");
        }

        static void Actualizar()
        {
            using var db = new AppDbContext();

            Console.Write("ID del agente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            datos agente = db.agentes_valorant.Find(id);

            if (agente != null)
            {
                Console.Write("Nuevo nombre: ");
                agente.nombre_agente = Console.ReadLine();

                Console.Write("Nuevo tipo: ");
                agente.tipo_agente = Console.ReadLine();

                Console.Write("Nueva nacionalidad: ");
                agente.nacionalidad = Console.ReadLine();

                Console.Write("Nueva fecha: ");
                agente.fecha_lanzamiento = Console.ReadLine();

                db.SaveChanges();

                Console.WriteLine("Agente actualizado.");
            }
            else
            {
                Console.WriteLine("Agente no encontrado.");
            }
        }

        static void Eliminar()
        {
            using var db = new AppDbContext();

            Console.Write("ID del agente: ");
            int id = Convert.ToInt32(Console.ReadLine());

            datos agente = db.agentes_valorant.Find(id);

            if (agente != null)
            {
                db.agentes_valorant.Remove(agente);
                db.SaveChanges();

                Console.WriteLine("Agente eliminado.");
            }
            else
            {
                Console.WriteLine("Agente no encontrado.");
            }
        }

        static ArbolBinario CargarArbol()
        {
            List<datos> agentes = CargarLista();

            ArbolBinario arbol = new ArbolBinario();

            foreach (datos agente in agentes)
            {
                arbol.Insertar(agente);
            }

            return arbol;
        }

        static void Buscar()
        {
            ArbolBinario arbol = CargarArbol();

            Console.Write("ID del agente a buscar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            datos agente = arbol.Buscar(id);

            if (agente != null)
            {
                Console.WriteLine(agente.nombre_agente);
                Console.WriteLine(agente.tipo_agente);
                Console.WriteLine(agente.nacionalidad);
                Console.WriteLine(agente.fecha_lanzamiento);
            }
            else
            {
                Console.WriteLine("Agente no encontrado.");
            }
        }

        static void MostrarArbol()
        {
            ArbolBinario arbol = CargarArbol();

            List<datos> agentes = arbol.RecorridoInOrden();

            MostrarAgentes(agentes);
        }

        static void OrdenarBurbuja(List<datos> agentes)
        {
            for (int i = 0; i < agentes.Count - 1; i++)
            {
                for (int j = 0; j < agentes.Count - 1 - i; j++)
                {
                    string nombreActual = agentes[j].nombre_agente;
                    string nombreSiguiente = agentes[j + 1].nombre_agente;
                    bool intercambiar = false;
                    int posicionLetra = 0;

                    while (posicionLetra < nombreActual.Length && posicionLetra < nombreSiguiente.Length)
                    {
                        if (nombreActual[posicionLetra] > nombreSiguiente[posicionLetra])
                        {
                            intercambiar = true;
                            break;
                        }

                        if (nombreActual[posicionLetra] < nombreSiguiente[posicionLetra])
                        {
                            break;
                        }

                        posicionLetra++;
                    }

                    if (posicionLetra == nombreSiguiente.Length && nombreActual.Length > nombreSiguiente.Length)
                    {
                        intercambiar = true;
                    }

                    if (intercambiar)
                    {
                        datos agenteAuxiliar = agentes[j];
                        agentes[j] = agentes[j + 1];
                        agentes[j + 1] = agenteAuxiliar;
                    }
                }
            }
        }
    }
}