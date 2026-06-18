Console.WriteLine("Ejercicio 1:Bienvenido al Tornedo Pokemon");
Console.WriteLine("");

string[] pokemones = { "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon", "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie", "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill", "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate", "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu", "Raichu", "Sandshrew", "Sandslash", "Nidoran♀", "Nidorina", "Nidoqueen", "Nidoran♂", "Nidorino", "Nidoking", "Clefairy", "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff", "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume", "Paras", "Parasect", "Venonat", "Venomoth", "Diglett", "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck", "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag", "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam", "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell", "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler", "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro", "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio", "Seel", "Dewgong", "Grimer", "Muk", "Shellder", "Cloyster", "Gastly", "Haunter", "Gengar", "Onix", "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb", "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak", "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing", "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan", "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu", "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz", "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados", "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon", "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl", "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew" }; 
string[] Tipos = { "Grass", "Grass", "Grass", "Fire", "Fire", "Fire", "Water", "Water", "Water", "Bug", "Bug", "Bug", "Bug", "Bug", "Bug", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Normal", "Poison", "Poison", "Electric", "Electric", "Ground", "Ground", "Poison", "Poison", "Poison", "Poison", "Poison", "Poison", "Fairy", "Fairy", "Fire", "Fire", "Normal", "Normal", "Poison", "Poison", "Grass", "Grass", "Grass", "Bug", "Bug", "Bug", "Bug", "Ground", "Ground", "Normal", "Normal", "Water", "Water", "Fighting", "Fighting", "Fire", "Fire", "Water", "Water", "Water", "Psychic", "Psychic", "Psychic", "Fighting", "Fighting", "Fighting", "Grass", "Grass", "Grass", "Water", "Water", "Rock", "Rock", "Rock", "Fire", "Fire", "Water", "Water", "Electric", "Electric", "Normal", "Normal", "Normal", "Water", "Water", "Poison", "Poison", "Water", "Water", "Ghost", "Ghost", "Ghost", "Rock", "Psychic", "Psychic", "Water", "Water", "Electric", "Electric", "Grass", "Grass", "Ground", "Ground", "Fighting", "Fighting", "Normal", "Poison", "Poison", "Ground", "Ground", "Normal", "Grass", "Normal", "Water", "Water", "Water", "Water", "Water", "Water", "Psychic", "Bug", "Ice", "Electric", "Fire", "Bug", "Normal", "Water", "Water", "Water", "Normal", "Normal", "Water", "Electric", "Fire", "Normal", "Rock", "Rock", "Rock", "Rock", "Rock", "Normal", "Ice", "Electric", "Fire", "Dragon", "Dragon", "Dragon", "Psychic", "Psychic" };
string[] Equipos = { "Red", "Green", "Blue", "Yellow" };
Random random = new Random();
string[,] EquipoRed = new string[6, 3];
string[,] EquipoGreen = new string[6, 3];
string[,] EquipoBlue = new string[6, 3];
string[,] EquipoYellow = new string[6, 3];

for (int i = 0; i < 6; i++)
{
    int indicePokemonRed = random.Next(pokemones.Length);
    EquipoRed[i, 0] = pokemones[indicePokemonRed];
    EquipoRed[i, 1] = Tipos[indicePokemonRed];
    EquipoRed[i, 2] = random.Next(50, 81).ToString();
    
    int indicePokemonGreen = random.Next(pokemones.Length);
    EquipoGreen[i, 0] = pokemones[indicePokemonGreen];
    EquipoGreen[i, 1] = Tipos[indicePokemonGreen];
    EquipoGreen[i, 2] = random.Next(50, 81).ToString();
    
    int indicePokemonBlue = random.Next(pokemones.Length);
    EquipoBlue[i, 0] = pokemones[indicePokemonBlue];
    EquipoBlue[i, 1] = Tipos[indicePokemonBlue];
    EquipoBlue[i, 2] = random.Next(50, 81).ToString();
    
    int indicePokemonYellow = random.Next(pokemones.Length);
    EquipoYellow[i, 0] = pokemones[indicePokemonYellow];
    EquipoYellow[i, 1] = Tipos[indicePokemonYellow];
    EquipoYellow[i, 2] = random.Next(50, 81).ToString();
}

int nivelTotalRed = 0;
int nivelTotalGreen = 0;
int nivelTotalBlue = 0;
int nivelTotalYellow = 0;

for (int i = 0; i < 6; i++)
{
    nivelTotalRed += int.Parse(EquipoRed[i, 2]);
    nivelTotalGreen += int.Parse(EquipoGreen[i, 2]);
    nivelTotalBlue += int.Parse(EquipoBlue[i, 2]);
    nivelTotalYellow += int.Parse(EquipoYellow[i, 2]);
}

Console.WriteLine("");
Console.WriteLine("Equipo Red:");
Console.WriteLine("");

for (int i = 0; i < 6; i++)
{
    Console.WriteLine($"{EquipoRed[i, 0]} - {EquipoRed[i, 1]} - Nivel: {EquipoRed[i, 2]} - Niveltotal: {nivelTotalRed}");
}
Console.WriteLine($"Nivel Total: {nivelTotalRed}");

Console.WriteLine("");
Console.WriteLine("Equipo Green:");
Console.WriteLine("");

for (int i = 0; i < 6; i++)
{
    Console.WriteLine($"{EquipoGreen[i, 0]} - {EquipoGreen[i, 1]} - Nivel: {EquipoGreen[i, 2]}");
}
Console.WriteLine($"Nivel Total: {nivelTotalGreen}");

Console.WriteLine("");
Console.WriteLine("Equipo Blue:");
Console.WriteLine("");
for (int i = 0; i < 6; i++)
{
    Console.WriteLine($"{EquipoBlue[i, 0]} - {EquipoBlue[i, 1]} - Nivel: {EquipoBlue[i, 2]}");
}
Console.WriteLine($"Nivel Total: {nivelTotalBlue}");

Console.WriteLine("");
Console.WriteLine("Equipo Yellow:");
Console.WriteLine("");
for (int i = 0; i < 6; i++)
{
    Console.WriteLine($"{EquipoYellow[i, 0]} - {EquipoYellow[i, 1]} - Nivel: {EquipoYellow[i, 2]}");
}
Console.WriteLine($"Nivel Total: {nivelTotalYellow}");

bool ganador_red = false;
bool ganador_green = false;
void determinarganador_entreRedvsgreen() 
{
    if (nivelTotalRed > nivelTotalGreen)
    {
        Console.WriteLine("");
        Console.WriteLine("EL ganador de la primera ronda es:Red");
        Console.WriteLine("");
        ganador_red = true;
    }
    else {
        Console.WriteLine("");
        Console.WriteLine("EL ganador de la primera ronda es:Green");
        Console.WriteLine("");
        ganador_green = true;
    }
};
determinarganador_entreRedvsgreen();

bool ganador_blue = false;
bool ganador_yellow = false;
void determinarganador_entreGreenvsYellow()
{
    if (nivelTotalBlue > nivelTotalYellow)
    {
        Console.WriteLine("EL ganador de la primera ronda es:Blue");
        Console.WriteLine("");
        ganador_blue = true;
    }
    else
    {
        Console.WriteLine("EL ganador de la primera ronda es:Yellow");
        Console.WriteLine("");
        ganador_yellow = true;
    }
}
determinarganador_entreGreenvsYellow();

void determinarganador_final()
{
    if (ganador_red == true && ganador_blue == true)
    {
        if (nivelTotalRed > nivelTotalBlue)
        {
            Console.WriteLine("EL ganador final es:Red");
        }
        else
        {
            Console.WriteLine("EL ganador final es:Blue");
        }
    }
    else if (ganador_red == true && ganador_yellow == true)
    {
        if (nivelTotalRed > nivelTotalYellow)
        {
            Console.WriteLine("EL ganador final es:Red");
        }
        else
        {
            Console.WriteLine("EL ganador final es:Yellow");
        }
    }
    else if (ganador_green == true && ganador_blue == true)
    {
        if (nivelTotalGreen > nivelTotalBlue)
        {
            Console.WriteLine("EL ganador final es:Green");
        }
        else
        {
            Console.WriteLine("EL ganador final es:Blue");
        }
    }
    else if (ganador_green == true && ganador_yellow == true)
    {
        if (nivelTotalGreen > nivelTotalYellow)
        {
            Console.WriteLine("EL ganador final es:Green");
        }
        else
        {
            Console.WriteLine("EL ganador final es:Yellow");
        }
    }
}
determinarganador_final();

Console.WriteLine("");
Console.WriteLine("Ejercicio 2:Números del 50 al 0 de forma descendente, de cinco en cinco:");
Console.WriteLine("");
void MostrarNumeros(int numero)
{
    if (numero < 0)
    {
        return;
    }
    Console.WriteLine(numero);
    MostrarNumeros(numero - 5);
    }
MostrarNumeros(50);