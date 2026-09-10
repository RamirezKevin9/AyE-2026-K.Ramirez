namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arbol arbolito = new Arbol();
            arbolito.Insertar(10);
            arbolito.Insertar(5);
            arbolito.Insertar(15);
            arbolito.Insertar(3);
            arbolito.Insertar(7);
            Console.WriteLine("buscar arbolito 7 y arblito 20");
            arbolito.buscar(7);
            arbolito.buscar(20);
            Console.WriteLine($"El valor mínimo en el árbol es: {arbolito.ObtenerMinimo(arbolito.raiz).valor}");
            Console.WriteLine($"El valor máximo en el árbol es: {arbolito.ObtenerMaximo(arbolito.raiz).valor}");
            Console.WriteLine($"El número de nodos en el árbol es: {arbolito.ObtenerCantidadNodos(arbolito.raiz)}");
            Console.WriteLine($"La altura del árbol es: {arbolito.obtenerAltura(arbolito.raiz)}");
            Console.WriteLine($"El número de hojas en el árbol es: {arbolito.contarHojas(arbolito.raiz)}");
            arbolito.eliminar(arbolito.raiz, 5);
            arbolito.buscar(5);
            Console.WriteLine($"La verificacion del arbol es: {arbolito.esvalidoelarbol(arbolito.raiz)}");
        }
    }
}
