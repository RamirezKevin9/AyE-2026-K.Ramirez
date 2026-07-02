namespace ConsoleApp4
{
    internal class Program
    {

        public struct puntosd2
        {
            // Propiedades
            public int X { get; set; }
            public int Y { get; set; }

            // Constructor
            public puntosd2(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Método
            public void Mostrar()
            {
                Console.WriteLine($"Posición: ({X}, {Y})");
            }
        }

        public struct Dimensiones
        {
            // Propiedades
            public int Ancho { get; set; }
            public int Alto { get; set; }

            // Constructor
            public Dimensiones(int ancho, int alto)
            {
                Ancho = ancho;
                Alto = alto;
            }

            // Método
            public void Mostrar()
            {
                Console.WriteLine($"Posición: ({Ancho}, {Alto})");
            }
        }

        public struct Producto
        {
            public string Nombres { get; set; }
            public int Codigo { get; set; }
            public double Precio { get; set; }

            public Producto(string nombres, int codigo, double precio)
            {
                Nombres = nombres;
                Codigo = codigo;
                Precio = precio;
            }
        }

        public struct Estudiante
        {
            public string Nombre { get; set; }
            public double[] Notas { get; set; }

            public Estudiante(string nombre, double[] notas)
            {
                Nombre = nombre;
                Notas = notas;
            }

            public double CalcularPromedio()
            {
                if (Notas == null || Notas.Length == 0)
                {
                    return 0.0;
                }

                double suma = 0.0;
                foreach (double nota in Notas)
                {
                    suma += nota;
                }

                return suma / Notas.Length;
            }
        }

        static void Main(string[] args)
        {
            puntosd2 punto = new puntosd2(5, 10);
            punto.Mostrar();

            Dimensiones d1 = new Dimensiones(10, 20);
            Dimensiones d2 = d1;
            d2.Alto = 99;
            d1.Mostrar();
            d2.Mostrar();

            Producto[] productos = new Producto[3];
            productos[0] = new Producto("Champu", 3215, 43.32);
            productos[1] = new Producto("Jabon", 45215, 1.69);
            productos[2] = new Producto("Traverso", 5575, 74.2);

            foreach (Producto p in productos)
            {
                Console.WriteLine($"Nombre: {p.Nombres}, Precio: {p.Precio}");
            }

            Estudiante estudiante = new Estudiante(
                "Juan Pérez",
                new double[] { 8.5, 9.0, 7.5 }
            );

            double promedio = estudiante.CalcularPromedio();
            Console.WriteLine($"Estudiante: {estudiante.Nombre}, Promedio: {promedio:F2}");
        }
    }
}
