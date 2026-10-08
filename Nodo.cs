using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    public class Nodo
    {
        public Jugador valor { get; set; }
        public Nodo izquierdo { get; set; }
        public Nodo derecho { get; set; }

        public Nodo(Jugador valor)
        {
            this.valor = valor;
            izquierdo = null;
            derecho = null;
        }
    }
}
