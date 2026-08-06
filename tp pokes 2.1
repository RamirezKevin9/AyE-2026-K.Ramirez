namespace ConsoleApp9
{
    internal class Program
    {
        public struct pokemon
        {
            public string nombre { get; set; }
            public string tipo { get; set; }
            public string estado { get; set; }
            public int nivel { get; set; }
            public int ps { get; set; }
            public int ataque { get; set; }
            public int defensa { get; set; }
            public int ataque_especial { get; set; }
            public int defensa_especial { get; set; }
            public int velocidad { get; set; }

            public pokemon(string nombre, string tipo, string estado, int nivel, int ps, int ataque, int defensa, int ataque_especial, int defensa_especial, int velocidad)
            {
                this.nombre = nombre;
                this.tipo = tipo;
                this.estado = estado;
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

            public int niveltotalequipo()
            {
                int total = 0;
                if (equipo == null) return 0;
                for (int i = 0; i < equipo.Length; i++)
                {
                    total += equipo[i].nivel;
                }
                return total;
            }

            public int cantidadmedallas()
            {
              
                return medallas.Length;
            }

            public int estadosalterados()
            {
                int total = 0;
                if (equipo == null) return 0;
                for (int i = 0; i < equipo.Length; i++)
                {
                    if (equipo[i].estado != "normal")
                    {
                        total++;
                    }
                }
                return total;
            }

            public int comprarpocion()
            {
                int precio_poti = 200;
                Console.WriteLine($"El precio de la poción es de {precio_poti} pokedolares. Tienes {pokedolares} pokedolares disponibles.");
                Console.WriteLine("¿Cuántas pociones deseas comprar?");
                int total = Convert.ToInt16(Console.ReadLine());
                for (int i = 0; i < total; i++)
                {
                    if (pokedolares >= precio_poti)
                    {
                        pokedolares = pokedolares - precio_poti;
                    }
                    else
                    {
                        Console.WriteLine("no de pudo comprar.");
                    }
                }
                return pokedolares;
            }
        }
        static void Main(string[] args)
        {
            pokemon[] pokes = new pokemon[6]
            {
                new pokemon("Pikachu", "Eléctrico", "normal", 25, 85, 55, 40, 50, 50, 90),
                new pokemon("Charmander", "Fuego", "Paralizado", 18, 60, 52, 43, 60, 50, 65),
                new pokemon("Bulbasaur", "Planta", "Envenenado", 20, 65, 49, 49, 65, 65, 45),
                new pokemon("Squirtle", "Agua", "normal", 19, 63, 48, 65, 50, 64, 43),
                new pokemon("Pidgey", "Volador", "Dormido", 12, 40, 45, 40, 35, 35, 56),
                new pokemon("Rattata", "Normal", "Congelado", 10, 30, 56, 35, 25, 35, 72),
            };

            pokemon[] pokes2 = new pokemon[6]
            {
                new pokemon("Eevee", "Normal", "Paralizado", 22, 65, 55, 50, 45, 65, 55),
                new pokemon("Jigglypuff", "Hada","normal", 15, 115, 45, 20, 45, 25, 20),
                new pokemon("Meowth", "Normal","Gravemente envenenado", 13, 40, 45, 35, 40, 40, 90),
                new pokemon("Psyduck", "Agua","Quemado", 17, 50, 52, 48, 65, 50, 55),
                new pokemon("Geodude", "Roca","normal", 16, 40, 80, 100, 30, 30, 20),
                new pokemon("Magikarp", "Agua","normal", 5, 20, 10, 55, 15, 20, 80)
            };
            string[] medallas = new string[8] { "Roca", "Cascad", "Trueno", "Rainbow ", "Soul ", "Marsh ", "Volcano ", "Earth " };
            string[] medallas2 = new string[4] { "Roca", "Cascad", "Trueno", "Rainbow " };

            entrenador Red = new entrenador("Red", medallas, 1000, pokes);

            entrenador Blue = new entrenador("blue", medallas2, 1000, pokes2);

            int totalNivelRed = Red.niveltotalequipo();
            int totalNivelBlue = Blue.niveltotalequipo();

            if (totalNivelRed > totalNivelBlue)
            {
                Console.WriteLine($"El entrenador {Red.nombre} tiene un nivel total de equipo mayor ({totalNivelRed}) que el entrenador {Blue.nombre} ({totalNivelBlue}).");
            }
            else
            {
                Console.WriteLine($"El entrenador {Blue.nombre} tiene un nivel total de equipo mayor ({totalNivelBlue}) que el entrenador {Red.nombre} ({totalNivelRed}).");
            }

            int cantidadMedallasRed = Red.cantidadmedallas();
            int cantidadMedallasBlue = Blue.cantidadmedallas();

            if (cantidadMedallasRed > cantidadMedallasBlue)
            {
                Console.WriteLine($"El entrenador {Red.nombre} tiene más medallas ({cantidadMedallasRed}) que el entrenador {Blue.nombre} ({cantidadMedallasBlue}).");
            }
            else
            {
                Console.WriteLine($"El entrenador {Blue.nombre} tiene más medallas ({cantidadMedallasBlue}) que el entrenador {Red.nombre} ({cantidadMedallasRed}).");
            }

            int estadosAlteradosRed = Red.estadosalterados();
            int estadosAlteradosBlue = Blue.estadosalterados();

            if (estadosAlteradosRed > estadosAlteradosBlue)
            {
                Console.WriteLine($"El entrenador {Red.nombre} tiene más Pokémon con estados alterados ({estadosAlteradosRed}) que el entrenador {Blue.nombre} ({estadosAlteradosBlue}).");
            }
            else
            {
                Console.WriteLine($"El entrenador {Blue.nombre} tiene más Pokémon con estados alterados ({estadosAlteradosBlue}) que el entrenador {Red.nombre} ({estadosAlteradosRed}).");
            }

            int comprarPocionRed = Red.comprarpocion();
            int comprarPocionBlue = Blue.comprarpocion();
        }
    }
}

