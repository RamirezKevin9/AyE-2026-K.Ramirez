using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using static ConsoleApp10.Tarea;

namespace ConsoleApp10
{
    internal class Program
    {

        static void Main(string[] args)
        {
            void palabras_alreves()
            {
                Stack<char> palabrag = new Stack<char>();
                string palabra = "";
                Console.WriteLine("ingrese la palabra para hacer alreves");
                palabra = Console.ReadLine();
                for (int i = 0; i < palabra.Length; i++)
                {
                    palabrag.Push(palabra[i]);
                }

                for (int i = 0; i < palabra.Length; i++)
                {
                    Console.Write(palabrag.Pop());
                }

                Console.WriteLine("");
            }

            void paginas_web()
            {
                Stack<string> historial = new Stack<string>();

                historial.Push("https://www.google.com/webhp?hl=es-419&sa=X&ved=0ahUKEwj4_cvm6sCWAxUNr5UCHVDoHpsQPAgI");
                historial.Push("https://github.com/RamirezKevin9/AyE-2026-K.Ramirez");
                historial.Push("https://www.youtube.com/watch?v=dQw4w9WgXcQ&list=RDdQw4w9WgXcQ&start_radio=1");
                bool sigue = true;

                while (sigue)
                {
                    Console.WriteLine("Ingrese 0 para agregar una pagina web, 1 para ir a la pagina anterior, 2 para ver la url actual, 3 para salir");
                    int opcion = 0;
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 0:
                            historial.Push(Console.ReadLine());
                            break;

                        case 1:
                            Console.WriteLine(historial.Pop());
                            break;

                        case 2:
                            Console.WriteLine(historial.Peek());
                            break;

                        case 3:
                            sigue = false;
                            break;
                    }
                }
            }

            void verificaciondelimitadores()
            {
                Console.WriteLine("Ingrese la expresión a verificar:");
                string expr = Console.ReadLine();

                bool resultado = VerificarDelimitadores(expr);
                Console.WriteLine(resultado ? "True" : "False");
            }

            bool VerificarDelimitadores(string s)
            {
                var stack = new Stack<char>();
                var pares = new Dictionary<char, char>
                {
                    { ')', '(' },
                    { ']', '[' },
                    { '}', '{' }
                };

                foreach (char c in s)
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        if (stack.Count == 0)
                            return false;

                        char esperado = pares[c];
                        if (stack.Pop() != esperado)
                            return false;
                    }
                }

                return stack.Count == 0;
            }

            void historial_documentos()
            {
                Stack<accionTexto> historial = new Stack<accionTexto>();

                historial.Push(new accionTexto("Agregar", "Hola", new int[] { 27, 6, 2024, 12, 0 }));
                historial.Push(new accionTexto("Agregar", "Mundo", new int[] { 27, 6, 2024, 12, 5 }));
                historial.Push(new accionTexto("Eliminar", "Hola", new int[] { 27, 6, 2024, 12, 10 }));
                historial.Push(new accionTexto("Atras", "Hola", new int[] { 27, 6, 2024, 12, 12 }));

                bool sigue = true;
                while (sigue)
                {
                    Console.Clear();
                    Console.WriteLine($"HISTORIAL DE EDICIÓN ({historial.Count} elementos)");
                    Console.WriteLine("1. Mostrar última acción (Peek)");
                    Console.WriteLine("2. Deshacer última acción (Pop)");
                    Console.WriteLine("3. Salir");
                    Console.Write("Seleccione una opción: ");

                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            if (historial.Count > 0)
                            {
                                accionTexto ultima = historial.Peek();
                                Console.WriteLine($"Última acción: [{ultima.fechaHora[0]}/{ultima.fechaHora[1]}/{ultima.fechaHora[2]}/ {ultima.fechaHora[3]}:{ultima.fechaHora[4]}] " +
                                                  $"{ultima.tipoAccion} -> {ultima.contenido}");
                            }
                            else
                            {
                                Console.WriteLine("El historial está vacío.");
                            }
                            break;

                        case "2":
                            if (historial.Count > 0)
                            {
                                accionTexto revertida = historial.Pop();
                                Console.WriteLine($"[DESHECHO] Se revirtió: {revertida.tipoAccion} de {revertida.contenido}");
                            }
                            else
                            {
                                Console.WriteLine("No hay acciones que se puedan deshacer.");
                            }
                            break;

                        case "3":
                            sigue = false;
                            Console.WriteLine("Finalizando gestor de historial...");
                            break;

                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }

                    
                }
            }

            double NotacionPolacaInversa()
            {
                Console.WriteLine("ingrese los numeros de la Notación Polaca Inversa");
                string[] elementos = Console.ReadLine().Split(' ');
                Stack<double> pila = new Stack<double>();

                foreach (string el in elementos)
                {
                    if (double.TryParse(el, out double num))
                    {
                        pila.Push(num);
                    }
                    else
                    {
                        double var2 = pila.Pop();
                        double var1 = pila.Pop();

                        switch (el)
                        {
                            case "+": 
                                pila.Push(var1 + var2); 
                                break;
                            case "-": 
                                pila.Push(var1 - var2); 
                                break;
                            case "*": 
                                pila.Push(var1 * var2); 
                                break;
                            case "/": 
                                pila.Push(var1 / var2); 
                                break;
                        }
                    }
                }
                return pila.Pop();
            }

            void ProcesadorDeTareas()
            {
                Stack<Tarea> pilaTareas = new Stack<Tarea>();

                pilaTareas.Push(new Tarea("001", "Configurar servidor", Tarea.PrioridadTarea.Alta, 45));
                pilaTareas.Push(new Tarea("002", "Diseñar vistas HTML", Tarea.PrioridadTarea.Media, 120));
                pilaTareas.Push(new Tarea("003", "Corregir bug de pagos", Tarea.PrioridadTarea.Alta, 20));

                Console.WriteLine("Tareas agregadas a la pila.");

                if (pilaTareas.Count > 0)
                {
                    Tarea tareaEnCima = pilaTareas.Peek();
                    Console.WriteLine($"Viendo la cima antes de atender");
                    Console.WriteLine($"ID: {tareaEnCima.Id} | Título: {tareaEnCima.Titulo} | Prioridad: {tareaEnCima.Prioridad}\n");
                }

                if (pilaTareas.Count > 0)
                {
                    Tarea tareaAtendida = pilaTareas.Pop();
                    Console.WriteLine($" Atendiendo tarea ");
                    Console.WriteLine($"Se ha procesado y removido: {tareaAtendida.Titulo}");
                }

                if (pilaTareas.Count > 0)
                {
                    Tarea nuevaCima = pilaTareas.Peek();
                    Console.WriteLine($"Nueva tarea en la cima");
                    Console.WriteLine($"La siguiente tarea es: {nuevaCima.Titulo}");
                }
            }

            while (true)
            {
                Console.WriteLine("Ingrese ");
                Console.WriteLine("1 para invertir una palabra");
                Console.WriteLine("2 para simular un historial de paginas web");
                Console.WriteLine("3 para verificar delimitadores");
                Console.WriteLine("5 para calcular una expresión en notación polaca");
                Console.WriteLine("6 para probar el procesador de tareas");
                Console.WriteLine("7 para salir");
                
                int opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        palabras_alreves();
                        break;
                    case 2:
                        paginas_web();
                        break;
                    case 3:
                        verificaciondelimitadores();
                        break;
                    case 4:
                        historial_documentos();
                        break;
                    case 5:
                        double resultado = NotacionPolacaInversa();
                        Console.WriteLine("El resultado es: " + resultado);
                        break;
                    case 6:
                        ProcesadorDeTareas();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
