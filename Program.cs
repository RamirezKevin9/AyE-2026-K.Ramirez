namespace ConsoleApp21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lista_desordenada ={
            37, 12, 89, 45, 3, 71, 56, 28, 94, 19,
            63, 7, 82, 41, 100, 25, 68, 14, 53, 90,
            31, 76, 9, 47, 85, 22, 60, 5, 98, 34,
            73, 16, 51, 88, 2, 66, 39, 92, 20, 57,
            80, 11, 44, 70, 27, 96, 8, 62, 35, 49
            };

            int[] lista_ordenada = {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };


            /*
            BUSQUEDA SECUENCIAL SIMPLE

            Explicación:
            Busca el número recorriendo la lista desde el principio.

            Condiciones:
            No hace falta que la lista esté ordenada.

            Complejidad:
            O(n), porque puede tener que revisar todos los números.
            */
            int busquedasecuencialsimple(int[] vector)
            {
                Console.Write("Ingrese el número que quiere buscar: ");
                int valorBuscado = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < vector.Length; i++)
                {
                    if (vector[i] == valorBuscado)
                    {
                        return i;
                    }
                }

                return -1;
            }


            /*
            BUSQUEDA SECUENCIAL OPTIMIZADA

            Explicación:
            Busca el número y puede dejar de buscar antes si encuentra uno mayor.

            Condiciones:
            La lista tiene que estar ordenada.

            Complejidad:
            O(n), porque puede tener que revisar todos los números.
            */
            int busquedasecuencialoptimizada(int[] vector)
            {
                Console.Write("Ingrese el número que quiere buscar: ");
                int valorBuscado = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < vector.Length; i++)
                {
                    if (vector[i] == valorBuscado)
                    {
                        return i;
                    }
                    else if (vector[i] > valorBuscado)
                    {
                        return -1;
                    }
                }

                return -1;
            }


            /*
            BUSQUEDA BINARIA

            Explicación:
            Busca el número dividiendo la lista por la mitad cada vez.

            Condiciones:
            La lista tiene que estar ordenada.

            Complejidad:
            O(log n), porque cada vez busca en una parte más chica.
            */
            int busquedabinaria(int[] vector)
            {
                Console.Write("Ingrese el número que quiere buscar: ");
                int valorBuscado = Convert.ToInt32(Console.ReadLine());

                int inicio = 0;
                int fin = vector.Length - 1;

                while (inicio <= fin)
                {
                    int medio = (inicio + fin) / 2;

                    if (vector[medio] == valorBuscado)
                    {
                        return medio;
                    }
                    else if (vector[medio] < valorBuscado)
                    {
                        inicio = medio + 1;
                    }
                    else
                    {
                        fin = medio - 1;
                    }
                }

                return -1;
            }


            /*
            BUSQUEDA BINARIA RECURSIVA

            Explicación:
            Hace lo mismo que la búsqueda binaria, pero se llama a sí misma.

            Condiciones:
            La lista tiene que estar ordenada.

            Complejidad:
            O(log n), porque cada vez busca en la mitad de la lista.
            */
            int busquedabinariarecursiva(int[] vector, int valorBuscado, int inicio, int fin)
            {
                if (inicio > fin)
                {
                    return -1;
                }

                int medio = (inicio + fin) / 2;

                if (vector[medio] == valorBuscado)
                {
                    return medio;
                }
                else if (vector[medio] < valorBuscado)
                {
                    return busquedabinariarecursiva(vector, valorBuscado, medio + 1, fin);
                }
                else
                {
                    return busquedabinariarecursiva(vector, valorBuscado, inicio, medio - 1);
                }
            }


            /*
            BURBUJA CLASICO

            Explicación:
            Compara números que están juntos y los cambia si están al revés.

            Condiciones:
            Puede usarse con una lista desordenada.

            Complejidad:
            O(n²), porque tiene que hacer muchas comparaciones.
            */
            void ordenamientoburbujaclasico(int[] vector)
            {
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    for (int j = 0; j < vector.Length - i - 1; j++)
                    {
                        if (vector[j] > vector[j + 1])
                        {
                            int temp = vector[j];
                            vector[j] = vector[j + 1];
                            vector[j + 1] = temp;
                        }
                    }
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write(vector[i] + " ");
                }

                Console.WriteLine();
            }


            /*
            BURBUJA OPTIMIZADO

            Explicación:
            Es como el burbuja clásico, pero deja de trabajar si ya está ordenado.

            Condiciones:
            Puede usarse con una lista desordenada.

            Complejidad:
            O(n²), porque en el peor caso hace muchas comparaciones.
            */
            void ordenamientoburbujaoptimizado(int[] vector)
            {
                bool intercambio;

                for (int i = 0; i < vector.Length - 1; i++)
                {
                    intercambio = false;

                    for (int j = 0; j < vector.Length - i - 1; j++)
                    {
                        if (vector[j] > vector[j + 1])
                        {
                            int temp = vector[j];
                            vector[j] = vector[j + 1];
                            vector[j + 1] = temp;

                            intercambio = true;
                        }
                    }

                    if (!intercambio)
                    {
                        break;
                    }
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write(vector[i] + " ");
                }

                Console.WriteLine();
            }


            /*
            SELECCION

            Explicación:
            Busca el número más chico y lo pone en la posición correcta.

            Condiciones:
            Puede usarse con una lista desordenada.

            Complejidad:
            O(n²), porque tiene que buscar el menor varias veces.
            */
            void ordenamientoselecion(int[] vector)
            {
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    int min = i;

                    for (int j = i + 1; j < vector.Length; j++)
                    {
                        if (vector[j] < vector[min])
                        {
                            min = j;
                        }
                    }

                    int temporal = vector[min];
                    vector[min] = vector[i];
                    vector[i] = temporal;
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write(vector[i] + " ");
                }

                Console.WriteLine();
            }


            /*
            INSERCION

            Explicación:
            Agarra cada número y lo coloca en el lugar que corresponde.

            Condiciones:
            Puede usarse con una lista desordenada.

            Complejidad:
            O(n²), porque puede tener que mover muchos números.
            */
            void ordenamientoinsercion(int[] vector)
            {
                for (int i = 1; i < vector.Length; i++)
                {
                    int tem = vector[i];
                    int j = i - 1;

                    while (j >= 0 && vector[j] > tem)
                    {
                        vector[j + 1] = vector[j];
                        j--;
                    }

                    vector[j + 1] = tem;
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write(vector[i] + " ");
                }

                Console.WriteLine();
            }


            /*
            QUICKSORT

            Explicación:
            Elige un número como pivote y separa los números menores y mayores.

            Condiciones:
            Puede usarse con una lista desordenada.

            Complejidad:
            O(n log n), porque normalmente ordena rápido.
            */
            void quicksort(int[] vector, int inicio, int fin)
            {
                if (inicio < fin)
                {
                    int pivote = vector[fin];
                    int i = inicio - 1;

                    for (int j = inicio; j < fin; j++)
                    {
                        if (vector[j] <= pivote)
                        {
                            i++;

                            int temporal = vector[i];
                            vector[i] = vector[j];
                            vector[j] = temporal;
                        }
                    }

                    int temporal2 = vector[i + 1];
                    vector[i + 1] = vector[fin];
                    vector[fin] = temporal2;

                    int posicionPivote = i + 1;

                    quicksort(vector, inicio, posicionPivote - 1);
                    quicksort(vector, posicionPivote + 1, fin);
                }
            }


            /*
            STALIN SORT

            Explicación:
            Elimina los números que son menores que el último número que dejó.

            Condiciones:
            Puede usarse con una lista desordenada.

            Complejidad:
            O(n), porque recorre la lista.
            */
            void stalinsort(int[] vector)
            {
                int cantidad = 1;

                for (int i = 1; i < vector.Length; i++)
                {
                    if (vector[i] >= vector[cantidad - 1])
                    {
                        cantidad++;
                    }
                }

                int[] resultado = new int[cantidad];
                resultado[0] = vector[0];

                int posicion = 1;

                for (int i = 1; i < vector.Length; i++)
                {
                    if (vector[i] >= resultado[posicion - 1])
                    {
                        resultado[posicion] = vector[i];
                        posicion++;
                    }
                }

                for (int i = 0; i < resultado.Length; i++)
                {
                    Console.Write(resultado[i] + " ");
                }

                Console.WriteLine();
            }


            /*
            BOGO SORT

            Explicación:
            Mezcla los números al azar hasta que quedan ordenados.

            Condiciones:
            Puede usarse con cualquier lista, pero es muy lento.

            Complejidad:
            O(n!), porque puede necesitar muchísimos intentos.
            */

            void bogosort(int[] vector)
            {
                Random random = new Random();

                while (!estaordenado(vector))
                {
                    for (int i = 0; i < vector.Length; i++)
                    {
                        int posicion = random.Next(vector.Length);

                        int temporal = vector[i];
                        vector[i] = vector[posicion];
                        vector[posicion] = temporal;
                    }
                }

                for (int i = 0; i < vector.Length; i++)
                {
                    Console.Write(vector[i] + " ");
                }

                Console.WriteLine();
            }

            bool estaordenado(int[] vector)
            {
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    if (vector[i] > vector[i + 1])
                    {
                        return false;
                    }
                }

                return true;
            }


            /*
            ¿CUAL ES LA BUSQUEDA MAS EFICIENTE?

            La búsqueda binaria, porque es rápida y tiene O(log n).
            La lista tiene que estar ordenada.


            ¿CUAL ES EL ORDENAMIENTO MAS EFICIENTE?

            QuickSort, porque normalmente tiene O(n log n).


            ¿QUE ES LA COMPLEJIDAD ALGORITMICA?

            Es una forma de medir qué tan rápido o lento es un algoritmo
            cuando aumenta la cantidad de datos.
            */


            int opcion = -1;


            while (opcion != 0)
            {
                Console.WriteLine("1. Busqueda secuencial simple");
                Console.WriteLine("2. Busqueda secuencial optimizada");
                Console.WriteLine("3. Busqueda binaria");
                Console.WriteLine("4. Busqueda binaria recursiva");
                Console.WriteLine("5. Burbuja clasico");
                Console.WriteLine("6. Burbuja optimizado");
                Console.WriteLine("7. Seleccion");
                Console.WriteLine("8. Insercion");
                Console.WriteLine("9. QuickSort");
                Console.WriteLine("10. Stalin Sort");
                Console.WriteLine("11. Bogo Sort");
                Console.WriteLine("0. Salir");
                Console.Write("Elija una opcion: ");

                opcion = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Busqueda secuencial simple:");
                        int posicion1 = busquedasecuencialsimple(lista_desordenada);
                        Console.WriteLine("Posicion: " + posicion1);
                        break;

                    case 2:
                        Console.WriteLine("Busqueda secuencial optimizada:");
                        int posicion2 = busquedasecuencialoptimizada(lista_ordenada);
                        Console.WriteLine("Posicion: " + posicion2);
                        break;

                    case 3:
                        Console.WriteLine("Busqueda binaria:");
                        int posicion3 = busquedabinaria(lista_ordenada);
                        Console.WriteLine("Posicion: " + posicion3);
                        break;

                    case 4:
                        Console.WriteLine("Busqueda binaria recursiva:");
                        Console.Write("Ingrese el numero que quiere buscar: ");
                        int valorBuscado = Convert.ToInt32(Console.ReadLine());

                        int posicion4 = busquedabinariarecursiva(lista_ordenada,valorBuscado,0,lista_ordenada.Length - 1);

                        Console.WriteLine("Posicion: " + posicion4);
                        break;

                    case 5:
                        Console.WriteLine("Burbuja clasico:");
                        ordenamientoburbujaclasico(lista_desordenada);
                        break;

                    case 6:
                        Console.WriteLine("Burbuja optimizado:");
                        ordenamientoburbujaoptimizado(lista_desordenada);
                        break;

                    case 7:
                        Console.WriteLine("Seleccion:");
                        ordenamientoselecion(lista_desordenada);
                        break;

                    case 8:
                        Console.WriteLine("Insercion:");
                        ordenamientoinsercion(lista_desordenada);
                        break;

                    case 9:
                        Console.WriteLine("QuickSort:");
                        quicksort(lista_desordenada, 0, lista_desordenada.Length - 1);
                        break;

                    case 10:
                        Console.WriteLine("Stalin Sort:");
                        stalinsort(lista_desordenada);
                        break;

                    case 11:
                        Console.WriteLine("Bogo Sort:");
                        bogosort(lista_desordenada);
                        break;

                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opcion incorrecta.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}