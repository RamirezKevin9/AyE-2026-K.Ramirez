using System.Collections.Generic;

namespace ConsoleApp18
{
    public class ArbolBinario
    {
        public Nodo raiz { get; set; }

        public ArbolBinario()
        {
            raiz = null;
        }

        public void Insertar(pokedex pokemon)
        {
            Nodo nuevo = new Nodo(pokemon);

            if (raiz == null)
            {
                raiz = nuevo;
                return;
            }

            Nodo actual = raiz;

            while (true)
            {
                if (pokemon.id < actual.valor.id)
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

        public pokedex Buscar(int id)
        {
            Nodo actual = raiz;

            while (actual != null)
            {
                if (id == actual.valor.id)
                {
                    return actual.valor;
                }

                if (id < actual.valor.id)
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

        public List<pokedex> RecorridoInOrden()
        {
            List<pokedex> lista = new List<pokedex>();

            Recorrer(raiz, lista);

            return lista;
        }

        private void Recorrer(Nodo nodo, List<pokedex> lista)
        {
            if (nodo != null)
            {
                Recorrer(nodo.izquierdo, lista);

                lista.Add(nodo.valor);

                Recorrer(nodo.derecho, lista);
            }
        }
    }
}