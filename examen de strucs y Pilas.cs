namespace ConsoleApp12
{
    internal class Program
    {
        struct personaje
        {
            public int vidatotal { get; set; }
            public int vidactual { get; set; }
            public string ultimaaccion { get; set; }

            public personaje(int vidatotal, int vidactual, string ultimaaccion)
            {
                this.vidatotal = vidatotal;
                this.vidactual = vidactual;
                this.ultimaaccion = ultimaaccion;
            }
        }

        static void Main(string[] args)
        {
            Stack<personaje> historial = new Stack<personaje>();

            historial.Push(new personaje(100, 100, "despertar en casa"));
            historial.Push(new personaje(100, 100, "equipar espada"));
            historial.Push(new personaje(100, 100, "equipar escudo"));

            Console.WriteLine("Historial de personaje");
            foreach (personaje p in historial)
            {
                Console.WriteLine($"Accion: {p.ultimaaccion} | Vida: {p.vidactual}/{p.vidatotal}");
            }
            Console.WriteLine();

            void golpear()
            {
                personaje pActual = historial.Peek();
                pActual.vidactual -= 20;
                pActual.ultimaaccion = "Golpe recibido";
                historial.Push(pActual);
                Console.WriteLine($"Tu personaje a recibido un golpe su vida actual es de: {pActual.vidactual}");
            }

            void volverEnElTiempo()
            {
                personaje borrado = historial.Pop();
                Console.WriteLine("Has viajado en el tiempo, se ha borrado la ultima accion que paso.");
                Console.WriteLine($"La accion borrada fue: {borrado.ultimaaccion}");
            }

            golpear();
            volverEnElTiempo();
        }
    }
}