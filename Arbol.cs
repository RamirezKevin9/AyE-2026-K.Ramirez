using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    public class Arbol
    {
        public Nodo raiz { get; set; }
        public Arbol()
        {
            raiz = null;
        }

         public void Insertar(int valor)
         {
            raiz = InsertarRecursivo(raiz, valor);

         }

        public Nodo InsertarRecursivo(Nodo nodoActual, int valor)
        {
            if (nodoActual == null)
            {
                return new Nodo(valor);
            }

            if (valor < nodoActual.valor)
            {
                nodoActual.izquierdo = InsertarRecursivo(nodoActual.izquierdo, valor);
            }
            else
            {
                nodoActual.derecho = InsertarRecursivo(nodoActual.derecho, valor);
            }

            return nodoActual;
        }

        public void buscar(int valor)
        {
            Nodo nodoEncontrado = BuscarRecursivo(raiz, valor);
            if (nodoEncontrado != null)
            {
                Console.WriteLine($"Valor {valor} encontrado en el árbol.");
            }
            else
            {
                Console.WriteLine($"Valor {valor} no encontrado en el árbol.");
            }
        }

        public Nodo BuscarRecursivo(Nodo nodoActual, int valor)
        {
            if (nodoActual == null || nodoActual.valor == valor)
            {
                return nodoActual;
            }

            if (valor < nodoActual.valor)
            {
                return BuscarRecursivo(nodoActual.izquierdo, valor);
            }
            else
            {
                return BuscarRecursivo(nodoActual.derecho, valor);
            }
        }

        public Nodo ObtenerMinimo(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return null;
            }

            while (nodoActual.izquierdo != null)
            {
                nodoActual = nodoActual.izquierdo;
            }

            return nodoActual;
        }

        public Nodo ObtenerMaximo(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return null;
            }

            while (nodoActual.derecho != null)
            {
                nodoActual = nodoActual.derecho;
            }

            return nodoActual;
        }

        public int ObtenerCantidadNodos(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }
            int cantidadIzquierda = ObtenerCantidadNodos(nodoActual.izquierdo);
            int cantidadDerecha = ObtenerCantidadNodos(nodoActual.derecho);

            return 1 + cantidadIzquierda + cantidadDerecha;
        }

        public int obtenerAltura(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }
            int alturaIzquierda = obtenerAltura(nodoActual.izquierdo);
            int alturaDerecha = obtenerAltura(nodoActual.derecho);
            if (alturaDerecha < alturaIzquierda)
            {
                return 1 + alturaIzquierda;
            }
            else
            {
                return 1 + alturaDerecha;
            }
        }

        public int contarHojas(Nodo nodoActual)
        {
            if (nodoActual == null)
            {
                return 0;
            }
            if (nodoActual.izquierdo == null && nodoActual.derecho == null)
            {
                return 1;
            }
            else
            {
                return contarHojas(nodoActual.izquierdo) + contarHojas(nodoActual.derecho);
            }
        }

        public Nodo eliminar(Nodo nodoActual, int valor)
        {
            if (nodoActual == null)
            {
                return nodoActual;
            }
            if (valor < nodoActual.valor)
            {
                nodoActual.izquierdo = eliminar(nodoActual.izquierdo, valor);
            }
            else if (valor > nodoActual.valor)
            {
                nodoActual.derecho = eliminar(nodoActual.derecho, valor);
            }
            else
            {
                nodoActual = null;
            }
            return nodoActual;
        }

        public bool esvalidoelarbol( Nodo nodoActual)
        { 
            if (nodoActual == null)
            {
                return true;
            }
            if (!esvalidoderecha(nodoActual) || !esvalidoizquierdo(nodoActual))
            {
                return false;
            }
            return esvalidoelarbol(nodoActual.izquierdo) && esvalidoelarbol(nodoActual.derecho);
        }
        public bool esvalidoderecha(Nodo nodoActual)
        {
            if (nodoActual.derecho == null)
            {
                return true;
            }
            if (nodoActual.derecho != null && nodoActual.derecho.valor <= nodoActual.valor)
            {
                return false;
            }
            return esvalidoderecha(nodoActual.derecho);
        }
        public bool esvalidoizquierdo(Nodo nodoActual)
        {
            if (nodoActual.izquierdo == null)
            {
                return true;
            }
            if (nodoActual.izquierdo != null && nodoActual.izquierdo.valor >= nodoActual.valor)
            {
                return false;
            }
            return esvalidoizquierdo(nodoActual.izquierdo);
        }
    }
}