namespace ConsoleApp18
{
    public class pokedex
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo_1 { get; set; }
        public string tipo_2 { get; set; }
        public int hp { get; set; }
        public int ataque { get; set; }
        public int defensa { get; set; }
        public int ataque_especial { get; set; }
        public int defensa_especial { get; set; }
        public int velocidad { get; set; }
        public int nivel { get; set; }

        public pokedex(
            int id,
            string nombre,
            string tipo_1,
            string tipo_2,
            int hp,
            int ataque,
            int defensa,
            int ataque_especial,
            int defensa_especial,
            int velocidad,
            int nivel)
        {
            this.id = id;
            this.nombre = nombre;
            this.tipo_1 = tipo_1;
            this.tipo_2 = tipo_2;
            this.hp = hp;
            this.ataque = ataque;
            this.defensa = defensa;
            this.ataque_especial = ataque_especial;
            this.defensa_especial = defensa_especial;
            this.velocidad = velocidad;
            this.nivel = nivel;
        }
    }
}