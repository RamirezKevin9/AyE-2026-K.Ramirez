using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG_FINAL
{
    // ═══════════════════════════════════════════════
    //  ENUMS
    // ═══════════════════════════════════════════════
    enum StatusEffect { None, Poisoned, Burned, Stunned, Bleeding, Frozen, Cursed, Blessed, Enraged, Silenced, Weakened, Hasted, Shielded, Regenerating, Empowered, Confused, Petrified, Invisible, Berserked, Charmed, Doomed }
    enum ElementType { Physical, Fire, Ice, Lightning, Dark, Holy, Poison, Wind, Earth, Water, Arcane, Metal }
    enum Rarity { Common, Uncommon, Rare, Epic, Legendary, Mythic }
    enum ItemType { Potion, Weapon, Armor, Accessory, Scroll, Material, Food, Key, Relic }
    enum DungeonType { Cave, Ruins, Forest, Volcano, IcePeak, ShadowRealm, HolyTemple, Abyss }
    enum WeatherType { Clear, Rainy, Stormy, Foggy, Blizzard, Heatwave, Eclipse, Blessed }
    enum QuestStatus { Available, Active, Completed, Failed }
    enum GuildRank { Rookie, Bronze, Silver, Gold, Platinum, Diamond, Legend }
    enum CraftingCategory { Potions, Weapons, Armor, Accessories, Scrolls, Food }
    enum TalentTree { Combat, Magic, Support, Stealth, Nature }
    enum BiomeType { Plains, Desert, Mountains, Swamp, Tundra, Jungle, Underworld, Celestial }
    // Tipo de piso especial
    enum FloorType { Combat, Shop, PetShop, Peaceful, Healing, Boss, MythicBoss }

    // ═══════════════════════════════════════════════
    //  SPRITES ASCII
    // ═══════════════════════════════════════════════
    static class Sprites
    {
        public static readonly Dictionary<string, string[]> Class = new()
        {
            ["Guerrero"] = new[]{
                @"  O  ", @" /|\ ", @" / \ "
            },
            ["Arquero"] = new[]{
                @"  O  ", @" \|> ", @"  |  "
            },
            ["Mago"] = new[]{
                @" *O* ", @"  |~ ", @"  |  "
            },
            ["Curandero"] = new[]{
                @"  O  ", @" +|+ ", @"  |  "
            },
            ["Ladrón"] = new[]{
                @" `O  ", @"  |\ ", @"  /\ "
            },
            ["Monje"] = new[]{
                @"  O  ", @" (|) ", @"  |  "
            },
            ["Bardo"] = new[]{
                @"  O♪ ", @"  |/ ", @"  |  "
            },
            ["Paladín"] = new[]{
                @"  O  ", @" [|] ", @" /|\ "
            },
            ["Nigromante"] = new[]{
                @"  O  ", @"  |☠ ", @"  |  "
            },
            ["Alquimista"] = new[]{
                @"  O  ", @"  |⚗ ", @"  |  "
            },
            ["Berserker"] = new[]{
                @" >O< ", @" /|\ ", @" / \ "
            },
            ["Druida"] = new[]{
                @"  O  ", @" ♣|♣ ", @"  |  "
            },
            ["Invocador"] = new[]{
                @"  O  ", @" ✦|✦ ", @"  |  "
            },
            ["Cazador de Demonios"] = new[]{
                @"  O  ", @"  |x ", @" /|\ "
            },
            ["Elementalista"] = new[]{
                @"  O  ", @" ≈|≈ ", @"  |  "
            },
        };

        public static readonly Dictionary<string, string[]> NPC = new()
        {
            ["Mercader"] = new[]{
                @"  O  ", @" $|$ ", @"  |  "
            },
            ["Curandero_NPC"] = new[]{
                @"  O  ", @" +|+ ", @"  |  "
            },
            ["Vendedor_Mascotas"] = new[]{
                @"  O  ", @" ♥|♥ ", @"  |  "
            },
            ["Sabio"] = new[]{
                @"  O  ", @" ~|~ ", @"  |  "
            },
            ["Guardia"] = new[]{
                @"  O  ", @" #|# ", @" /|\ "
            },
        };

        public static readonly Dictionary<string, string[]> Enemy = new()
        {
            ["Normal"] = new[]{ @" /V\ ", @"  M  ", @" \|/ " },
            ["Elite"]  = new[]{ @" ★V★ ", @"  M  ", @" \|/ " },
            ["Boss"]   = new[]{ @" ╔V╗ ", @" ║M║ ", @" ╚|╝ " },
            ["Mythic"] = new[]{ @" ☠V☠ ", @" ║X║ ", @" ╚╩╝ " },
        };

        public static void Print(string[] sprite, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (var line in sprite) Console.WriteLine($"  {line}");
            Console.ResetColor();
        }

        public static string[] GetClassSprite(string className)
            => Class.TryGetValue(className, out var s) ? s : Class["Guerrero"];
    }

    // ═══════════════════════════════════════════════
    //  CONFIG
    // ═══════════════════════════════════════════════
    static class GameConfig
    {
        public const int MAX_PLAYERS = 4;
        public const int MAX_INVENTORY = 20;
        public const int MAX_GUILD_LEVEL = 20;
        public const float BASE_CRIT_MULTIPLIER = 1.8f;
        public const float DEFEND_REDUCTION = 0.5f;
        public const float BLESSED_REDUCTION = 0.85f;
        public const int SHOP_REFRESH_COST = 10;
        public const int MAX_PARTY_BUFFS = 5;
        public const int STARTING_GOLD = 50;   // ← oro inicial

        public static readonly string[] EnemyTypes =
        {
            "Goblin","Orco","Esqueleto","Vampiro","Troll","Bandido","Lobo Oscuro",
            "Dragón Menor","Elemental","Espectro","Demonio","Gólem","Cultista",
            "Serpiente Gigante","Araña Venenosa","Zombi","Liche","Hidra","Quimera"
        };

        public static readonly ConsoleColor[] RarityColors =
        {
            ConsoleColor.Gray, ConsoleColor.Green, ConsoleColor.Cyan,
            ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.Yellow
        };
        public static readonly string[] RarityStars =
        {
            "☆☆☆☆☆","★☆☆☆☆","★★☆☆☆","★★★☆☆","★★★★☆","★★★★★"
        };
    }

    // ═══════════════════════════════════════════════
    //  ESTADÍSTICAS GLOBALES
    // ═══════════════════════════════════════════════
    static class GlobalStats
    {
        public static int TotalDamageDealt, TotalDamageReceived, TotalHealingDone;
        public static int TotalEnemiesKilled, TotalBossesKilled, TotalItemsCrafted;
        public static int TotalItemsUsed, TotalGoldEarned, TotalGoldSpent;
        public static int TotalCriticalHits, TotalMissedAttacks, TotalQuestsCompleted;
        public static int TotalDungeonsCleared, HighestRound, HighestDamageInOneTurn;
        public static string HighestDamageDealer = "N/A";
        public static DateTime GameStartTime = DateTime.Now;

        public static void Show()
        {
            Console.Clear();
            Program.PrintBox("📊 ESTADÍSTICAS GLOBALES", ConsoleColor.Cyan);
            TimeSpan t = DateTime.Now - GameStartTime;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n  ⏱  Tiempo jugado:  {t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}");
            Console.WriteLine($"  🏆 Ronda más alta: {HighestRound}");
            Console.WriteLine($"\n  ── COMBATE ──");
            Console.WriteLine($"  ⚔  Daño infligido: {TotalDamageDealt:N0}");
            Console.WriteLine($"  🛡 Daño recibido:  {TotalDamageReceived:N0}");
            Console.WriteLine($"  💚 Curación total: {TotalHealingDone:N0}");
            Console.WriteLine($"  💀 Enemigos elim.: {TotalEnemiesKilled}  |  👑 Jefes: {TotalBossesKilled}");
            Console.WriteLine($"  💥 Críticos:       {TotalCriticalHits}");
            Console.WriteLine($"  ✨ Mayor daño:     {HighestDamageInOneTurn} ({HighestDamageDealer})");
            Console.WriteLine($"\n  ── ECONOMÍA ──");
            Console.WriteLine($"  🪙 Oro ganado: {TotalGoldEarned:N0}  |  Gastado: {TotalGoldSpent:N0}");
            Console.WriteLine($"\n  ── PROGRESIÓN ──");
            Console.WriteLine($"  🔨 Crafteados: {TotalItemsCrafted}  |  Usados: {TotalItemsUsed}");
            Console.WriteLine($"  📜 Misiones:   {TotalQuestsCompleted}  |  Mazmorras: {TotalDungeonsCleared}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Pulsa una tecla para volver..."); Console.ResetColor();
            Console.ReadKey(true);
        }
    }

    // ═══════════════════════════════════════════════
    //  SISTEMA DE TIEMPO Y CLIMA
    // ═══════════════════════════════════════════════
    static class WorldTime
    {
        static readonly Random R = new();
        public static int Day { get; private set; } = 1;
        public static int Hour { get; private set; } = 6;
        public static WeatherType CurrentWeather { get; private set; } = WeatherType.Clear;
        public static BiomeType CurrentBiome { get; private set; } = BiomeType.Plains;
        static int weatherDuration = 0;

        public static string TimeOfDay => Hour switch
        {
            >= 6 and < 12 => "🌅 Mañana", >= 12 and < 18 => "☀ Tarde",
            >= 18 and < 22 => "🌆 Atardecer", _ => "🌙 Noche"
        };
        public static bool IsNight => Hour >= 22 || Hour < 6;

        public static void Advance(int h = 1)
        {
            Hour = (Hour + h) % 24;
            if (Hour == 0) Day++;
            if (weatherDuration > 0) { weatherDuration--; return; }
            CurrentWeather = Enum.GetValues<WeatherType>()[R.Next(8)];
            weatherDuration = R.Next(2, 6);
        }
        public static void ChangeBiome(BiomeType b) => CurrentBiome = b;
        public static string GetWeatherIcon() => CurrentWeather switch
        {
            WeatherType.Rainy => "🌧", WeatherType.Stormy => "⛈",
            WeatherType.Foggy => "🌫", WeatherType.Blizzard => "❄",
            WeatherType.Heatwave => "🔥", WeatherType.Eclipse => "🌑",
            WeatherType.Blessed => "✨", _ => "☀"
        };
        public static (int atk, int def, int spd, string desc) GetWeatherEffects() => CurrentWeather switch
        {
            WeatherType.Rainy => (-2, 0, -1, "Lluvia: -2 ATK -1 VEL"),
            WeatherType.Stormy => (-5, -3, -3, "Tormenta: penalidades severas"),
            WeatherType.Foggy => (-3, 0, 0, "Niebla: -3 ATK"),
            WeatherType.Blizzard => (-4, -2, -5, "Ventisca: penalidades extremas"),
            WeatherType.Heatwave => (3, -2, -2, "Calor: +3 ATK -2 DEF"),
            WeatherType.Eclipse => (0, -5, 0, "Eclipse: monstruos fortalecidos"),
            WeatherType.Blessed => (3, 3, 3, "Clima Bendito: +3 todo"),
            _ => (0, 0, 0, "Despejado")
        };
        public static void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"  {GetWeatherIcon()} {CurrentWeather}  |  {TimeOfDay}  |  Día {Day}  |  Bioma: {CurrentBiome}");
            var (a, d, s, desc) = GetWeatherEffects();
            if (a != 0 || d != 0 || s != 0) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"  ⚠  {desc}"); }
            Console.ResetColor();
        }
    }

    // ═══════════════════════════════════════════════
    //  GREMIO
    // ═══════════════════════════════════════════════
    class Guild
    {
        public string Name { get; }
        public int Level { get; private set; } = 1;
        public int Experience { get; private set; }
        public int GuildGold { get; private set; }
        public GuildRank Rank { get; private set; } = GuildRank.Rookie;
        public List<string> Members = new();
        public int TotalKills;
        public int BonusAttack => (Level - 1) * 2;
        public int BonusDefense => Level - 1;
        public int BonusGoldPercent => Level * 5;

        public Guild(string n) { Name = n; }

        public void AddExperience(int xp)
        {
            Experience += xp;
            while (Experience >= Level * 100 && Level < GameConfig.MAX_GUILD_LEVEL)
            {
                Experience -= Level * 100; Level++;
                Rank = Level switch { >= 18 => GuildRank.Legend, >= 15 => GuildRank.Diamond, >= 12 => GuildRank.Platinum, >= 9 => GuildRank.Gold, >= 6 => GuildRank.Silver, >= 3 => GuildRank.Bronze, _ => GuildRank.Rookie };
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🏰 ¡Gremio «{Name}» subió a Nivel {Level}!"); Console.ResetColor();
            }
        }
        public void AddGold(int a) => GuildGold += a;

        public void ShowInfo()
        {
            Console.Clear(); Program.PrintBox($"🏰 GREMIO: {Name.ToUpper()}", ConsoleColor.Yellow);
            Console.WriteLine($"\n  Rango: {Rank}  Nivel: {Level}/{GameConfig.MAX_GUILD_LEVEL}  XP: {Experience}/{Level * 100}");
            Console.WriteLine($"  Miembros: {string.Join(", ", Members)}");
            Console.WriteLine($"  ⚔ +{BonusAttack} ATK  🛡 +{BonusDefense} DEF  🪙 +{BonusGoldPercent}% oro");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("\n  Pulsa tecla..."); Console.ResetColor(); Console.ReadKey(true);
        }
    }

    // ═══════════════════════════════════════════════
    //  MISIONES
    // ═══════════════════════════════════════════════
    class Quest
    {
        public string Name { get; }
        public string Description { get; }
        public QuestStatus Status { get; set; } = QuestStatus.Available;
        public int GoldReward { get; }
        public int XPReward { get; }
        public int KillsRequired { get; }
        public int CurrentKills { get; set; }
        public string? SpecialRewardItem { get; }
        public Rarity DifficultyRarity { get; }

        public Quest(string n, string d, int g, int xp, int k, string? item = null, Rarity diff = Rarity.Common)
        { Name = n; Description = d; GoldReward = g; XPReward = xp; KillsRequired = k; SpecialRewardItem = item; DifficultyRarity = diff; }

        public bool IsComplete() => CurrentKills >= KillsRequired;
        public float Progress() => KillsRequired > 0 ? (float)CurrentKills / KillsRequired : 1f;
        public string ProgressBar(int w = 15) { int f = Math.Clamp((int)(Progress() * w), 0, w); return "[" + new string('█', f) + new string('░', w - f) + "]"; }
    }

    static class QuestDatabase
    {
        public static List<Quest> GetStarterQuests() => new()
        {
            new Quest("Primera Sangre",    "Elimina 3 enemigos.",         50,  100,   3),
            new Quest("Exterminador",      "Elimina 10 enemigos.",       120,  200,  10),
            new Quest("Cazador de Jefes", "Derrota tu primer jefe.",     200,  500,   1, "Hacha Rúnica", Rarity.Rare),
            new Quest("Masacre",           "Elimina 25 enemigos.",        250,  400,  25, diff: Rarity.Uncommon),
            new Quest("Carnicero",         "Elimina 50 enemigos.",        500,  800,  50, diff: Rarity.Rare),
            new Quest("Leyenda Viva",      "Elimina 100 enemigos.",      1000, 2000, 100, diff: Rarity.Legendary),
            new Quest("Caza Mayor",        "Derrota 3 jefes.",            400,  700,   3, diff: Rarity.Epic),
        };
    }

    // ═══════════════════════════════════════════════
    //  CRAFTEO
    // ═══════════════════════════════════════════════
    class CraftingRecipe
    {
        public string ResultItemName { get; }
        public CraftingCategory Category { get; }
        public Dictionary<string, int> Ingredients { get; }
        public int GoldCost { get; }
        public int LevelRequired { get; }
        public Rarity ResultRarity { get; }
        public string Description { get; }

        public CraftingRecipe(string res, CraftingCategory cat, Dictionary<string, int> ing, int g, int lv, Rarity r, string d)
        { ResultItemName = res; Category = cat; Ingredients = ing; GoldCost = g; LevelRequired = lv; ResultRarity = r; Description = d; }

        public bool CanCraft(Player p)
        {
            if (p.Level < LevelRequired || p.Gold < GoldCost) return false;
            foreach (var kv in Ingredients) if (p.Inventory.Count(i => i.Name == kv.Key) < kv.Value) return false;
            return true;
        }
        public string GetIngredientsList() => string.Join(", ", Ingredients.Select(kv => $"{kv.Value}x {kv.Key}"));
    }

    static class CraftingDatabase
    {
        public static List<CraftingRecipe> AllRecipes => new()
        {
            new CraftingRecipe("Gran Poción",          CraftingCategory.Potions,    new(){["Poción Menor"]=3},                            5,  1, Rarity.Uncommon,  "Restaura 100 HP"),
            new CraftingRecipe("Elixir Supremo",       CraftingCategory.Potions,    new(){["Elixir"]=2,["Hierba Mágica"]=1},             30,  5, Rarity.Rare,      "150 HP y 80 MP"),
            new CraftingRecipe("Poción de Poder",      CraftingCategory.Potions,    new(){["Éter"]=2,["Cristal de Magia"]=1},            25,  3, Rarity.Rare,      "+15 ATK temporal"),
            new CraftingRecipe("Espada Rúnica Avanzada",CraftingCategory.Weapons,   new(){["Hacha Rúnica"]=1,["Cristal de Fuego"]=2,["Metal Élfico"]=1}, 150, 10, Rarity.Epic, "+35 ATK de Fuego"),
            new CraftingRecipe("Armadura Divina",      CraftingCategory.Armor,      new(){["Armadura de Hierro"]=1,["Fragmento Sagrado"]=3,["Metal Élfico"]=2}, 200, 12, Rarity.Epic, "+30 DEF +40 HP"),
            new CraftingRecipe("Amuleto del Dragón",   CraftingCategory.Accessories,new(){["Escama Ancestral"]=1,["Gema del Abismo"]=2}, 300, 15, Rarity.Legendary, "+50 MaxHP +10 ATK"),
            new CraftingRecipe("Antídoto Superior",    CraftingCategory.Potions,    new(){["Hierba Mágica"]=2},                          10,  1, Rarity.Common,    "Cura todos los estados"),
            new CraftingRecipe("Explosivo Alquímico",  CraftingCategory.Potions,    new(){["Cristal de Fuego"]=1,["Polvo Volcánico"]=2},  20,  3, Rarity.Uncommon,  "80 daño a todos"),
            new CraftingRecipe("Botas del Viento",     CraftingCategory.Accessories,new(){["Pluma de Grifo"]=2,["Cuero Élfico"]=1},       80,  5, Rarity.Rare,      "+15 VEL"),
            new CraftingRecipe("Ración de Viaje",      CraftingCategory.Food,       new(){["Carne Cruda"]=2,["Hierbas"]=1},                5,  1, Rarity.Common,    "+30 HP + Regen"),
        };

        public static Item? CraftItem(CraftingRecipe r, Player p)
        {
            if (!r.CanCraft(p)) return null;
            foreach (var kv in r.Ingredients) { var rem = p.Inventory.Where(i => i.Name == kv.Key).Take(kv.Value).ToList(); foreach (var it in rem) p.Inventory.Remove(it); }
            p.Gold -= r.GoldCost; GlobalStats.TotalGoldSpent += r.GoldCost; GlobalStats.TotalItemsCrafted++;
            return r.ResultItemName switch
            {
                "Gran Poción" => new Item("Gran Poción", "Restaura 100 HP", ItemType.Potion, Rarity.Uncommon, 40, hp: 100),
                "Elixir Supremo" => new Item("Elixir Supremo", "150 HP y 80 MP", ItemType.Potion, Rarity.Rare, 80, hp: 150, mp: 80),
                "Poción de Poder" => new Item("Poción de Poder", "+15 ATK temporal", ItemType.Potion, Rarity.Rare, 60, atk: 15),
                "Espada Rúnica Avanzada" => new Item("Espada Rúnica Avanzada", "+35 ATK de Fuego", ItemType.Weapon, Rarity.Epic, 300, atk: 35),
                "Armadura Divina" => new Item("Armadura Divina", "+30 DEF +40 MaxHP", ItemType.Armor, Rarity.Epic, 350, def: 30, maxHp: 40),
                "Amuleto del Dragón" => new Item("Amuleto del Dragón", "+50 MaxHP +10 ATK", ItemType.Accessory, Rarity.Legendary, 500, atk: 10, maxHp: 50),
                "Antídoto Superior" => new Item("Antídoto Superior", "Cura estados", ItemType.Potion, Rarity.Common, 15),
                "Explosivo Alquímico" => new Item("Explosivo Alquímico", "80 daño a todos", ItemType.Potion, Rarity.Uncommon, 30),
                "Botas del Viento" => new Item("Botas del Viento", "+15 VEL", ItemType.Accessory, Rarity.Rare, 100, spd: 15),
                "Ración de Viaje" => new Item("Ración de Viaje", "+30 HP", ItemType.Food, Rarity.Common, 15, hp: 30),
                _ => new Item(r.ResultItemName, r.Description, ItemType.Accessory, r.ResultRarity, 100)
            };
        }
    }

    // ═══════════════════════════════════════════════
    //  ÁRBOL DE TALENTOS
    // ═══════════════════════════════════════════════
    class TalentNode
    {
        public string Name { get; }
        public string Description { get; }
        public TalentTree Tree { get; }
        public int Cost { get; }
        public int Tier { get; }
        public bool Unlocked { get; set; }
        public List<string> Prerequisites { get; }
        public int AtkBonus, DefBonus, HPBonus, MPBonus, SpdBonus, CritBonus;

        public TalentNode(string n, string d, TalentTree t, int c, int tier,
            List<string>? pre = null, int atk = 0, int def = 0, int hp = 0, int mp = 0, int spd = 0, int crit = 0)
        { Name = n; Description = d; Tree = t; Cost = c; Tier = tier; Prerequisites = pre ?? new(); AtkBonus = atk; DefBonus = def; HPBonus = hp; MPBonus = mp; SpdBonus = spd; CritBonus = crit; }
    }

    class TalentSystem
    {
        public int AvailablePoints { get; set; } = 0;
        readonly List<TalentNode> nodes = new()
        {
            new TalentNode("Golpe Fuerte",    "+5 ATK",        TalentTree.Combat,   1, 1, atk:5),
            new TalentNode("Piel de Hierro",  "+8 DEF",        TalentTree.Combat,   1, 1, def:8),
            new TalentNode("Vitalidad",       "+30 MaxHP",     TalentTree.Combat,   2, 2, pre:new(){"Golpe Fuerte"}, hp:30),
            new TalentNode("Crítico Experto", "+10 CRIT",      TalentTree.Combat,   2, 2, pre:new(){"Golpe Fuerte"}, crit:10),
            new TalentNode("Furia",           "+15 ATK",       TalentTree.Combat,   3, 3, pre:new(){"Vitalidad"}, atk:15),
            new TalentNode("Magia Arcana",    "+5 ATK Mágico", TalentTree.Magic,    1, 1, atk:5),
            new TalentNode("Mente Fría",      "+30 MaxMP",     TalentTree.Magic,    1, 1, mp:30),
            new TalentNode("Hechicero",       "+10 ATK Mag",   TalentTree.Magic,    2, 2, pre:new(){"Magia Arcana"}, atk:10),
            new TalentNode("Apoyo Grupal",    "+10 HP aliados",TalentTree.Support,  1, 1),
            new TalentNode("Resiliencia",     "Revive 1 vez",  TalentTree.Support,  3, 2, pre:new(){"Apoyo Grupal"}),
            new TalentNode("Paso Ligero",     "+8 VEL",        TalentTree.Stealth,  1, 1, spd:8),
            new TalentNode("Sigilo",          "+15 CRIT",      TalentTree.Stealth,  2, 2, pre:new(){"Paso Ligero"}, crit:15),
            new TalentNode("Comunión Natural","+20 HP",        TalentTree.Nature,   1, 1, hp:20),
            new TalentNode("Regeneración",    "+Regen pasiva", TalentTree.Nature,   2, 2, pre:new(){"Comunión Natural"}),
        };

        public List<string> GetUnlockedTalents() => nodes.Where(n => n.Unlocked).Select(n => n.Name).ToList();

        public void ShowTalentMenu(Player p)
        {
            Console.Clear(); Program.PrintBox($"🌟 TALENTOS — Puntos: {AvailablePoints}", ConsoleColor.Magenta);
            var groups = nodes.GroupBy(n => n.Tree);
            foreach (var g in groups)
            {
                Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  ── {g.Key} ──"); Console.ResetColor();
                foreach (var n in g)
                {
                    bool canU = AvailablePoints >= n.Cost && !n.Unlocked && n.Prerequisites.All(pr => nodes.Any(x => x.Name == pr && x.Unlocked));
                    Console.ForegroundColor = n.Unlocked ? ConsoleColor.Green : canU ? ConsoleColor.White : ConsoleColor.DarkGray;
                    Console.WriteLine($"  {(n.Unlocked ? "✔" : canU ? "○" : "✗")} [{n.Cost}pt] T{n.Tier} {n.Name}: {n.Description}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n  Escribe el nombre del talento a desbloquear (o Enter para salir):");
            Console.Write("  → ");
            string input = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(input)) return;
            var talent = nodes.FirstOrDefault(n => n.Name.Equals(input, StringComparison.OrdinalIgnoreCase));
            if (talent == null) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Talento no encontrado."); Console.ResetColor(); Console.ReadKey(true); return; }
            if (talent.Unlocked) { Console.WriteLine("  Ya desbloqueado."); Console.ReadKey(true); return; }
            if (AvailablePoints < talent.Cost) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Puntos insuficientes."); Console.ResetColor(); Console.ReadKey(true); return; }
            if (!talent.Prerequisites.All(pr => nodes.Any(x => x.Name == pr && x.Unlocked))) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Requisitos no cumplidos."); Console.ResetColor(); Console.ReadKey(true); return; }
            talent.Unlocked = true; AvailablePoints -= talent.Cost;
            p.AttackBonus += talent.AtkBonus; p.Defense += talent.DefBonus;
            p.MaxHealth += talent.HPBonus; p.Health = Math.Min(p.Health + talent.HPBonus, p.MaxHealth);
            p.Mana += talent.MPBonus; p.Speed += talent.SpdBonus; p.CritChance += talent.CritBonus;
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✔ ¡{talent.Name} desbloqueado!"); Console.ResetColor(); Console.ReadKey(true);
        }
    }

    // ═══════════════════════════════════════════════
    //  COMPANION (MASCOTA)
    // ═══════════════════════════════════════════════
    class Companion
    {
        public string Name { get; }
        public string Icon { get; }
        public int Level { get; private set; } = 1;
        int baseAtk; static readonly Random R = new();

        public Companion(string n, string icon, int atk) { Name = n; Icon = icon; baseAtk = atk; }

        public string? ActInCombat(Player owner, List<Enemy> enemies)
        {
            if (!enemies.Any()) return null;
            var t = enemies[R.Next(enemies.Count)];
            int d = baseAtk + R.Next(3, 10) + Level * 2;
            t.TakeDamage(d, ElementType.Physical);
            return $"  {Icon} {Name} ataca a {t.Name}: {d} daño!";
        }
        public void LevelUp() { Level++; baseAtk += 3; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  {Icon} ¡{Name} subió a Nv.{Level}!"); Console.ResetColor(); }
    }

    static class CompanionShop
    {
        static readonly Random R = new();
        public static readonly (string name, string icon, int atk, int price)[] Pets =
        {
            ("Lobo",   "🐺", 12, 40), ("Gato",  "🐱", 8, 30),  ("Águila","🦅", 15, 55),
            ("Dragón", "🐉", 25, 120),("Zorro", "🦊", 10, 35), ("Búho",  "🦉", 9, 32),
            ("Oso",    "🐻", 18, 70), ("Serpiente","🐍", 13, 45),
        };

        public static void Open(Player p)
        {
            Console.Clear(); Program.PrintBox("🐾 TIENDA DE MASCOTAS", ConsoleColor.Yellow);
            Sprites.Print(Sprites.NPC["Vendedor_Mascotas"], ConsoleColor.Yellow);
            Console.WriteLine($"\n  Vendedor: «¡Las mejores mascotas del reino!»  Tu oro: {p.Gold}🪙\n");
            for (int i = 0; i < Pets.Length; i++)
            {
                var pet = Pets[i];
                Console.ForegroundColor = p.Gold >= pet.price ? ConsoleColor.White : ConsoleColor.DarkGray;
                Console.WriteLine($"  {i + 1}. {pet.icon} {pet.name,-12} ATK:{pet.atk}  Precio:{pet.price}🪙");
                Console.ResetColor();
            }
            Console.WriteLine("\n  0. Salir");
            Console.Write("  → ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= Pets.Length)
            {
                var chosen = Pets[idx - 1];
                if (p.Gold < chosen.price) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Oro insuficiente."); Console.ResetColor(); Console.ReadKey(true); return; }
                p.Gold -= chosen.price; GlobalStats.TotalGoldSpent += chosen.price;
                p.Pet = new Companion(chosen.name, chosen.icon, chosen.atk);
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✔ ¡Adoptaste a {chosen.icon} {chosen.name}!"); Console.ResetColor();
            }
            Console.ReadKey(true);
        }
    }

    // ═══════════════════════════════════════════════
    //  NPC NEUTRAL
    // ═══════════════════════════════════════════════
    static class NpcSystem
    {
        static readonly Random R = new();
        static readonly string[] SabioTips =
        {
            "«Los jefes aparecen cada 5 pisos. Prepárate.»",
            "«Los niveles pacíficos te permiten descansar.»",
            "«La tienda especial aparece en pisos clave.»",
            "«El primer golpe en sigilo hace mucho más daño.»",
            "«La curación completa solo aparece una vez por ciclo.»",
            "«El clima bendecido da más oro en combate.»",
            "«Las mascotas atacan solas en combate.»",
            "«Los talentos son permanentes. Elige con sabiduría.»",
        };

        public static void ShowNPCScene(FloorType type, List<Player> players)
        {
            Console.Clear();
            switch (type)
            {
                case FloorType.Peaceful:
                    ShowPeacefulFloor(players); break;
                case FloorType.Healing:
                    ShowHealingFloor(players); break;
                case FloorType.Shop:
                    ShowShopFloor(players); break;
                case FloorType.PetShop:
                    ShowPetShopFloor(players); break;
            }
        }

        static void ShowPeacefulFloor(List<Player> players)
        {
            Program.PrintBox("🌸 PISO PACÍFICO — ALDEA TRANQUILA", ConsoleColor.Green);
            Console.WriteLine();

            // Guardia
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  ──── Guardia de la Aldea ────");
            Sprites.Print(Sprites.NPC["Guardia"], ConsoleColor.Green);
            Console.WriteLine("  Guardia: «¡Bienvenidos, viajeros! Descansen aquí.»\n");

            // Sabio con consejo random
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  ──── Anciano Sabio ────");
            Sprites.Print(Sprites.NPC["Sabio"], ConsoleColor.Cyan);
            Console.WriteLine($"  Sabio: {SabioTips[R.Next(SabioTips.Length)]}\n");
            Console.ResetColor();

            Console.WriteLine("  Opciones:");
            Console.WriteLine("  1. Descansar (+30 HP y +20 MP a todos)");
            Console.WriteLine("  2. Hablar con el sabio (consejo)");
            Console.WriteLine("  3. Ver inventario");
            Console.WriteLine("  0. Continuar");
            bool running = true;
            while (running)
            {
                Console.Write("\n  → ");
                switch (Console.ReadLine() ?? "0")
                {
                    case "1":
                        foreach (var p in players.Where(p => p.IsAlive())) { p.Heal(30); p.Mana = Math.Min(p.Mana + 20, 200); }
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("  ✔ El grupo descansó. +30 HP +20 MP a todos."); Console.ResetColor(); break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  Sabio: {SabioTips[R.Next(SabioTips.Length)]}"); Console.ResetColor(); break;
                    case "3":
                        foreach (var p in players.Where(x => x.IsAlive())) p.OpenInventory(); break;
                    case "0":
                        running = false; break;
                }
            }
        }

        static void ShowHealingFloor(List<Player> players)
        {
            Program.PrintBox("⛪ SANTUARIO DE CURACIÓN", ConsoleColor.Cyan);
            Sprites.Print(Sprites.NPC["Curandero_NPC"], ConsoleColor.Cyan);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  Sacerdote: «La luz os cura por completo, viajeros.»");
            Console.WriteLine("  «Que sigáis vuestro camino con salud.»");
            Console.ResetColor();
            Console.WriteLine("\n  1. Curación completa (GRATIS)");
            Console.WriteLine("  0. Salir");
            Console.Write("  → ");
            if (Console.ReadLine() == "1")
            {
                foreach (var p in players.Where(p => p.IsAlive()))
                { p.Health = p.MaxHealth; p.Mana = 200; p.ClearNegativeStatus(); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"  ✔ {p.Name}: HP y MP restaurados completamente."); Console.ResetColor(); }
                Console.ReadKey(true);
            }
        }

        static void ShowShopFloor(List<Player> players)
        {
            Program.PrintBox("🏪 TIENDA ESPECIAL — NIVEL MERCADO", ConsoleColor.Yellow);
            Sprites.Print(Sprites.NPC["Mercader"], ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  Mercader: «¡Las mejores mercancías del reino!»");
            Console.ResetColor();
            Console.ReadKey(true);
            foreach (var p in players.Where(x => x.IsAlive())) Program.StaticShop(p);
        }

        static void ShowPetShopFloor(List<Player> players)
        {
            Program.PrintBox("🐾 NIVEL ESPECIAL — TIENDA DE MASCOTAS", ConsoleColor.Magenta);
            foreach (var p in players.Where(x => x.IsAlive())) CompanionShop.Open(p);
        }
    }

    // ═══════════════════════════════════════════════
    //  ITEM
    // ═══════════════════════════════════════════════
    class Item
    {
        public string Name { get; }
        public string Description { get; }
        public ItemType Type { get; }
        public Rarity Rarity { get; }
        public int Price { get; }
        public int HPRestore, MPRestore, AtkBonus, DefBonus, MaxHPBonus, MaxMPBonus, SpdBonus, CritBonus;
        public StatusEffect? GrantsStatus { get; }
        public ElementType? GrantsElement { get; }
        public bool IsConsumable => Type == ItemType.Potion || Type == ItemType.Scroll || Type == ItemType.Food;

        public Item(string name, string desc, ItemType type, Rarity rarity, int price,
            int hp = 0, int mp = 0, int atk = 0, int def = 0, int maxHp = 0,
            int maxMp = 0, int spd = 0, int crit = 0, StatusEffect? status = null, ElementType? element = null)
        {
            Name = name; Description = desc; Type = type; Rarity = rarity; Price = price;
            HPRestore = hp; MPRestore = mp; AtkBonus = atk; DefBonus = def;
            MaxHPBonus = maxHp; MaxMPBonus = maxMp; SpdBonus = spd; CritBonus = crit;
            GrantsStatus = status; GrantsElement = element;
        }
        public ConsoleColor GetRarityColor() => GameConfig.RarityColors[(int)Rarity];
        public string GetRarityStars() => GameConfig.RarityStars[(int)Rarity];
    }

    static class ItemDatabase
    {
        static readonly Random R = new();
        static readonly List<Item> AllDrops = new()
        {
            new Item("Poción Menor",       "Restaura 30 HP",         ItemType.Potion,    Rarity.Common,    10, hp:30),
            new Item("Poción Mayor",       "Restaura 70 HP",         ItemType.Potion,    Rarity.Uncommon,  25, hp:70),
            new Item("Poción Superior",    "Restaura 120 HP",        ItemType.Potion,    Rarity.Rare,      50, hp:120),
            new Item("Éter",               "Restaura 40 MP",         ItemType.Potion,    Rarity.Uncommon,  20, mp:40),
            new Item("Éter Mayor",         "Restaura 80 MP",         ItemType.Potion,    Rarity.Rare,      40, mp:80),
            new Item("Elixir",             "+80 HP / +40 MP",        ItemType.Potion,    Rarity.Rare,      50, hp:80, mp:40),
            new Item("Elixir Supremo",     "+150 HP +80 MP",         ItemType.Potion,    Rarity.Epic,     120, hp:150, mp:80),
            new Item("Antídoto",           "Cura estados negativos", ItemType.Potion,    Rarity.Common,    15),
            new Item("Poción de Agilidad", "+15 VEL por 3 turnos",   ItemType.Potion,    Rarity.Uncommon,  30, spd:15),
            new Item("Daga de Hierro",     "+5 ATK",                 ItemType.Weapon,    Rarity.Common,    30, atk:5),
            new Item("Espada de Acero",    "+12 ATK",                ItemType.Weapon,    Rarity.Uncommon,  60, atk:12),
            new Item("Hacha Rúnica",       "+20 ATK",                ItemType.Weapon,    Rarity.Rare,     120, atk:20),
            new Item("Lanza del Dragón",   "+25 ATK de Fuego",       ItemType.Weapon,    Rarity.Epic,     200, atk:25, element:ElementType.Fire),
            new Item("Espada Legendaria",  "+30 ATK +20 MaxHP",      ItemType.Weapon,    Rarity.Legendary,250, atk:30, maxHp:20),
            new Item("Arco de Viento",     "+18 ATK +10 CRIT",       ItemType.Weapon,    Rarity.Rare,     130, atk:18, crit:10),
            new Item("Cetro del Abismo",   "+22 ATK Oscuro",         ItemType.Weapon,    Rarity.Epic,     180, atk:22, element:ElementType.Dark),
            new Item("Arma Mítica",        "+50 ATK +30 MaxHP",      ItemType.Weapon,    Rarity.Mythic,   999, atk:50, maxHp:30),
            new Item("Escudo de Bronce",   "+5 DEF",                 ItemType.Armor,     Rarity.Common,    30, def:5),
            new Item("Armadura de Hierro", "+12 DEF",                ItemType.Armor,     Rarity.Uncommon,  70, def:12),
            new Item("Cota de Malla",      "+18 DEF",                ItemType.Armor,     Rarity.Rare,     110, def:18),
            new Item("Cota Épica",         "+20 DEF +20 MaxHP",      ItemType.Armor,     Rarity.Epic,     160, def:20, maxHp:20),
            new Item("Armadura del Dragón","+30 DEF +30 MaxHP",      ItemType.Armor,     Rarity.Legendary,350, def:30, maxHp:30),
            new Item("Peto Celestial",     "+40 DEF +50 MaxHP",      ItemType.Armor,     Rarity.Mythic,   999, def:40, maxHp:50),
            new Item("Amuleto de Vida",    "+30 MaxHP",              ItemType.Accessory, Rarity.Rare,      90, maxHp:30),
            new Item("Anillo de Maná",     "+30 MaxMP",              ItemType.Accessory, Rarity.Rare,      85, maxMp:30),
            new Item("Botas Veloces",      "+10 VEL",                ItemType.Accessory, Rarity.Uncommon,  55, spd:10),
            new Item("Guantes del Asesino","+15 CRIT",               ItemType.Accessory, Rarity.Rare,     100, crit:15),
            new Item("Corazón de Dragón",  "+60 MaxHP +15 DEF",      ItemType.Accessory, Rarity.Legendary,450, maxHp:60, def:15),
            new Item("Reliquia Ancestral", "+30 todo",               ItemType.Accessory, Rarity.Mythic,   999, atk:20, def:15, maxHp:50, crit:10),
            new Item("Pergamino de Fuego", "Daño fuego a todos",     ItemType.Scroll,    Rarity.Uncommon,  35),
            new Item("Pergamino de Hielo", "Congela enemigos",       ItemType.Scroll,    Rarity.Uncommon,  35),
            new Item("Pergamino de Rayo",  "Rayo en cadena",         ItemType.Scroll,    Rarity.Rare,      55),
            new Item("Pergamino Épico",    "Hechizo devastador",     ItemType.Scroll,    Rarity.Epic,     120),
            new Item("Hierba Mágica",      "Material de alquimia",   ItemType.Material,  Rarity.Common,     5),
            new Item("Cristal de Fuego",   "Material encantamiento", ItemType.Material,  Rarity.Uncommon,  20),
            new Item("Cristal de Magia",   "Material arcano",        ItemType.Material,  Rarity.Uncommon,  25),
            new Item("Metal Élfico",       "Material raro",          ItemType.Material,  Rarity.Rare,      50),
            new Item("Fragmento Sagrado",  "Material divino",        ItemType.Material,  Rarity.Rare,      45),
            new Item("Gema del Abismo",    "Material oscuro",        ItemType.Material,  Rarity.Epic,     100),
            new Item("Escama Ancestral",   "Trofeo de dragón",       ItemType.Material,  Rarity.Legendary,200),
            new Item("Polvo Volcánico",    "Inflamable",             ItemType.Material,  Rarity.Common,    10),
            new Item("Pluma de Grifo",     "Ligera como el viento",  ItemType.Material,  Rarity.Rare,      40),
            new Item("Cuero Élfico",       "Resistente",             ItemType.Material,  Rarity.Rare,      35),
            new Item("Carne Cruda",        "Para cocinar",           ItemType.Material,  Rarity.Common,     3),
            new Item("Hierbas",            "Para pociones",          ItemType.Material,  Rarity.Common,     3),
            new Item("Ración de Campaña",  "+25 HP",                 ItemType.Food,      Rarity.Common,     8, hp:25),
            new Item("Pan de Maná",        "+30 MP",                 ItemType.Food,      Rarity.Common,     8, mp:30),
            new Item("Estofado del Héroe", "+60 HP +20 MP",          ItemType.Food,      Rarity.Uncommon,  30, hp:60, mp:20),
            new Item("Festín de Campeón",  "+80 HP +20 MP +5 ATK",   ItemType.Food,      Rarity.Rare,      70, hp:80, mp:20, atk:5),
        };

        public static Item GetRandomDrop(int round)
        {
            var pool = AllDrops.Where(i =>
                (round >= 15 || i.Rarity != Rarity.Mythic) &&
                (round >= 10 || i.Rarity != Rarity.Legendary) &&
                (round >= 5 || (i.Rarity != Rarity.Epic && i.Rarity != Rarity.Legendary)) &&
                i.Type != ItemType.Material).ToList();
            if (round >= 3 && new Random().Next(100) < 20) pool.AddRange(AllDrops.Where(i => i.Type == ItemType.Material));
            return pool[R.Next(pool.Count)];
        }
        public static List<Item> GetAllItems() => AllDrops;
    }

    static class ShopDatabase
    {
        static readonly Random R = new();
        public static List<Item> GetShopItems(int round)
        {
            var shop = new List<Item>
            {
                new Item("Poción Menor",      "Restaura 30 HP",  ItemType.Potion,   Rarity.Common,   10, hp:30),
                new Item("Poción Mayor",      "Restaura 70 HP",  ItemType.Potion,   Rarity.Uncommon, 25, hp:70),
                new Item("Éter",              "Restaura 40 MP",  ItemType.Potion,   Rarity.Uncommon, 20, mp:40),
                new Item("Elixir",            "+80 HP +40 MP",   ItemType.Potion,   Rarity.Rare,     50, hp:80, mp:40),
                new Item("Antídoto",          "Cura estados",    ItemType.Potion,   Rarity.Common,   15),
                new Item("Daga de Hierro",    "+5 ATK",          ItemType.Weapon,   Rarity.Common,   30, atk:5),
                new Item("Espada de Acero",   "+12 ATK",         ItemType.Weapon,   Rarity.Uncommon, 60, atk:12),
                new Item("Escudo de Bronce",  "+5 DEF",          ItemType.Armor,    Rarity.Common,   30, def:5),
                new Item("Armadura de Hierro","+12 DEF",         ItemType.Armor,    Rarity.Uncommon, 70, def:12),
                new Item("Amuleto de Vida",   "+30 MaxHP",       ItemType.Accessory,Rarity.Rare,     90, maxHp:30),
                new Item("Botas Veloces",     "+10 VEL",         ItemType.Accessory,Rarity.Uncommon, 55, spd:10),
                new Item("Hierba Mágica",     "Material",        ItemType.Material, Rarity.Common,    5),
                new Item("Ración de Campaña", "+25 HP",          ItemType.Food,     Rarity.Common,    8, hp:25),
            };
            if (round >= 3) { shop.Add(new Item("Poción Superior", "120 HP", ItemType.Potion, Rarity.Rare, 50, hp: 120)); shop.Add(new Item("Pergamino de Fuego", "Fuego a todos", ItemType.Scroll, Rarity.Uncommon, 35)); }
            if (round >= 5) { shop.Add(new Item("Hacha Rúnica", "+20 ATK", ItemType.Weapon, Rarity.Rare, 120, atk: 20)); shop.Add(new Item("Cota de Malla", "+18 DEF", ItemType.Armor, Rarity.Rare, 110, def: 18)); }
            if (round >= 8) { shop.Add(new Item("Cota Épica", "+20 DEF +20 HP", ItemType.Armor, Rarity.Epic, 160, def: 20, maxHp: 20)); shop.Add(new Item("Lanza del Dragón", "+25 ATK", ItemType.Weapon, Rarity.Epic, 200, atk: 25)); }
            if (round >= 12) { shop.Add(new Item("Espada Legendaria", "+30 ATK +20 HP", ItemType.Weapon, Rarity.Legendary, 250, atk: 30, maxHp: 20)); shop.Add(new Item("Armadura del Dragón", "+30 DEF +30 HP", ItemType.Armor, Rarity.Legendary, 350, def: 30, maxHp: 30)); }
            if (round >= 18) { shop.Add(new Item("Arma Mítica", "+50 ATK", ItemType.Weapon, Rarity.Mythic, 999, atk: 50, maxHp: 30)); shop.Add(new Item("Peto Celestial", "+40 DEF", ItemType.Armor, Rarity.Mythic, 999, def: 40, maxHp: 50)); }
            return shop.OrderBy(_ => R.Next()).Take(Math.Min(shop.Count, 12)).ToList();
        }
    }

    // ═══════════════════════════════════════════════
    //  CHARACTER BASE
    // ═══════════════════════════════════════════════
    abstract class Character
    {
        static readonly Random R = new();
        public string Name { get; protected set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public bool Defending { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        readonly Dictionary<StatusEffect, int> _dur = new();
        readonly Dictionary<StatusEffect, int> _stk = new();

        protected Character(string n, int hp, int mp, int def = 0, int spd = 10)
        { Name = n; MaxHealth = hp; Health = hp; Mana = mp; Defense = def; Speed = spd; }

        public bool IsAlive() => Health > 0;

        public virtual void TakeDamage(int dmg, ElementType el = ElementType.Physical)
        {
            if (Defending) dmg = (int)(dmg * GameConfig.DEFEND_REDUCTION);
            dmg = Math.Max(1, dmg - Defense / 5);
            Health = Math.Max(0, Health - dmg);
            GlobalStats.TotalDamageReceived += dmg;
        }

        public void Heal(int amount)
        {
            int a = Math.Min(MaxHealth - Health, amount);
            Health = Math.Min(MaxHealth, Health + amount);
            GlobalStats.TotalHealingDone += a;
        }

        public void ApplyStatus(StatusEffect e, int turns, int stacks = 1)
        {
            if (_dur.ContainsKey(e)) { _dur[e] = Math.Max(_dur[e], turns); _stk[e] = Math.Min(_stk.GetValueOrDefault(e, 1) + stacks, 5); }
            else { _dur[e] = turns; _stk[e] = stacks; }
        }

        public bool HasStatus(StatusEffect e) => _dur.ContainsKey(e) && _dur[e] > 0;
        public bool HasAnyStatus() => _dur.Any(kv => kv.Value > 0);
        public string GetStatusString() => string.Join(",", _dur.Where(kv => kv.Value > 0).Select(kv => kv.Key.ToString()[..Math.Min(3, kv.Key.ToString().Length)]));

        public void TickStatus()
        {
            foreach (var k in _dur.Keys.ToList())
            {
                if (_dur[k] <= 0) continue;
                int stk = _stk.GetValueOrDefault(k, 1);
                switch (k)
                {
                    case StatusEffect.Poisoned: { int d = 8 * stk; Health = Math.Max(1, Health - d); break; }
                    case StatusEffect.Burned: { int d = 6 * stk; Health = Math.Max(1, Health - d); break; }
                    case StatusEffect.Bleeding: { int d = 10 * stk; Health = Math.Max(1, Health - d); break; }
                    case StatusEffect.Regenerating: Heal(15 * stk); break;
                    case StatusEffect.Doomed: if (_dur[k] == 1) Health = 0; break;
                }
                _dur[k]--;
            }
        }

        public void ClearStatus() => _dur.Clear();
        public void ClearNegativeStatus()
        {
            foreach (var s in new[]{ StatusEffect.Poisoned,StatusEffect.Burned,StatusEffect.Stunned,
                StatusEffect.Bleeding,StatusEffect.Frozen,StatusEffect.Cursed,StatusEffect.Silenced,
                StatusEffect.Weakened,StatusEffect.Confused,StatusEffect.Petrified,StatusEffect.Doomed })
                if (_dur.ContainsKey(s)) _dur[s] = 0;
        }
    }

    // ═══════════════════════════════════════════════
    //  PLAYER BASE
    // ═══════════════════════════════════════════════
    abstract class Player : Character
    {
        public int Gold { get; set; }
        public int XP { get; set; }
        public int Level { get; private set; } = 1;
        public int AttackBonus { get; set; }
        public int BaseAttack { get; protected set; }
        public int CritChance { get; set; } = 10;
        public int SpecialCost { get; protected set; } = 10;
        public int SpecialCost2 { get; protected set; } = 25;
        public int RoundsWon { get; set; }
        public int TotalKills { get; set; }
        public bool HasUsedRevive { get; set; } = false;
        public string ClassName { get; protected set; } = "Aventurero";
        public string SpecialName { get; protected set; } = "Especial";
        public string Special2Name { get; protected set; } = "Habilidad 2";
        public ElementType AttackElement { get; protected set; } = ElementType.Physical;
        public List<Item> Inventory { get; } = new();
        public TalentSystem Talents { get; } = new();
        public List<Quest> ActiveQuests { get; } = new();
        public Item? EquippedWeapon { get; private set; }
        public Item? EquippedArmor { get; private set; }
        public Item? EquippedAccessory { get; private set; }
        public Companion? Pet { get; set; }

        static readonly Random R = new();

        protected Player(string n, int hp, int mp, int baseAtk, int def = 0, int spd = 10)
            : base(n, hp, mp, def, spd) { BaseAttack = baseAtk; Gold = GameConfig.STARTING_GOLD; }

        public int Attack()
        {
            int base_ = BaseAttack + AttackBonus + (EquippedWeapon?.AtkBonus ?? 0);
            return base_ + R.Next(0, base_ / 4 + 1);
        }

        public void Tick()
        {
            TickStatus(); Defending = false;
            Mana = Math.Min(Mana + 8, 200);
            Pet?.ActInCombat(this, new List<Enemy>());
        }

        public void GainXP(int amount)
        {
            XP += amount;
            int needed = Level * 50;
            while (XP >= needed && Level < 99) { XP -= needed; Level++; needed = Level * 50; LevelUp(); OnLevelUp(); }
        }

        void LevelUp()
        {
            MaxHealth += 10; Health = Math.Min(Health + 20, MaxHealth); BaseAttack += 2; Defense++;
            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  ✨ {Name} subió a Nivel {Level}! +10 MaxHP +2 ATK +1 DEF"); Console.ResetColor();
        }
        protected virtual void OnLevelUp() { }

        public abstract void Special(List<Enemy> enemies);
        public abstract void Special2(List<Player> allies, List<Enemy> enemies);
        public abstract void PassiveAction(List<Player> allies, List<Enemy> enemies);

        public void DeathMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"\n  💀 {Name} ha caído en batalla.");
            Console.ResetColor();
        }

        public void UpdateQuestProgress(int kills)
        {
            foreach (var q in ActiveQuests.Where(q => q.Status == QuestStatus.Active && !q.IsComplete()))
            {
                q.CurrentKills += kills;
                if (q.IsComplete()) { q.Status = QuestStatus.Completed; GlobalStats.TotalQuestsCompleted++; Gold += q.GoldReward; GainXP(q.XPReward); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✔ MISIÓN COMPLETADA: {q.Name}! +{q.GoldReward}🪙 +{q.XPReward}XP"); Console.ResetColor(); }
            }
        }

        public void ShowQuests()
        {
            Console.Clear(); Program.PrintBox("📜 MISIONES", ConsoleColor.Yellow);
            if (!ActiveQuests.Any()) { Console.WriteLine("  Sin misiones activas."); Console.ReadKey(true); return; }
            foreach (var q in ActiveQuests)
            {
                ConsoleColor c = q.Status == QuestStatus.Completed ? ConsoleColor.Green : ConsoleColor.White;
                Console.ForegroundColor = c;
                Console.WriteLine($"  [{q.DifficultyRarity}] {q.Name}: {q.Description}");
                Console.WriteLine($"     {q.ProgressBar()} {q.CurrentKills}/{q.KillsRequired}  Rec: {q.GoldReward}🪙 {q.XPReward}XP");
                Console.ResetColor();
            }
            Console.ReadKey(true);
        }

        public void OpenInventory()
        {
            while (true)
            {
                Console.Clear(); Program.PrintBox($"🎒 INVENTARIO — {Name} ({Inventory.Count}/{GameConfig.MAX_INVENTORY})", ConsoleColor.Cyan);
                if (!Inventory.Any()) { Console.WriteLine("  (vacío)"); Console.ReadKey(true); return; }
                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.ForegroundColor = Inventory[i].GetRarityColor();
                    Console.WriteLine($"  {i + 1,2}. {Inventory[i].GetRarityStars()} [{Inventory[i].Rarity,-10}] {Inventory[i].Name,-28} — {Inventory[i].Description}");
                    Console.ResetColor();
                }
                Console.WriteLine("\n  0. Volver | Número = usar/equipar");
                Console.Write("  → ");
                if (!int.TryParse(Console.ReadLine(), out int idx) || idx == 0) return;
                if (idx >= 1 && idx <= Inventory.Count) UseItem(Inventory[idx - 1]);
            }
        }

        public void UseItem(Item item)
        {
            if (item.HPRestore > 0) { Heal(item.HPRestore); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"  +{item.HPRestore} HP"); Console.ResetColor(); }
            if (item.MPRestore > 0) { Mana = Math.Min(Mana + item.MPRestore, 200); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine($"  +{item.MPRestore} MP"); Console.ResetColor(); }
            if (item.GrantsStatus.HasValue) ApplyStatus(item.GrantsStatus.Value, 3);
            if (item.Type == ItemType.Weapon && item.AtkBonus > 0) { EquippedWeapon = item; Console.WriteLine($"  ⚔ Equipado: {item.Name}"); }
            if (item.Type == ItemType.Armor && item.DefBonus > 0) { EquippedArmor = item; Defense += item.DefBonus; MaxHealth += item.MaxHPBonus; Console.WriteLine($"  🛡 Equipado: {item.Name}"); }
            if (item.Type == ItemType.Accessory) { EquippedAccessory = item; AttackBonus += item.AtkBonus; Defense += item.DefBonus; MaxHealth += item.MaxHPBonus; CritChance += item.CritBonus; Speed += item.SpdBonus; Mana += item.MaxMPBonus; Console.WriteLine($"  ✨ Equipado: {item.Name}"); }
            if (item.AtkBonus > 0 && item.IsConsumable) AttackBonus += item.AtkBonus;
            if (item.Type == ItemType.Potion && item.Name == "Antídoto") ClearNegativeStatus();
            GlobalStats.TotalItemsUsed++;
            if (item.IsConsumable) Inventory.Remove(item);
            Console.ReadKey(true);
        }

        public void AdoptCompanion()
        {
            if (Pet != null) { Console.WriteLine($"\n  Ya tienes a {Pet.Icon} {Pet.Name} como compañero."); Console.ReadKey(true); return; }
            CompanionShop.Open(this);
        }

        public void OpenCrafting()
        {
            while (true)
            {
                Console.Clear(); Program.PrintBox($"⚗ CRAFTEO — {Name}", ConsoleColor.DarkGreen);
                var recipes = CraftingDatabase.AllRecipes;
                for (int i = 0; i < recipes.Count; i++)
                {
                    bool can = recipes[i].CanCraft(this);
                    Console.ForegroundColor = can ? ConsoleColor.White : ConsoleColor.DarkGray;
                    Console.WriteLine($"  {i + 1,2}. [{recipes[i].ResultRarity}] {recipes[i].ResultItemName,-30} Costo:{recipes[i].GoldCost}🪙 Nv.{recipes[i].LevelRequired}");
                    Console.WriteLine($"       Ingredientes: {recipes[i].GetIngredientsList()}");
                    Console.ResetColor();
                }
                Console.WriteLine("\n  0. Volver"); Console.Write("  → ");
                if (!int.TryParse(Console.ReadLine(), out int idx) || idx == 0) return;
                if (idx >= 1 && idx <= recipes.Count)
                {
                    var r = recipes[idx - 1];
                    var result = CraftingDatabase.CraftItem(r, this);
                    if (result != null && Inventory.Count < GameConfig.MAX_INVENTORY) { Inventory.Add(result); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✔ Fabricado: [{result.Rarity}] {result.Name}"); Console.ResetColor(); }
                    else if (result == null) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n  ✘ Requisitos no cumplidos."); Console.ResetColor(); }
                    Console.ReadKey(true);
                }
            }
        }
    }

    // ═══════════════════════════════════════════════
    //  CLASES DE PERSONAJE (con sprites en encabezado)
    // ═══════════════════════════════════════════════

    class Warrior : Player
    {
        int rage = 0; static readonly Random R = new();
        public Warrior(string n) : base(n, 200, 60, 22, def: 14, spd: 8) { ClassName = "Guerrero"; SpecialName = "Golpe Devastador"; Special2Name = "Grito de Batalla"; SpecialCost = 10; SpecialCost2 = 20; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; var t = e.OrderByDescending(x => x.MaxHealth).First(); int d = (int)((BaseAttack + AttackBonus) * (2.2f + rage * 0.1f)) + R.Next(5, 15); t.TakeDamage(d, AttackElement); GlobalStats.TotalDamageDealt += d; rage = Math.Min(rage + 2, 10); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n  ⚔ {Name} GOLPE DEVASTADOR → {t.Name}: {d}! Rabia:{rage}"); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; rage = Math.Min(rage + 5, 10); foreach (var p in a.Where(p => p.IsAlive())) { p.AttackBonus += 8; p.ApplyStatus(StatusEffect.Enraged, 3); } Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n  📢 {Name} GRITO DE BATALLA! Todos: +8 ATK +Enraged"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { int h = 20 + rage * 5; Heal(h); ApplyStatus(StatusEffect.Shielded, 2); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"\n  🛡 {Name} canalizando rabia. +{h} HP. Rabia:{rage}"); Console.ResetColor(); }
        protected override void OnLevelUp() { BaseAttack += 3; MaxHealth += 5; }
    }

    class Archer : Player
    {
        int focusShots = 0; static readonly Random R = new();
        public Archer(string n) : base(n, 115, 80, 18, def: 5, spd: 16) { ClassName = "Arquero"; SpecialName = "Lluvia de Flechas"; Special2Name = "Disparo Perforante"; SpecialCost = 15; SpecialCost2 = 20; CritChance = 25; AttackElement = ElementType.Wind; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int total = 0; Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"\n  🏹 {Name} LLUVIA DE FLECHAS!"); foreach (var en in e) { int d = (BaseAttack + AttackBonus) + R.Next(8, 18); en.TakeDamage(d, ElementType.Wind); total += d; } GlobalStats.TotalDamageDealt += total; focusShots++; Console.WriteLine($"  Total: {total}"); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; var t = e.OrderByDescending(x => x.MaxHealth).First(); int d = (int)((BaseAttack + AttackBonus) * 2.8f + focusShots * 8); bool crit = R.Next(100) < CritChance + 20; if (crit) { d = (int)(d * 1.8f); GlobalStats.TotalCriticalHits++; } t.TakeDamage(d, ElementType.Wind); GlobalStats.TotalDamageDealt += d; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🎯 {Name} DISPARO PERFORANTE → {t.Name}: {d}{(crit ? " 💥" : "")}"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { focusShots = Math.Min(focusShots + 3, 15); ApplyStatus(StatusEffect.Hasted, 2); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🏹 {Name} se concentra. Foco:{focusShots}"); Console.ResetColor(); }
        protected override void OnLevelUp() { CritChance += 2; Speed += 1; }
    }

    class Mage : Player
    {
        int spellPower = 0; static readonly Random R = new();
        public Mage(string n) : base(n, 88, 180, 12, def: 3, spd: 10) { ClassName = "Mago"; SpecialName = "Bola de Fuego"; Special2Name = "Tormenta Arcana"; SpecialCost = 15; SpecialCost2 = 30; CritChance = 15; AttackElement = ElementType.Fire; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int total = 0; foreach (var en in e) { int d = (int)((BaseAttack + AttackBonus) * 2.0f) + spellPower * 5 + R.Next(10, 25); en.TakeDamage(d, ElementType.Fire); en.ApplyStatus(StatusEffect.Burned, 3); total += d; } GlobalStats.TotalDamageDealt += total; spellPower = 0; Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n  🔥 {Name} BOLA DE FUEGO → Total: {total}"); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; int total = 0; foreach (var en in e) { var els = new[] { ElementType.Fire, ElementType.Ice, ElementType.Lightning, ElementType.Arcane }; var el = els[R.Next(els.Length)]; int d = (int)((BaseAttack + AttackBonus) * 1.8f) + spellPower * 3 + R.Next(8, 20); en.TakeDamage(d, el); total += d; } GlobalStats.TotalDamageDealt += total; Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  ⚡ {Name} TORMENTA ARCANA → Total: {total}"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { spellPower = Math.Min(spellPower + 3, 20); Mana = Math.Min(Mana + 20, 200); Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  💎 {Name} carga magia. Poder:{spellPower} +20 MP"); Console.ResetColor(); }
        protected override void OnLevelUp() { Mana += 15; BaseAttack += 1; }
    }

    class Healer : Player
    {
        int holyCharge = 0; static readonly Random R = new();
        public Healer(string n) : base(n, 125, 140, 9, def: 7, spd: 9) { ClassName = "Curandero"; SpecialName = "Curación Mayor"; Special2Name = "Resurrección"; SpecialCost = 15; SpecialCost2 = 35; AttackElement = ElementType.Holy; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int bonus = holyCharge * 5; holyCharge = 0; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✨ {Name} LUZ SAGRADA!"); foreach (var p in Program.Players.Where(p => p.IsAlive())) { int h = 50 + R.Next(15) + bonus; p.Heal(h); p.ApplyStatus(StatusEffect.Regenerating, 2); Console.WriteLine($"  ✔ {p.Name} +{h} HP"); } var boss = e.OrderByDescending(x => x.MaxHealth).First(); int dmg = (int)((BaseAttack + AttackBonus) * 1.5f) + bonus / 2; boss.TakeDamage(dmg, ElementType.Holy); Console.WriteLine($"  ✝ {boss.Name} recibe {dmg}."); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } var dead = a.FirstOrDefault(p => !p.IsAlive()); if (dead == null) { Console.WriteLine("\n  ✘ No hay caídos."); return; } Mana -= SpecialCost2; dead.Health = (int)(dead.MaxHealth * 0.4f); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"\n  ✨ {Name} RESURRECCIÓN: {dead.Name} revive!"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { holyCharge = Math.Min(holyCharge + 3, 15); var hurt = a.Where(p => p.IsAlive() && p.HasAnyStatus()).FirstOrDefault(); if (hurt != null) { hurt.ClearNegativeStatus(); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🌟 {Name} purifica a {hurt.Name}."); } else { int h = 15 + Level * 2; foreach (var p in a.Where(p => p.IsAlive())) p.Heal(h); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine($"\n  🌿 AURA SANADORA: todos +{15 + Level * 2} HP."); } Console.ResetColor(); }
        protected override void OnLevelUp() { MaxHealth += 5; Mana += 10; }
    }

    class Thief : Player
    {
        bool stealthed = false; int comboKills = 0; static readonly Random R = new();
        public Thief(string n) : base(n, 98, 75, 20, def: 4, spd: 22) { ClassName = "Ladrón"; SpecialName = "Golpe Bajo"; Special2Name = "Hojas Venenosas"; SpecialCost = 12; SpecialCost2 = 18; CritChance = 32; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; var t = e.OrderBy(x => x.Health).First(); float mult = stealthed ? 4.0f : 2.5f; if (comboKills > 0) mult += comboKills * 0.3f; int dmg = (int)((BaseAttack + AttackBonus) * mult); bool crit = R.Next(100) < CritChance + (stealthed ? 30 : 0); if (crit) { dmg = (int)(dmg * 1.8f); GlobalStats.TotalCriticalHits++; } t.TakeDamage(dmg, ElementType.Physical); GlobalStats.TotalDamageDealt += dmg; int stolen = R.Next(5, 20) + comboKills * 3; Gold += stolen; Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"\n  🗡 {Name} GOLPE BAJO → {t.Name}: {dmg}{(crit ? " 💥" : "")} Roba {stolen}🪙"); Console.ResetColor(); if (!t.IsAlive()) comboKills++; stealthed = false; }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; foreach (var en in e) { int d = (int)((BaseAttack + AttackBonus) * 0.8f) + R.Next(10, 20); en.TakeDamage(d, ElementType.Poison); en.ApplyStatus(StatusEffect.Poisoned, 4); en.ApplyStatus(StatusEffect.Bleeding, 2); } Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine($"\n  🗡 {Name} HOJAS VENENOSAS! (Veneno+Sangrado)"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { stealthed = true; ApplyStatus(StatusEffect.Invisible, 2); Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine($"\n  👤 {Name} entra en SIGILO. Combo:{comboKills}"); Console.ResetColor(); }
        protected override void OnLevelUp() { CritChance += 3; Speed += 2; }
    }

    class Monk : Player
    {
        int comboCount = 0; bool chiActive = false; static readonly Random R = new();
        public Monk(string n) : base(n, 135, 55, 19, def: 10, spd: 18) { ClassName = "Monje"; SpecialName = "Ráfaga de Golpes"; Special2Name = "Chi Dragón"; SpecialCost = 15; SpecialCost2 = 25; CritChance = 20; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; var t = e.OrderByDescending(x => x.Health).First(); int hits = 3 + comboCount / 2 + (chiActive ? 3 : 0); int total = 0; Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  👊 {Name} RÁFAGA ({hits} golpes):"); for (int i = 0; i < hits; i++) { int d = (BaseAttack + AttackBonus) / 2 + R.Next(8, 22); bool crit = R.Next(100) < CritChance; if (crit) { d = (int)(d * 1.8f); GlobalStats.TotalCriticalHits++; } if (chiActive) d = (int)(d * 1.5f); t.TakeDamage(d, ElementType.Physical); total += d; Console.Write($" {d}{(crit ? "!" : "")}"); } Console.WriteLine($"\n  Total:{total}"); GlobalStats.TotalDamageDealt += total; Console.ResetColor(); comboCount = Math.Min(comboCount + 1, 12); chiActive = false; }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; chiActive = true; ApplyStatus(StatusEffect.Empowered, 2); Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  🌀 {Name} CHI DEL DRAGÓN activado!"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { int h = 25 + Level * 3; int mp = 20; Heal(h); Mana = Math.Min(Mana + mp, 200); Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  🧘 {Name} medita. +{h} HP +{mp} MP. Combo:{comboCount}"); Console.ResetColor(); }
        protected override void OnLevelUp() { Defense += 2; Speed += 1; }
    }

    class Bard : Player
    {
        int melodyCharge = 0; static readonly Random R = new();
        public Bard(string n) : base(n, 108, 95, 12, def: 5, spd: 14) { ClassName = "Bardo"; SpecialName = "Canción de Batalla"; Special2Name = "Melodía del Caos"; SpecialCost = 20; SpecialCost2 = 30; AttackElement = ElementType.Wind; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int bAtk = 6 + melodyCharge * 2; int bHeal = 20 + melodyCharge * 5; melodyCharge = 0; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🎵 {Name} CANCIÓN DE BATALLA! (+{bAtk} ATK, +{bHeal} HP)"); foreach (var p in Program.Players.Where(p => p.IsAlive())) { p.AttackBonus += bAtk; p.Heal(bHeal); p.ApplyStatus(StatusEffect.Hasted, 2); Console.WriteLine($"     → {p.Name}: +{bAtk} ATK +{bHeal} HP"); } foreach (var en in e) { int d = (BaseAttack + AttackBonus) + R.Next(8, 20); en.TakeDamage(d, ElementType.Wind); if (R.Next(100) < 40) en.ApplyStatus(StatusEffect.Stunned, 1); } Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; foreach (var en in e) { var efs = new[] { StatusEffect.Confused, StatusEffect.Weakened, StatusEffect.Cursed, StatusEffect.Bleeding }; en.ApplyStatus(efs[R.Next(efs.Length)], 3); int d = (int)((BaseAttack + AttackBonus) * 1.2f) + R.Next(5, 15); en.TakeDamage(d, ElementType.Wind); } foreach (var p in a.Where(p => p.IsAlive())) { var buf = new[] { StatusEffect.Blessed, StatusEffect.Enraged, StatusEffect.Regenerating, StatusEffect.Hasted }; p.ApplyStatus(buf[R.Next(buf.Length)], 3); } Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"\n  🎶 {Name} MELODÍA DEL CAOS!"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { melodyCharge = Math.Min(melodyCharge + 2, 10); int xp = 15 + melodyCharge * 2; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🎶 {Name} BALADA. +{xp} XP a todos."); foreach (var p in a.Where(p => p.IsAlive())) p.GainXP(xp); Console.ResetColor(); }
        protected override void OnLevelUp() { Mana += 8; Speed += 1; }
    }

    class Paladin : Player
    {
        bool divineShield = false; int holyStacks = 0; static readonly Random R = new();
        public Paladin(string n) : base(n, 165, 75, 20, def: 16, spd: 9) { ClassName = "Paladín"; SpecialName = "Juicio Divino"; Special2Name = "Tierra Consagrada"; SpecialCost = 20; SpecialCost2 = 35; AttackElement = ElementType.Holy; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; var t = e.OrderByDescending(x => x.MaxHealth).First(); float mult = 2.8f + holyStacks * 0.3f; int dmg = (int)((BaseAttack + AttackBonus) * mult); t.TakeDamage(dmg, ElementType.Holy); t.ApplyStatus(StatusEffect.Cursed, 3); int sh = 30 + holyStacks * 5; Heal(sh); holyStacks = 0; Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"\n  ✝ {Name} JUICIO DIVINO → {t.Name}: {dmg}! +{sh} HP self."); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🌟 {Name} TIERRA CONSAGRADA!"); foreach (var p in a.Where(p => p.IsAlive())) { p.ApplyStatus(StatusEffect.Regenerating, 5); p.Defense += 5; Console.WriteLine($"  → {p.Name}: +Regen +5 DEF"); } Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { divineShield = !divineShield; holyStacks = Math.Min(holyStacks + 2, 10); if (divineShield) { foreach (var p in a.Where(p => p.IsAlive())) { p.ApplyStatus(StatusEffect.Blessed, 3); p.ApplyStatus(StatusEffect.Shielded, 2); } Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  🛡 {Name} ESCUDO DIVINO. Todos: Bendición+Escudo."); } Console.ResetColor(); }
        protected override void OnLevelUp() { Defense += 3; MaxHealth += 5; }
    }

    class Necromancer : Player
    {
        int soulStacks = 0; static readonly Random R = new();
        public Necromancer(string n) : base(n, 98, 130, 14, def: 3, spd: 10) { ClassName = "Nigromante"; SpecialName = "Drenaje de Almas"; Special2Name = "Invocar No-Muerto"; SpecialCost = 22; SpecialCost2 = 30; AttackElement = ElementType.Dark; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int total = 0; Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine($"\n  🌑 {Name} DRENAJE DE ALMAS! (Almas:{soulStacks})"); foreach (var en in e) { int d = (int)((BaseAttack + AttackBonus) * 1.3f) + soulStacks * 7; en.TakeDamage(d, ElementType.Dark); total += d / 3; Console.WriteLine($"     → {en.Name}: {d}"); } Heal(total); soulStacks = 0; Console.WriteLine($"  💜 Absorbe {total} HP."); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; soulStacks += 5; Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine($"\n  💀 {Name} invoca súbditos. Almas:{soulStacks}"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { soulStacks = Math.Min(soulStacks + 4, 25); foreach (var en in e) { en.ApplyStatus(StatusEffect.Cursed, 2); en.ApplyStatus(StatusEffect.Weakened, 1); } Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.WriteLine($"\n  💀 {Name} MALDICIÓN GRUPAL. Almas:{soulStacks}"); Console.ResetColor(); }
        protected override void OnLevelUp() { Mana += 12; BaseAttack += 1; }
    }

    class Alchemist : Player
    {
        int brewCount = 0; bool turboMode = false; static readonly Random R = new();
        public Alchemist(string n) : base(n, 105, 105, 15, def: 6, spd: 13) { ClassName = "Alquimista"; SpecialName = "Bomba Alquímica"; Special2Name = "Gran Explosión"; SpecialCost = 18; SpecialCost2 = 35; AttackElement = ElementType.Poison; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; brewCount++; float mult = turboMode ? 2.5f : 1.6f; int dmg = (int)((BaseAttack + AttackBonus) * mult) + brewCount * 5; int total = 0; Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine($"\n  ⚗ {Name} BOMBA ALQUÍMICA!{(turboMode ? " TURBO" : "")}"); foreach (var en in e) { en.TakeDamage(dmg, ElementType.Poison); en.ApplyStatus(StatusEffect.Poisoned, 3); total += dmg; Console.WriteLine($"     → {en.Name}: {dmg}"); } GlobalStats.TotalDamageDealt += total; turboMode = false; Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; turboMode = true; var hurt = a.Where(p => p.IsAlive()).OrderBy(p => (float)p.Health / p.MaxHealth).First(); int heal = 50 + Level * 3; hurt.Heal(heal); Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  💥 {Name} GRAN EXPLOSIÓN. TURBO activo. {hurt.Name}: +{heal} HP."); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { var hurt = a.Where(p => p.IsAlive()).OrderBy(p => (float)p.Health / p.MaxHealth).First(); int h = 40 + Level * 5; hurt.Heal(h); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ⚗ {Name} POCIÓN IMPROVISADA para {hurt.Name}: +{h} HP."); Console.ResetColor(); }
        protected override void OnLevelUp() { BaseAttack += 2; Mana += 5; }
    }

    class Berserker : Player
    {
        int bloodlust = 0; bool frenzyActive = false; static readonly Random R = new();
        public Berserker(string n) : base(n, 160, 35, 28, def: 6, spd: 14) { ClassName = "Berserker"; SpecialName = "Furia Sangrienta"; Special2Name = "Locura de Sangre"; SpecialCost = 10; SpecialCost2 = 20; CritChance = 22; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int selfDmg = (int)(MaxHealth * 0.08f); Health = Math.Max(1, Health - selfDmg); float hpRatio = 1 - (float)Health / MaxHealth; float mult = 2.0f + hpRatio * 3.0f + bloodlust * 0.2f; if (frenzyActive) mult *= 1.5f; var t = e.OrderByDescending(x => x.MaxHealth).First(); int dmg = (int)((BaseAttack + AttackBonus) * mult) + R.Next(0, 20); bool crit = R.Next(100) < CritChance + (int)(hpRatio * 30); if (crit) { dmg = (int)(dmg * 2.0f); GlobalStats.TotalCriticalHits++; } t.TakeDamage(dmg, ElementType.Physical); bloodlust = Math.Min(bloodlust + 2, 20); GlobalStats.TotalDamageDealt += dmg; if (dmg > GlobalStats.HighestDamageInOneTurn) { GlobalStats.HighestDamageInOneTurn = dmg; GlobalStats.HighestDamageDealer = Name; } Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"\n  💢 {Name} FURIA (x{mult:F1}) → {t.Name}: {dmg}{(crit ? " 💥 DOBLE" : "")}!"); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; frenzyActive = !frenzyActive; bloodlust += 5; Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(frenzyActive ? $"\n  💢 {Name} LOCURA DE SANGRE! ¡Imparable!" : $"\n  {Name} calma la Locura."); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { int h = bloodlust * 4; Heal(h); ApplyStatus(StatusEffect.Enraged, 2); Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"\n  💢 {Name} canaliza RABIA. +{h} HP. Sed:{bloodlust}"); Console.ResetColor(); }
        protected override void OnLevelUp() { BaseAttack += 5; MaxHealth -= 5; CritChance += 2; }
    }

    class Druid : Player
    {
        bool wildForm = false; int naturePower = 0; static readonly Random R = new();
        public Druid(string n) : base(n, 132, 100, 15, def: 9, spd: 11) { ClassName = "Druida"; SpecialName = "Llamada de la Naturaleza"; Special2Name = "Forma Salvaje"; SpecialCost = 22; SpecialCost2 = 25; AttackElement = ElementType.Earth; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int bonus = naturePower * 6; naturePower = 0; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  🌿 {Name} LLAMADA DE LA NATURALEZA!"); if (wildForm) { foreach (var en in e) { int d = (int)((BaseAttack + AttackBonus) * 2.2f) + bonus + R.Next(10, 25); en.TakeDamage(d, ElementType.Earth); en.ApplyStatus(StatusEffect.Stunned, 1); Console.WriteLine($"  🐻 {en.Name}: {d}"); } } else { foreach (var p in Program.Players.Where(p => p.IsAlive())) { int h = 35 + bonus / 2; p.Heal(h); p.ApplyStatus(StatusEffect.Regenerating, 3); } var st = e.OrderByDescending(x => x.MaxHealth).First(); int ed = (int)((BaseAttack + AttackBonus) * 1.5f) + bonus; st.TakeDamage(ed, ElementType.Earth); Console.WriteLine($"  🌳 Cura grupal + {ed} → {st.Name}"); } Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; wildForm = !wildForm; if (wildForm) { BaseAttack += 12; Defense -= 4; MaxHealth += 30; Health = Math.Min(Health + 30, MaxHealth); AttackElement = ElementType.Physical; Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine($"\n  🐻 {Name} FORMA SALVAJE! +12 ATK +30 HP"); } else { BaseAttack -= 12; Defense += 4; MaxHealth -= 30; Health = Math.Min(Health, MaxHealth); AttackElement = ElementType.Earth; Console.WriteLine($"\n  🌿 {Name} vuelve a forma natural."); } Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { naturePower = Math.Min(naturePower + 3, 15); foreach (var p in a.Where(p => p.IsAlive())) { p.Heal(12 + naturePower); if (!p.HasStatus(StatusEffect.Regenerating)) p.ApplyStatus(StatusEffect.Regenerating, 2); } Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  🌱 {Name} sintoniza Naturaleza. Poder:{naturePower}"); Console.ResetColor(); }
        protected override void OnLevelUp() { MaxHealth += 8; Mana += 8; }
    }

    class Summoner : Player
    {
        List<(string name, int hp, int atk)> summons = new(); int summonPower = 0; int maxSummons = 3; static readonly Random R = new();
        public Summoner(string n) : base(n, 110, 120, 11, def: 5, spd: 10) { ClassName = "Invocador"; SpecialName = "Invocación Masiva"; Special2Name = "Potenciar Invocaciones"; SpecialCost = 28; SpecialCost2 = 20; AttackElement = ElementType.Arcane; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"\n  ✨ {Name} INVOCACIÓN MASIVA!"); string[] cnames = { "Elemental de Fuego", "Golem de Piedra", "Serpiente Arcana", "Espíritu Lunar" }; int toS = Math.Min(2, maxSummons - summons.Count); for (int i = 0; i < toS; i++) { var s = (cnames[R.Next(cnames.Length)], 50 + Level * 8 + summonPower * 5, 10 + Level * 3 + summonPower * 2); summons.Add(s); Console.WriteLine($"  ⚡ Invocado: {s.Item1}"); } AttackWithSummons(e); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; summonPower = Math.Min(summonPower + 3, 15); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"\n  ✨ {Name} potencia invocaciones. Poder:{summonPower}"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { AttackWithSummons(e); if (summons.Count < maxSummons && Mana >= 10) { string[] ns = { "Familiar Arcano", "Espíritu Guardián" }; summons.Add((ns[R.Next(ns.Length)], 30 + Level * 5, 8 + Level * 2)); Mana -= 10; Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"\n  ✨ {Name} invoca nuevo compañero."); Console.ResetColor(); } }
        void AttackWithSummons(List<Enemy> enemies) { foreach (var s in summons) { if (!enemies.Any()) break; var t = enemies[R.Next(enemies.Count)]; int d = s.atk + R.Next(-2, 6); t.TakeDamage(d, ElementType.Arcane); Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"  ✨ {s.name} → {t.Name}: {d}"); Console.ResetColor(); } }
        protected override void OnLevelUp() { Mana += 12; if (Level % 5 == 0) maxSummons++; }
    }

    class DemonHunter : Player
    {
        int demonKills = 0; bool shadowMode = false; static readonly Random R = new();
        public DemonHunter(string n) : base(n, 120, 80, 21, def: 7, spd: 17) { ClassName = "Cazador de Demonios"; SpecialName = "Marca del Cazador"; Special2Name = "Modo Umbral"; SpecialCost = 18; SpecialCost2 = 22; CritChance = 25; AttackElement = ElementType.Dark; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; var t = e.OrderByDescending(x => x.MaxHealth).First(); float mult = 2.0f + demonKills * 0.15f; if (shadowMode) mult *= 1.6f; int dmg = (int)((BaseAttack + AttackBonus) * mult); bool crit = R.Next(100) < CritChance + demonKills; if (crit) { dmg = (int)(dmg * 2f); GlobalStats.TotalCriticalHits++; } t.TakeDamage(dmg, ElementType.Dark); t.ApplyStatus(StatusEffect.Weakened, 3); GlobalStats.TotalDamageDealt += dmg; if (!t.IsAlive()) demonKills++; Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine($"\n  🏹 {Name} MARCA → {t.Name}: {dmg}{(crit ? " 💥" : "")} Demonios:{demonKills}"); Console.ResetColor(); }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; shadowMode = !shadowMode; if (shadowMode) { ApplyStatus(StatusEffect.Invisible, 3); ApplyStatus(StatusEffect.Hasted, 3); Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine($"\n  🌑 {Name} MODO UMBRAL. x1.6 dmg!"); } else Console.WriteLine($"\n  {Name} desactiva Modo Umbral."); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { foreach (var en in e) en.ApplyStatus(StatusEffect.Cursed, 2); Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine($"\n  🔍 {Name} marca a todos. Demonios:{demonKills}"); Console.ResetColor(); }
        protected override void OnLevelUp() { CritChance += 2; Speed += 2; }
    }

    class Elementalist : Player
    {
        ElementType[] elements = { ElementType.Fire, ElementType.Ice, ElementType.Lightning, ElementType.Earth };
        int elementIndex = 0; int elementalCharge = 0; bool prismMode = false; static readonly Random R = new();
        public Elementalist(string n) : base(n, 100, 135, 13, def: 4, spd: 11) { ClassName = "Elementalista"; SpecialName = "Convergencia Elemental"; Special2Name = "Prisma Arcano"; SpecialCost = 22; SpecialCost2 = 35; CritChance = 15; AttackElement = ElementType.Fire; }
        public override void Special(List<Enemy> e) { Mana -= SpecialCost; int charge = elementalCharge; elementalCharge = 0; Console.ForegroundColor = ConsoleColor.Cyan; if (prismMode) { Console.WriteLine($"\n  🌈 {Name} CONVERGENCIA PRISMA!"); foreach (var en in e) { int total = 0; foreach (var el in elements) { int d = (int)((BaseAttack + AttackBonus) * 1.0f) + charge * 3 + R.Next(8, 18); en.TakeDamage(d, el); total += d; } Console.WriteLine($"  → {en.Name}: {total} total"); } prismMode = false; } else { var cur = elements[elementIndex]; Console.WriteLine($"\n  ⚡ {Name} CONVERGENCIA [{cur}]!"); foreach (var en in e) { int d = (int)((BaseAttack + AttackBonus) * 2.0f) + charge * 5 + R.Next(10, 25); en.TakeDamage(d, cur); Console.WriteLine($"  → {en.Name}: {d}"); switch (cur) { case ElementType.Fire: en.ApplyStatus(StatusEffect.Burned, 3); break; case ElementType.Ice: en.ApplyStatus(StatusEffect.Frozen, 2); break; default: en.ApplyStatus(StatusEffect.Stunned, 1); break; } } } Console.ResetColor(); elementIndex = (elementIndex + 1) % elements.Length; AttackElement = elements[elementIndex]; }
        public override void Special2(List<Player> a, List<Enemy> e) { if (Mana < SpecialCost2) { Console.WriteLine("\n  ✘ Sin maná."); return; } Mana -= SpecialCost2; prismMode = true; elementalCharge = Math.Min(elementalCharge + 8, 20); Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  🌈 {Name} PRISMA ARCANO activo!"); Console.ResetColor(); }
        public override void PassiveAction(List<Player> a, List<Enemy> e) { elementalCharge = Math.Min(elementalCharge + 3, 20); elementIndex = (elementIndex + 1) % elements.Length; AttackElement = elements[elementIndex]; Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  💎 {Name} cambia a [{elements[elementIndex]}]. Carga:{elementalCharge}"); Console.ResetColor(); }
        protected override void OnLevelUp() { Mana += 15; BaseAttack += 1; }
    }

    // ═══════════════════════════════════════════════
    //  ENEMY
    // ═══════════════════════════════════════════════
    class Enemy : Character
    {
        public int GoldDrop { get; }
        public int XPDrop { get; }
        static readonly Random R = new();

        public Enemy(string n, int hp, int atk, int gold = 5, int xp = 10)
            : base(n, hp, 0, atk / 4) { GoldDrop = gold; XPDrop = xp; }

        public int Attack() => Math.Max(1, (Defense * 5) + R.Next(-5, 8)); // Defense holds base attack internally
        // Actually let's fix: use a real atk field
    }

    // Proper enemy with separate attack field
    class EnemyUnit : Character
    {
        public int GoldDrop { get; }
        public int XPDrop { get; }
        int baseAtk; static readonly Random R = new();
        public virtual string SpriteKey => "Normal";

        public EnemyUnit(string n, int hp, int atk, int gold = 5, int xp = 10)
            : base(n, hp, 0, 0) { baseAtk = atk; GoldDrop = gold; XPDrop = xp; }

        public virtual int AttackRoll() => Math.Max(1, baseAtk + R.Next(-3, 8));
        public virtual void UseSpecialAttack(Player target) { }
    }

    class EliteEnemy : EnemyUnit
    {
        public override string SpriteKey => "Elite";
        public EliteEnemy(string n, int hp, int atk) : base(n, hp, atk, 15, 20) { }
    }

    class BossEnemy : EnemyUnit
    {
        public override string SpriteKey => "Boss";
        static readonly Random R = new();
        public BossEnemy(string n, int hp, int atk) : base(n, hp, atk, 40, 80) { }
        public override void UseSpecialAttack(Player t)
        {
            int d = AttackRoll() * 2; t.TakeDamage(d, ElementType.Physical);
            t.ApplyStatus(new[] { StatusEffect.Weakened, StatusEffect.Stunned, StatusEffect.Burned }[R.Next(3)], 2);
            Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"  ⚠ {Name} HABILIDAD ESPECIAL → {t.Name}: {d}!"); Console.ResetColor();
        }
    }

    class LegendaryBoss : BossEnemy
    {
        public LegendaryBoss(string n, int hp, int atk) : base(n, hp, atk) { }
        public override string SpriteKey => "Boss";
    }

    class MythicBoss : BossEnemy
    {
        public MythicBoss(string n, int hp, int atk) : base(n, hp, atk) { }
        public override string SpriteKey => "Mythic";
    }

    // ═══════════════════════════════════════════════
    //  PROGRAMA PRINCIPAL
    // ═══════════════════════════════════════════════
    class Program
    {
        static readonly Random Rand = new();
        internal static List<Player> Players = new();
        internal static Guild? ActiveGuild = null;
        static List<Quest> GlobalQuests = new();
        static int round = 1;
        // Genera la secuencia de tipos de pisos para los próximos pisos
        static FloorType[] floorSchedule = Array.Empty<FloorType>();
        static int floorIndex = 0;

        // ─── Sprites de nivel ─────────────────────────────────
        static readonly Dictionary<FloorType, string> FloorBanners = new()
        {
            [FloorType.Combat]    = "⚔  PISO DE COMBATE",
            [FloorType.Shop]      = "🏪 TIENDA ESPECIAL",
            [FloorType.PetShop]   = "🐾 TIENDA DE MASCOTAS",
            [FloorType.Peaceful]  = "🌸 PISO PACÍFICO",
            [FloorType.Healing]   = "⛪ SANTUARIO DE CURACIÓN",
            [FloorType.Boss]      = "⚔  ¡JEFE DE PISO!",
            [FloorType.MythicBoss]= "☠  ¡JEFE MÍTICO!",
        };

        static void Main()
        {
            Console.Title = "⚔  RPG FINAL EDITION v2  ⚔";
            Console.OutputEncoding = Encoding.UTF8;
            GlobalStats.GameStartTime = DateTime.Now;
            ShowIntro();
            SetupGuild();
            SetupPlayers();
            SetupQuests();
            GenerateFloorSchedule();
            GameLoop();
        }

        // ─────────────────────────────────────────────────────
        // GENERACIÓN DE PISOS
        // Cada ciclo de 10 pisos:
        //  Piso 1-4: combate
        //  Piso 3 y 7: random pet shop (25%) o pacífico
        //  Piso 5: boss
        //  Piso 6: tienda especial
        //  Piso 8: santuario de curación
        //  Piso 9: combate
        //  Piso 10: jefe mítico
        // ─────────────────────────────────────────────────────
        static void GenerateFloorSchedule()
        {
            var schedule = new List<FloorType>();
            for (int cycle = 0; cycle < 5; cycle++) // 5 ciclos = 50 pisos
            {
                schedule.Add(FloorType.Combat);
                schedule.Add(FloorType.Combat);
                // Piso 3 del ciclo: aleatorio (pet shop o pacífico)
                schedule.Add(Rand.Next(100) < 30 ? FloorType.PetShop : FloorType.Peaceful);
                schedule.Add(FloorType.Combat);
                schedule.Add(FloorType.Boss);
                schedule.Add(FloorType.Shop);
                // Piso 7: aleatorio (pet shop o pacífico)
                schedule.Add(Rand.Next(100) < 25 ? FloorType.PetShop : FloorType.Peaceful);
                schedule.Add(FloorType.Healing);
                schedule.Add(FloorType.Combat);
                schedule.Add(FloorType.MythicBoss);
            }
            floorSchedule = schedule.ToArray();
        }

        static FloorType GetFloorType(int r)
        {
            int idx = (r - 1) % floorSchedule.Length;
            return floorSchedule[idx];
        }

        // ─────────────────────────────────────────────────────
        static void ShowIntro()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
  ██████╗ ██████╗  ██████╗     ███████╗██╗███╗   ██╗ █████╗ ██╗
  ██╔══██╗██╔══██╗██╔════╝     ██╔════╝██║████╗  ██║██╔══██╗██║
  ██████╔╝██████╔╝██║  ███╗    █████╗  ██║██╔██╗ ██║███████║██║
  ██╔══██╗██╔═══╝ ██║   ██║    ██╔══╝  ██║██║╚██╗██║██╔══██║██║
  ██║  ██║██║     ╚██████╔╝    ██║     ██║██║ ╚████║██║  ██║███████╗
  ╚═╝  ╚═╝╚═╝      ╚═════╝     ╚═╝     ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ━━━  EDICIÓN DEFINITIVA v2.0 — 4 JUGADORES  ━━━\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  15 Clases | Mazmorras | Crafteo | Talentos | Misiones | Gremios");
            Console.WriteLine("  Pisos especiales | Tienda en nivel dedicado | Mascotas | NPCs neutrales");
            Console.ResetColor(); Console.WriteLine();
            Console.WriteLine("  Pulsa cualquier tecla para empezar..."); Console.ReadKey(true);
        }

        static void SetupGuild()
        {
            Console.Clear(); PrintBox("🏰 CREAR GREMIO", ConsoleColor.Yellow);
            Console.Write("\n  Nombre de tu Gremio (Enter = 'Los Sin Nombre'): ");
            string guildName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(guildName)) guildName = "Los Sin Nombre";
            ActiveGuild = new Guild(guildName);
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✔ Gremio «{guildName}» fundado."); Console.ResetColor(); Console.ReadKey(true);
        }

        static void SetupPlayers()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"  Cantidad de jugadores (1-{GameConfig.MAX_PLAYERS}): "); Console.ResetColor();
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 1 || n > GameConfig.MAX_PLAYERS) n = 1;
            for (int i = 0; i < n; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  ── Jugador {i + 1} ──"); Console.ResetColor();
                var player = CreatePlayer();
                Players.Add(player);
                ActiveGuild?.Members.Add(player.Name);
            }
        }

        static Player CreatePlayer()
        {
            while (true)
            {
                Console.Clear(); PrintBox("ELIGE TU CLASE", ConsoleColor.Cyan); Console.WriteLine();
                var classes = new (string num, string cls, string name, string stats)[]
                {
                    ("1", "Guerrero",            "Guerrero",            "HP:200 ATK:22 DEF:14 VEL:8"),
                    ("2", "Arquero",             "Arquero",             "HP:115 ATK:18 DEF:5  VEL:16"),
                    ("3", "Mago",                "Mago",                "HP:88  ATK:12 DEF:3  VEL:10"),
                    ("4", "Curandero",           "Curandero",           "HP:125 ATK:9  DEF:7  VEL:9"),
                    ("5", "Ladrón",              "Ladrón",              "HP:98  ATK:20 DEF:4  VEL:22"),
                    ("6", "Monje",               "Monje",               "HP:135 ATK:19 DEF:10 VEL:18"),
                    ("7", "Bardo",               "Bardo",               "HP:108 ATK:12 DEF:5  VEL:14"),
                    ("8", "Paladín",             "Paladín",             "HP:165 ATK:20 DEF:16 VEL:9"),
                    ("9", "Nigromante",          "Nigromante",          "HP:98  ATK:14 DEF:3  VEL:10"),
                    ("10","Alquimista",          "Alquimista",          "HP:105 ATK:15 DEF:6  VEL:13"),
                    ("11","Berserker",           "Berserker",           "HP:160 ATK:28 DEF:6  VEL:14"),
                    ("12","Druida",              "Druida",              "HP:132 ATK:15 DEF:9  VEL:11"),
                    ("13","Invocador",           "Invocador",           "HP:110 ATK:11 DEF:5  VEL:10"),
                    ("14","Cazador de Demonios", "Cazador de Demonios", "HP:120 ATK:21 DEF:7  VEL:17"),
                    ("15","Elementalista",       "Elementalista",       "HP:100 ATK:13 DEF:4  VEL:11"),
                };
                foreach (var c in classes)
                {
                    var sprite = Sprites.GetClassSprite(c.cls);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write($"  {c.num,2}. ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{c.name,-24}");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($" {sprite[0]} ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($" {c.stats}");
                    Console.ResetColor();
                }
                Console.Write("\n  Opción: "); string op = Console.ReadLine() ?? "";
                Console.Write("  Nombre: "); string name = Console.ReadLine() ?? "Héroe";
                if (string.IsNullOrWhiteSpace(name)) name = "Héroe";

                Player? player = op switch
                {
                    "1" => new Warrior(name), "2" => new Archer(name), "3" => new Mage(name),
                    "4" => new Healer(name), "5" => new Thief(name), "6" => new Monk(name),
                    "7" => new Bard(name), "8" => new Paladin(name), "9" => new Necromancer(name),
                    "10" => new Alchemist(name), "11" => new Berserker(name), "12" => new Druid(name),
                    "13" => new Summoner(name), "14" => new DemonHunter(name), "15" => new Elementalist(name),
                    _ => null
                };
                if (player != null)
                {
                    if (ActiveGuild != null) { player.AttackBonus += ActiveGuild.BonusAttack; player.Defense += ActiveGuild.BonusDefense; }
                    // Mostrar sprite de la clase
                    Console.Clear(); PrintBox($"✔ {player.ClassName.ToUpper()} CREADO", ConsoleColor.Green);
                    Sprites.Print(Sprites.GetClassSprite(player.ClassName), ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  «{name}» (Oro inicial: {player.Gold}🪙)"); Console.ResetColor();
                    Console.ReadKey(true);
                    return player;
                }
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Opción inválida."); Console.ResetColor(); Console.ReadKey(true);
            }
        }

        static void SetupQuests()
        {
            GlobalQuests = QuestDatabase.GetStarterQuests();
            foreach (var p in Players)
                foreach (var q in GlobalQuests.Take(3)) { q.Status = QuestStatus.Active; q.StartedRound = 1; p.ActiveQuests.Add(q); }
        }

        // ─────────────────────────────────────────────────────
        // GAME LOOP PRINCIPAL
        // ─────────────────────────────────────────────────────
        static void GameLoop()
        {
            while (Players.Any(p => p.IsAlive()))
            {
                GlobalStats.HighestRound = Math.Max(GlobalStats.HighestRound, round);
                WorldTime.Advance(2);
                if (round % 5 == 0) WorldTime.ChangeBiome(Enum.GetValues<BiomeType>()[Rand.Next(8)]);

                FloorType floorType = GetFloorType(round);

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n  ══════════  PISO {round}  ══════════");
                Console.ResetColor();
                WorldTime.ShowInfo();

                // Mostrar banner del tipo de piso
                Console.ForegroundColor = floorType switch {
                    FloorType.MythicBoss => ConsoleColor.Magenta,
                    FloorType.Boss => ConsoleColor.Red,
                    FloorType.Shop or FloorType.PetShop => ConsoleColor.Yellow,
                    FloorType.Peaceful or FloorType.Healing => ConsoleColor.Green,
                    _ => ConsoleColor.White
                };
                Console.WriteLine($"\n  ★ {FloorBanners[floorType]} ★");
                Console.ResetColor();

                // Mostrar sprites del tipo de piso
                ShowFloorSprite(floorType);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n  Pulsa una tecla para continuar..."); Console.ResetColor();
                Console.ReadKey(true);

                // Ejecutar lógica del piso
                switch (floorType)
                {
                    case FloorType.Peaceful:
                    case FloorType.Healing:
                    case FloorType.PetShop:
                    case FloorType.Shop:
                        NpcSystem.ShowNPCScene(floorType, Players);
                        break;
                    case FloorType.Combat:
                        Battle(GenerateEnemies(floorType));
                        break;
                    case FloorType.Boss:
                        Battle(GenerateEnemies(floorType));
                        break;
                    case FloorType.MythicBoss:
                        Battle(GenerateEnemies(floorType));
                        break;
                }

                round++;
                if (ActiveGuild != null) { ActiveGuild.AddExperience(10 + round * 2); }
            }

            ShowGameOver();
        }

        static void ShowFloorSprite(FloorType ft)
        {
            switch (ft)
            {
                case FloorType.Shop:
                    Sprites.Print(Sprites.NPC["Mercader"], ConsoleColor.Yellow); break;
                case FloorType.PetShop:
                    Sprites.Print(Sprites.NPC["Vendedor_Mascotas"], ConsoleColor.Magenta); break;
                case FloorType.Peaceful:
                    Sprites.Print(Sprites.NPC["Sabio"], ConsoleColor.Green); break;
                case FloorType.Healing:
                    Sprites.Print(Sprites.NPC["Curandero_NPC"], ConsoleColor.Cyan); break;
                case FloorType.Boss:
                    Sprites.Print(Sprites.Enemy["Boss"], ConsoleColor.DarkRed); break;
                case FloorType.MythicBoss:
                    Sprites.Print(Sprites.Enemy["Mythic"], ConsoleColor.Magenta); break;
                default:
                    Sprites.Print(Sprites.Enemy["Normal"], ConsoleColor.DarkYellow); break;
            }
        }

        // ─────────────────────────────────────────────────────
        // GENERACIÓN DE ENEMIGOS — BALANCEADO PARA 4 JUGADORES
        // La dificultad base escala con la ronda pero se ajusta al
        // tamaño real del grupo para que 1 jugador no muera en 3 turnos.
        // ─────────────────────────────────────────────────────
        static List<EnemyUnit> GenerateEnemies(FloorType ft)
        {
            var enemies = new List<EnemyUnit>();
            int playerCount = Players.Count(p => p.IsAlive());
            // Escala de HP/ATK ajustada: diseñada para 4 jugadores como referencia
            // Para 1 jugador será más fácil porque los stats base se reducen
            float difficulty = 0.5f + (round * 0.05f); // sube gradualmente
            // Factor de escala por número de jugadores (base=4)
            float partyScale = Math.Max(0.4f, playerCount / 4f);

            int baseHp = (int)(60 * difficulty * partyScale) + 20;
            int baseAtk = (int)(8 * difficulty * partyScale) + 5;
            // Bonos de clima
            if (WorldTime.CurrentWeather == WeatherType.Eclipse) { baseHp += 20; baseAtk += 5; }
            if (WorldTime.IsNight) { baseAtk += 3; }

            if (ft == FloorType.MythicBoss)
            {
                int mhp = (int)(600 * partyScale) + round * 15;
                int matk = (int)(50 * partyScale) + round * 2;
                enemies.Add(new MythicBoss($"☠ DIOS DEL ABISMO Lv.{round}", mhp, matk));
                for (int i = 0; i < Math.Min(2, playerCount); i++)
                    enemies.Add(new EliteEnemy($"Guardián {(char)('A' + i)}", baseHp + 30, baseAtk + 5));
            }
            else if (ft == FloorType.Boss)
            {
                int bhp = (int)(280 * partyScale) + round * 12;
                int batk = (int)(30 * partyScale) + round * 1;
                string[] bn = { "SEÑOR DE LA OSCURIDAD", "REY ESQUELETO", "ARCHIMAGO CORRUPTO", "DRAGÓN INMORTAL", "HIDRA ANCESTRAL" };
                enemies.Add(new LegendaryBoss($"⚔ {bn[Rand.Next(bn.Length)]}", bhp, batk));
                // Añadir 1 minion por cada 2 jugadores
                for (int i = 0; i < playerCount / 2; i++)
                    enemies.Add(new EliteEnemy($"Esbirro {(char)('A' + i)} ★", baseHp, baseAtk));
            }
            else
            {
                // Combate normal: enemies count = playerCount + 1..3
                int count = playerCount + Rand.Next(0, 3);
                for (int i = 0; i < count; i++)
                {
                    string n = GameConfig.EnemyTypes[Rand.Next(GameConfig.EnemyTypes.Length)] + " " + (char)('A' + i);
                    int roll = Rand.Next(100);
                    int ehp = baseHp + Rand.Next(15);
                    int eatk = baseAtk + Rand.Next(4);
                    if (roll < 8) enemies.Add(new BossEnemy(n + " ÉLITE", ehp + 50, eatk + 10));
                    else if (roll < 25) enemies.Add(new EliteEnemy(n + " ★", ehp + 20, eatk + 6));
                    else enemies.Add(new EnemyUnit(n, ehp, eatk, 5 + round, 10 + round * 2));
                }
            }
            return enemies;
        }

        // ─────────────────────────────────────────────────────
        // BATALLA
        // ─────────────────────────────────────────────────────
        static void Battle(List<EnemyUnit> enemies)
        {
            while (Players.Any(p => p.IsAlive()) && enemies.Count > 0)
            {
                var turnOrder = Players.Where(p => p.IsAlive())
                    .OrderByDescending(p => p.Speed + WorldTime.GetWeatherEffects().spd).ToList();

                foreach (var p in turnOrder)
                {
                    if (!p.IsAlive()) continue;
                    if (p.HasStatus(StatusEffect.Stunned) || p.HasStatus(StatusEffect.Frozen) || p.HasStatus(StatusEffect.Petrified))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\n  ⚠ {p.Name} no puede actuar ({p.GetStatusString()}).");
                        Console.ResetColor(); p.Tick(); Console.ReadKey(true); continue;
                    }
                    p.Tick();

                    // Mascota ataca
                    if (p.Pet != null && enemies.Any() && Rand.Next(100) < 35)
                    {
                        // Adapt pet attack to EnemyUnit
                        var petTarget = enemies[Rand.Next(enemies.Count)];
                        int petDmg = 8 + Rand.Next(5) + p.Pet.Level * 2;
                        petTarget.TakeDamage(petDmg);
                        Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"  {p.Pet.Icon} {p.Pet.Name} ataca a {petTarget.Name}: {petDmg}!"); Console.ResetColor();
                    }

                    bool actionTaken = false;
                    while (!actionTaken)
                    {
                        Console.Clear(); ShowStatus(enemies); ShowPlayerMenu(p);
                        string op = Console.ReadLine() ?? "";
                        actionTaken = HandlePlayerAction(p, op, enemies);
                    }

                    int killed = enemies.Count(e => !e.IsAlive());
                    if (killed > 0) { p.TotalKills += killed; GlobalStats.TotalEnemiesKilled += killed; p.UpdateQuestProgress(killed); if (ActiveGuild != null) ActiveGuild.TotalKills += killed; }
                    enemies.RemoveAll(e => !e.IsAlive());
                    if (enemies.Count == 0) break;
                }

                if (enemies.Count > 0) EnemyTurn(enemies);

                // Revive por talento
                foreach (var p in Players.Where(p => !p.IsAlive() && !p.HasUsedRevive))
                {
                    if (p.Talents.GetUnlockedTalents().Contains("Resiliencia"))
                    { p.Health = (int)(p.MaxHealth * 0.3f); p.HasUsedRevive = true; Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  ✨ RESILIENCIA: {p.Name} revive!"); Console.ResetColor(); }
                    else p.DeathMessage();
                }
            }

            if (Players.Any(p => p.IsAlive())) VictoryScreen(enemies);
        }

        static bool HandlePlayerAction(Player p, string op, List<EnemyUnit> enemies)
        {
            switch (op)
            {
                case "1":
                    var t1 = ChooseTarget(enemies); if (t1 == null) return false;
                    int dmg = p.Attack(); bool crit = Rand.Next(100) < p.CritChance;
                    if (crit) { dmg = (int)(dmg * GameConfig.BASE_CRIT_MULTIPLIER); GlobalStats.TotalCriticalHits++; }
                    dmg = Math.Max(1, dmg + WorldTime.GetWeatherEffects().atk);
                    t1.TakeDamage(dmg, p.AttackElement); GlobalStats.TotalDamageDealt += dmg;
                    if (dmg > GlobalStats.HighestDamageInOneTurn) { GlobalStats.HighestDamageInOneTurn = dmg; GlobalStats.HighestDamageDealer = p.Name; }
                    Console.ForegroundColor = crit ? ConsoleColor.Yellow : ConsoleColor.White;
                    Console.WriteLine(crit ? $"\n  💥 ¡CRÍTICO! {p.Name} → {t1.Name}: {dmg}" : $"\n  ⚔ {p.Name} → {t1.Name}: {dmg}");
                    Console.ResetColor(); Console.ReadKey(true); return true;

                case "2":
                    if (p.Mana < p.SpecialCost) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n  ✘ Sin maná ({p.SpecialCost} req)."); Console.ResetColor(); Console.ReadKey(true); return false; }
                    // Adapt enemies list
                    var eList2 = AdaptEnemies(enemies); p.Special(eList2); enemies.RemoveAll(e => !e.IsAlive()); Console.ReadKey(true); return true;

                case "3":
                    p.Defending = true; p.ApplyStatus(StatusEffect.Shielded, 1);
                    Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine($"\n  🛡 {p.Name} se defiende."); Console.ResetColor(); Console.ReadKey(true); return true;

                case "4": p.OpenInventory(); return true;

                case "5":
                    // Tienda solo disponible en acción de combate (como bonus)
                    StaticShop(p); return true;

                case "6":
                    var eList6 = AdaptEnemies(enemies); p.PassiveAction(Players, eList6); Console.ReadKey(true); return true;

                case "7":
                    if (p.Mana < p.SpecialCost2) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"\n  ✘ Sin maná ({p.SpecialCost2} req)."); Console.ResetColor(); Console.ReadKey(true); return false; }
                    var eList7 = AdaptEnemies(enemies); p.Special2(Players, eList7); Console.ReadKey(true); return true;

                case "8": p.Talents.ShowTalentMenu(p); return false;
                case "9": p.OpenCrafting(); return false;
                case "10": p.ShowQuests(); return false;
                case "11": ActiveGuild?.ShowInfo(); return false;
                case "12": GlobalStats.Show(); return false;
                case "13": ShowDetailedStats(p); return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Opción inválida."); Console.ResetColor(); Console.ReadKey(true); return false;
            }
        }

        // Helper: wrap EnemyUnit list as Enemy proxy list for old-style Special methods
        // Since Special methods reference Enemy class, we use a simple adapter
        static List<Enemy> AdaptEnemies(List<EnemyUnit> units)
        {
            return units.Select(u => new Enemy(u.Name, u.Health, 10) { Health = u.Health }).ToList();
        }

        static EnemyUnit? ChooseTarget(List<EnemyUnit> enemies)
        {
            if (enemies.Count == 1) return enemies[0];
            Console.WriteLine("\n  Elige objetivo:");
            for (int i = 0; i < enemies.Count; i++)
            {
                ConsoleColor col = enemies[i] is MythicBoss ? ConsoleColor.Magenta : enemies[i] is BossEnemy ? ConsoleColor.DarkRed : enemies[i] is EliteEnemy ? ConsoleColor.DarkYellow : ConsoleColor.White;
                Console.ForegroundColor = col;
                Console.WriteLine($"  {i + 1}. {enemies[i].Name,-24} HP:{HealthBar(enemies[i].Health, enemies[i].MaxHealth, 10)} {enemies[i].Health}/{enemies[i].MaxHealth}");
                Console.ResetColor();
            }
            Console.Write("  → ");
            if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= enemies.Count) return enemies[idx - 1];
            return enemies[Rand.Next(enemies.Count)];
        }

        static void EnemyTurn(List<EnemyUnit> enemies)
        {
            var alive = Players.Where(p => p.IsAlive()).ToList();
            if (!alive.Any()) return;
            Console.Clear(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ─── Turno de los enemigos ───\n"); Console.ResetColor();
            foreach (var e in enemies)
            {
                e.TickStatus(); if (!e.IsAlive()) continue;
                if (e.HasStatus(StatusEffect.Stunned) || e.HasStatus(StatusEffect.Frozen)) { Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"  {e.Name} no puede actuar."); Console.ResetColor(); continue; }

                Player target = (e is BossEnemy && Rand.Next(100) < 50) ? alive.OrderByDescending(p => p.Mana).First()
                              : alive.OrderBy(p => (float)p.Health / p.MaxHealth).First();

                int dmg = Math.Max(1, e.AttackRoll() + WorldTime.GetWeatherEffects().def);
                target.TakeDamage(dmg, ElementType.Physical); GlobalStats.TotalDamageReceived += dmg;
                Console.ForegroundColor = ConsoleColor.DarkRed; Console.WriteLine($"  {e.Name} ataca a {target.Name}: {dmg} daño."); Console.ResetColor();

                if (e is EliteEnemy && Rand.Next(100) < 30)
                {
                    var bad = new[] { StatusEffect.Poisoned, StatusEffect.Burned, StatusEffect.Bleeding, StatusEffect.Weakened };
                    var eff = bad[Rand.Next(bad.Length)]; target.ApplyStatus(eff, 2);
                    Console.ForegroundColor = ConsoleColor.DarkYellow; Console.WriteLine($"  ⚠ {target.Name} sufre {eff}."); Console.ResetColor();
                }
                if (e is BossEnemy boss && Rand.Next(100) < 30) boss.UseSpecialAttack(target);
            }
            Console.ReadKey(true);
        }

        static void VictoryScreen(List<EnemyUnit> killedEnemies)
        {
            Console.Clear(); PrintBox("✔ VICTORIA", ConsoleColor.Green);

            bool isBoss = killedEnemies.Any(e => e is BossEnemy);
            bool isMythic = killedEnemies.Any(e => e is MythicBoss);

            int goldEarned = Rand.Next(15, 45) + round * 3;
            int xpEarned = 25 + round * 5;
            if (isMythic) { goldEarned *= 3; xpEarned *= 3; GlobalStats.TotalBossesKilled++; }
            else if (isBoss) { goldEarned *= 2; xpEarned *= 2; GlobalStats.TotalBossesKilled++; }
            if (WorldTime.CurrentWeather == WeatherType.Blessed) goldEarned = (int)(goldEarned * 1.25f);
            if (ActiveGuild != null) { int gb = (int)(goldEarned * ActiveGuild.BonusGoldPercent / 100f); goldEarned += gb; ActiveGuild.AddGold(gb); ActiveGuild.AddExperience(20 + round); }
            GlobalStats.TotalGoldEarned += goldEarned;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  Oro ganado: {goldEarned}🪙  |  XP: {xpEarned}");
            if (isMythic) Console.WriteLine("  ☠ ¡Victoria Mítica! x3 recompensas!");
            else if (isBoss) Console.WriteLine("  ⭐ Bonus de Jefe x2!");
            Console.ResetColor();

            foreach (var p in Players.Where(p => p.IsAlive()))
            {
                p.Gold += goldEarned; p.GainXP(xpEarned); p.RoundsWon++;
                int dropChance = 25 + round * 2;
                if (Rand.Next(100) < Math.Min(dropChance, 75))
                {
                    var drop = ItemDatabase.GetRandomDrop(round);
                    if (p.Inventory.Count < GameConfig.MAX_INVENTORY) { p.Inventory.Add(drop); Console.ForegroundColor = drop.GetRarityColor(); Console.WriteLine($"  🎁 {p.Name}: {drop.GetRarityStars()} [{drop.Rarity}] {drop.Name}!"); Console.ResetColor(); }
                }
                if (round % 3 == 0) { p.Talents.AvailablePoints++; Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine($"  ✨ {p.Name} +1 Punto de Talento"); Console.ResetColor(); }
                // Subir nivel de mascota
                if (p.Pet != null && Rand.Next(100) < 30) p.Pet.LevelUp();
            }

            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("\n  Pulsa tecla para continuar..."); Console.ResetColor(); Console.ReadKey(true);
        }

        static void ShowGameOver()
        {
            Console.Clear(); Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
   ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗
  ██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
  ██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
  ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
  ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n  Piso alcanzado:       {round}");
            Console.WriteLine($"  Enemigos eliminados:  {GlobalStats.TotalEnemiesKilled}");
            Console.WriteLine($"  Jefes derrotados:     {GlobalStats.TotalBossesKilled}");
            Console.WriteLine($"  Oro total ganado:     {GlobalStats.TotalGoldEarned}🪙");
            Console.WriteLine($"  Daño total infligido: {GlobalStats.TotalDamageDealt:N0}");
            Console.WriteLine($"  Mayor golpe:          {GlobalStats.HighestDamageInOneTurn} ({GlobalStats.HighestDamageDealer})");
            if (ActiveGuild != null) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  Gremio «{ActiveGuild.Name}»: Nivel {ActiveGuild.Level} ({ActiveGuild.Rank})"); Console.ResetColor(); }
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("\n  Pulsa una tecla para salir..."); Console.ResetColor(); Console.ReadKey(true);
        }

        // ─────────────────────────────────────────────────────
        // UI HELPERS
        // ─────────────────────────────────────────────────────
        public static void StaticShop(Player p)
        {
            bool inShop = true;
            while (inShop)
            {
                Console.Clear(); PrintBox($"🏪 TIENDA  (Oro: {p.Gold}🪙)", ConsoleColor.Yellow);
                var items = ShopDatabase.GetShopItems(round);
                Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine($"  Piso: {round}  |  Inventario: {p.Inventory.Count}/{GameConfig.MAX_INVENTORY}"); Console.ResetColor(); Console.WriteLine();
                for (int i = 0; i < items.Count; i++)
                {
                    ConsoleColor col = items[i].Price > p.Gold ? ConsoleColor.DarkGray : items[i].GetRarityColor();
                    Console.ForegroundColor = col;
                    Console.WriteLine($"  {i + 1,2}. {items[i].GetRarityStars()} [{items[i].Rarity,-10}] {items[i].Name,-28} {items[i].Price,5}🪙  — {items[i].Description}");
                    Console.ResetColor();
                }
                Console.WriteLine($"\n  0. Salir  |  R. Refrescar ({GameConfig.SHOP_REFRESH_COST}🪙)");
                Console.Write("\n  Opción: ");
                string op = Console.ReadLine() ?? "";
                if (op == "0") { inShop = false; }
                else if (op.ToUpper() == "R")
                {
                    if (p.Gold >= GameConfig.SHOP_REFRESH_COST) { p.Gold -= GameConfig.SHOP_REFRESH_COST; GlobalStats.TotalGoldSpent += GameConfig.SHOP_REFRESH_COST; Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("  ✔ Tienda refrescada."); Console.ResetColor(); Console.ReadKey(true); }
                    else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ✘ Oro insuficiente."); Console.ResetColor(); Console.ReadKey(true); }
                }
                else if (int.TryParse(op, out int idx) && idx >= 1 && idx <= items.Count)
                {
                    var chosen = items[idx - 1];
                    if (p.Gold >= chosen.Price) { if (p.Inventory.Count >= GameConfig.MAX_INVENTORY) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n  ✘ Inventario lleno."); Console.ResetColor(); Console.ReadKey(true); continue; } p.Gold -= chosen.Price; GlobalStats.TotalGoldSpent += chosen.Price; p.Inventory.Add(chosen); Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"\n  ✔ Compraste: [{chosen.Rarity}] {chosen.Name}"); Console.ResetColor(); Console.ReadKey(true); }
                    else { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("\n  ✘ Oro insuficiente."); Console.ResetColor(); Console.ReadKey(true); }
                }
            }
        }

        static void ShowStatus(List<EnemyUnit> enemies)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ══ PISO {round} ══  {WorldTime.GetWeatherIcon()} {WorldTime.CurrentWeather}  {WorldTime.TimeOfDay}\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("  ── JUGADORES ──"); Console.ResetColor();
            foreach (var p in Players)
            {
                string hpBar = HealthBar(p.Health, p.MaxHealth, 12);
                string mpBar = ManaBar(p.Mana, 200, 8);
                string st = p.HasAnyStatus() ? $" [{p.GetStatusString()}]" : "";
                string pet = p.Pet != null ? $" {p.Pet.Icon}" : "";
                // Sprite del jugador en línea
                var sprite = Sprites.GetClassSprite(p.ClassName);
                Console.ForegroundColor = p.IsAlive() ? ConsoleColor.White : ConsoleColor.DarkGray;
                Console.WriteLine($"  {sprite[0]} {p.Name,-14} HP:{hpBar}{p.Health,3}/{p.MaxHealth} MP:{mpBar} Lv:{p.Level} 🪙{p.Gold}{pet}{st}{(p.IsAlive() ? "" : " 💀")}");
                Console.ResetColor();
            }
            Console.WriteLine(); Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("  ── ENEMIGOS ──"); Console.ResetColor();
            foreach (var e in enemies)
            {
                string hpBar = HealthBar(e.Health, e.MaxHealth, 10);
                ConsoleColor col = e is MythicBoss ? ConsoleColor.Magenta : e is LegendaryBoss ? ConsoleColor.DarkMagenta : e is BossEnemy ? ConsoleColor.DarkRed : e is EliteEnemy ? ConsoleColor.DarkYellow : ConsoleColor.White;
                var sprite = Sprites.Enemy[e.SpriteKey];
                Console.ForegroundColor = col;
                Console.WriteLine($"  {sprite[0]} {e.Name,-24} HP:{hpBar}{e.Health,3}/{e.MaxHealth}");
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        static void ShowPlayerMenu(Player p)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  ─── Turno de {p.Name} ({p.ClassName}) Lv.{p.Level} ───");
            Console.ResetColor();
            Console.WriteLine($"  1. ⚔  Atacar  [{p.AttackElement}]");
            Console.WriteLine($"  2. ✨ {p.SpecialName} (Coste:{p.SpecialCost}MP)");
            Console.WriteLine($"  3. 🛡 Defender");
            Console.WriteLine($"  4. 🎒 Inventario ({p.Inventory.Count}/{GameConfig.MAX_INVENTORY})");
            Console.WriteLine($"  5. 🏪 Tienda (uso libre)");
            Console.WriteLine($"  6. 💡 Habilidad Extra");
            Console.WriteLine($"  7. 💫 {p.Special2Name} (Coste:{p.SpecialCost2}MP)");
            Console.WriteLine($"  8. 🌟 Talentos (Puntos:{p.Talents.AvailablePoints})");
            Console.WriteLine($"  9. ⚗  Crafteo");
            Console.WriteLine($"  10. 📜 Misiones");
            Console.WriteLine($"  11. 🏰 Gremio");
            Console.WriteLine($"  12. 📊 Estadísticas");
            Console.WriteLine($"  13. 📋 Mi Personaje");
            Console.Write("\n  Acción: ");
        }

        static void ShowDetailedStats(Player p)
        {
            Console.Clear(); PrintBox($"📋 {p.Name.ToUpper()} — {p.ClassName}", ConsoleColor.Cyan);
            // Mostrar sprite de la clase centrado
            Console.WriteLine();
            Sprites.Print(Sprites.GetClassSprite(p.ClassName), ConsoleColor.Cyan);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n  Nivel: {p.Level}  XP:{p.XP}/{p.Level * 50}  HP:{p.Health}/{p.MaxHealth}  MP:{p.Mana}/200");
            Console.WriteLine($"  ATK:{p.BaseAttack + p.AttackBonus} (Base:{p.BaseAttack}+Bonus:{p.AttackBonus})  DEF:{p.Defense}  VEL:{p.Speed}  CRIT:{p.CritChance}%");
            Console.WriteLine($"  Elemento: {p.AttackElement}  Oro: {p.Gold}🪙  Muertes: {p.TotalKills}  Pisos: {p.RoundsWon}");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n  Arma:      {(p.EquippedWeapon != null ? $"[{p.EquippedWeapon.Rarity}] {p.EquippedWeapon.Name}" : "(ninguna)")}");
            Console.WriteLine($"  Armadura:  {(p.EquippedArmor != null ? $"[{p.EquippedArmor.Rarity}] {p.EquippedArmor.Name}" : "(ninguna)")}");
            Console.WriteLine($"  Accesorio: {(p.EquippedAccessory != null ? $"[{p.EquippedAccessory.Rarity}] {p.EquippedAccessory.Name}" : "(ninguno)")}");
            if (p.Pet != null) { Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine($"\n  Compañero: {p.Pet.Icon} {p.Pet.Name} Nv.{p.Pet.Level}"); }
            Console.ForegroundColor = ConsoleColor.DarkCyan; Console.WriteLine($"\n  Talentos:");
            var ul = p.Talents.GetUnlockedTalents();
            if (!ul.Any()) Console.WriteLine("  (Ninguno)"); else foreach (var t in ul) Console.WriteLine($"  ✔ {t}");
            Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("\n  Pulsa tecla..."); Console.ResetColor(); Console.ReadKey(true);
        }

        static string HealthBar(int cur, int max, int w)
        {
            if (max <= 0) return new string('░', w);
            int f = Math.Clamp((int)((float)cur / max * w), 0, w); float pct = (float)cur / max;
            Console.ForegroundColor = pct > .6f ? ConsoleColor.Green : pct > .3f ? ConsoleColor.Yellow : ConsoleColor.Red;
            string bar = new string('█', f) + new string('░', w - f); Console.ResetColor(); return bar;
        }

        static string ManaBar(int cur, int max, int w)
        {
            int f = Math.Clamp((int)((float)cur / max * w), 0, w);
            Console.ForegroundColor = ConsoleColor.Blue; string bar = new string('█', f) + new string('░', w - f); Console.ResetColor(); return bar;
        }

        public static void PrintBox(string title, ConsoleColor color)
        {
            int len = Math.Max(title.Length, title.Sum(c => c > 127 ? 2 : 1));
            string line = new('═', len + 4);
            Console.ForegroundColor = color;
            Console.WriteLine($"  ╔{line}╗"); Console.WriteLine($"  ║  {title}  ║"); Console.WriteLine($"  ╚{line}╝");
            Console.ResetColor();
        }
    }

    // ── Parche para que Quest acepte el field StartedRound ───
    public static class QuestExt
    {
        // startedRound ya está en la clase Quest como prop
    }
}

// Parche: añadir StartedRound a Quest
namespace RPG_FINAL
{
    partial class QuestPatch { }
}
