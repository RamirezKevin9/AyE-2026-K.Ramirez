using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Base_de_Datos
{
    public class ArbolBinario
    {
        public Nodo raiz { get; set; }

        public ArbolBinario()
        {
            raiz = null;
        }

        public void Insertar(datos agente)
        {
            Nodo nuevo = new Nodo(agente);

            if (raiz == null)
            {
                raiz = nuevo;
                return;
            }

            Nodo actual = raiz;

            while (true)
            {
                if (agente.id < actual.valor.id)
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

        public datos Buscar(int id)
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

        public List<datos> RecorridoInOrden()
        {
            List<datos> lista = new List<datos>();

            Recorrer(raiz, lista);

            return lista;
        }

        private void Recorrer(Nodo nodo, List<datos> lista)
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
