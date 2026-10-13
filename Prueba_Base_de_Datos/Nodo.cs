using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Base_de_Datos
{
    public class Nodo
    {
        public datos valor { get; set; }

        public Nodo izquierdo { get; set; }

        public Nodo derecho { get; set; }

        public Nodo(datos valor)
        {
            this.valor = valor;
            izquierdo = null;
            derecho = null;
        }
    }
}