using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class ArbolBinario
    {
        public Nodo raiz { get; set; }

        public ArbolBinario()
        {
            raiz = null;
        }

        public void Insertar(Jugador jugador)
        {
            Nodo nuevo = new Nodo(jugador);

            if (raiz == null)
            {
                raiz = nuevo;
                return;
            }

            Nodo actual = raiz;

            while (true)
            {
                if (jugador.Id < actual.valor.Id)
                {
                    if (actual.izquierdo == null)
                    {
                        actual.izquierdo = nuevo;
                        return;
                    }

                    actual = actual.izquierdo;
                }
                else
                {
                    if (actual.derecho == null)
                    {
                        actual.derecho = nuevo;
                        return;
                    }

                    actual = actual.derecho;
                }
            }
        }

        public Jugador Buscar(int id)
        {
            Nodo actual = raiz;

            while (actual != null)
            {
                if (id == actual.valor.Id)
                {
                    return actual.valor;
                }

                if (id < actual.valor.Id)
                {
                    actual = actual.izquierdo;
                }
                else
                {
                    actual = actual.derecho;
                }
            }

            return null;
        }

        public Jugador[] RecorridoInOrden(int cantidad)
        {
            Jugador[] jugadores = new Jugador[cantidad];
            int posicion = 0;

            Recorrer(raiz, jugadores,  posicion);

            return jugadores;
        }

        private void Recorrer(Nodo nodo, Jugador[] jugadores, int posicion)
        {
            if (nodo != null)
            {
                Recorrer(nodo.izquierdo, jugadores, posicion);

                jugadores[posicion] = nodo.valor;
                posicion++;

                Recorrer(nodo.derecho, jugadores, posicion);
            }
        }
    }
}
