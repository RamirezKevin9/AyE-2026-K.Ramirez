namespace ConsoleApp8
{
    internal class Program
    {
        public struct pokemon
        {
            public string nombre { get; set; }
            public string tipo { get; set; }
            public int nivel { get; set; }
            public int ps { get; set; }
            public int ataque { get; set; }
            public int defensa { get; set; }
            public int ataque_especial { get; set; }
            public int defensa_especial { get; set; }
            public int velocidad { get; set; }

            public pokemon(string nombre, string tipo, int nivel, int ps, int ataque, int defensa, int ataque_especial, int defensa_especial, int velocidad)
            {
                this.nombre = nombre;
                this.tipo = tipo;
                this.nivel = nivel;
                this.ps = ps;
                this.ataque = ataque;
                this.defensa = defensa;
                this.ataque_especial = ataque_especial;
                this.defensa_especial = defensa_especial;
                this.velocidad = velocidad;
            }
        }

        public struct entrenador
        {
            public string nombre { get; set; }
            public string[] medallas { get; set; }
            public int pokedolares { get; set; }
            public pokemon[] equipo { get; set; }

            public entrenador(string nombre, string[] medallas, int pokedolares, pokemon[] equipo)
            {
                this.nombre = nombre;
                this.medallas = medallas;
                this.pokedolares = pokedolares;
                this.equipo = equipo;
            }

            public int niveltotaldeequipo(pokemon[] equipo)
            {
                int total = 0;
                if (equipo == null) return 0;
                for (int i = 0; i < equipo.Length; i++)
                {
                    total += equipo[i].nivel;
                }
                return total;
            }
        }
        static void Main(string[] args)
        {
            pokemon[] pokes = new pokemon[6]
            {
                new pokemon("Pikachu", "Eléctrico", 25, 85, 55, 40, 50, 50, 90),
                new pokemon("Charmander", "Fuego", 18, 60, 52, 43, 60, 50, 65),
                new pokemon("Bulbasaur", "Planta", 20, 65, 49, 49, 65, 65, 45),
                new pokemon("Squirtle", "Agua", 19, 63, 48, 65, 50, 64, 43),
                new pokemon("Pidgey", "Volador", 12, 40, 45, 40, 35, 35, 56),
                new pokemon("Rattata", "Normal", 10, 30, 56, 35, 25, 35, 72),
            };

            pokemon[] pokes2 = new pokemon[6]
            {
                new pokemon("Eevee", "Normal", 22, 65, 55, 50, 45, 65, 55),
                new pokemon("Jigglypuff", "Hada", 15, 115, 45, 20, 45, 25, 20),
                new pokemon("Meowth", "Normal", 13, 40, 45, 35, 40, 40, 90),
                new pokemon("Psyduck", "Agua", 17, 50, 52, 48, 65, 50, 55),
                new pokemon("Geodude", "Roca", 16, 40, 80, 100, 30, 30, 20),
                new pokemon("Magikarp", "Agua", 5, 20, 10, 55, 15, 20, 80)
            };
            string[] medallas = new string[8] { "Roca", "Cascad", "Trueno", "Rainbow ", "Soul ", "Marsh ", "Volcano ", "Earth " };

            entrenador Red = new entrenador("Red", medallas, 5000, pokes);

            entrenador Blue = new entrenador("blue", medallas, 5000, pokes2);

            int totalNivelRed = Red.niveltotaldeequipo(Red.equipo);
            int totalNivelBlue = Blue.niveltotaldeequipo(Blue.equipo);

            if (totalNivelRed > totalNivelBlue)
            {
                Console.WriteLine($"El entrenador {Red.nombre} tiene un nivel total de equipo mayor ({totalNivelRed}) que el entrenador {Blue.nombre} ({totalNivelBlue}).");
            }
            else
            {
                Console.WriteLine($"El entrenador {Blue.nombre} tiene un nivel total de equipo mayor ({totalNivelBlue}) que el entrenador {Red.nombre} ({totalNivelRed}).");
            }
        }
    }
}
