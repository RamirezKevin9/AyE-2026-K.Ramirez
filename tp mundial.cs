namespace ConsoleApp7
{
    internal class Program
    {
        public struct Jugador
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public int goles { get; set; }
            public int disparos { get; set; }
            public int numerocamiseta { get; set; }
            public string posicion { get; set; }
            public string equipo { get; set; }

            public Jugador(string nombre, string apellido, int goles, int disparos, int numerocamiseta, string posicion, string equipo)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.goles = goles;
                this.disparos = disparos;
                this.numerocamiseta = numerocamiseta;
                this.posicion = posicion;
                this.equipo = equipo;
            }

            public double IndiceAtaque
            {
                get
                {
                    if (disparos == 0) return 0.0;
                    return (double)goles / disparos * 100.0;
                }
            }

            public string Mostrar()
            {
                return nombre + " " + apellido + " | Nº " + numerocamiseta + " | " + posicion + " | " + equipo + " | Goles: " + goles + " | Disparos: " + disparos + " | Índice: " + IndiceAtaque.ToString("F2") + "%";
            }
        }

        static void Main(string[] args)
        {

            Jugador[] jugadores = new Jugador[10];
            jugadores[0] = new Jugador("Kylian", "Mbappé", 10, 23, 10, "Delantero Centro", "Francia");
            jugadores[1] = new Jugador("Lionel", "Messi", 8, 18, 10, "Extremo derecho", "Argentina");
            jugadores[2] = new Jugador("Erling", "Haaland", 7, 13, 9, "Delantero centro", "Noruega");
            jugadores[3] = new Jugador("Jude", "Bellingham", 7, 12, 10, "Centrocampista", "Inglaterra");
            jugadores[4] = new Jugador("Harry", "Kane", 6, 12, 9, "Delantero centro", "Inglaterra");
            jugadores[5] = new Jugador("Ousmane", "Dembélé", 6, 14, 11, "Extremo derecho", "Francia");
            jugadores[6] = new Jugador("Mikel", "Oyarzabal", 5, 11, 21, "Extremo izquierdo", "España");
            jugadores[7] = new Jugador("Vinícius", "Júnior", 4, 7, 11, "Extremo izquierdo", "Brazil");
            jugadores[8] = new Jugador("Ismaïla", "Sarr", 4, 14, 18, "Extremo derecho ", "Senegal");
            jugadores[9] = new Jugador("Julián", "Quiñones", 4, 16, 11, "Delantero Centro", "México");
            MostrarYDeterminarMejor(jugadores);
        }

        static void MostrarYDeterminarMejor(Jugador[] jugadores)
        {
            Console.WriteLine();
            Console.WriteLine("Lista de jugadores:");
            for (int i = 0; i < jugadores.Length; i++)
            {
                Console.WriteLine(jugadores[i].Mostrar());
            }

            int indiceMejor = 0;
            

            double mejorIndice = jugadores[0].IndiceAtaque;
            for (int i = 1; i < jugadores.Length; i++)
            {
                if (jugadores[i].IndiceAtaque > mejorIndice)
                {
                    mejorIndice = jugadores[i].IndiceAtaque;
                    indiceMejor = i;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Mejor índice de ataque:");
            Console.WriteLine(jugadores[indiceMejor].Mostrar());
        }
    }
}