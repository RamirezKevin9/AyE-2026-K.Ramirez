namespace ConsoleApp18
{
    public class Nodo
    {
        public pokedex valor { get; set; }

        public Nodo izquierdo { get; set; }

        public Nodo derecho { get; set; }

        public Nodo(pokedex valor)
        {
            this.valor = valor;
            izquierdo = null;
            derecho = null;
        }
    }
}