using System.Text.Json;

namespace TextRpg
{
    class Program
    {
        public static Random rand = new Random();
        public static bool newPlayer = true;
        public static bool mainGamePlay = false;
        public static Player currentPlayer = new();
        public static Area area = new();
        public static Zones zone = new(0, "");
        public static Quest quest = new();
        public static List<Zones> zones = new();
        public static List<Weapon> currentWeapons = new();
        public static List<Spells> currentSpells = new();
        public static List<Boots> currentBoots = new();
        public static List<Gloves> currentGloves = new();
        public static List<Belt> currentBelts = new();
        public static List<Amulet> currentAmulets = new();
        public static List<Ring> currentRings = new();
        public static List<BodyArmour> currentArmours = new();
        public static List<Helmet> currentHelmets = new();
        public static Boots boots = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static Gloves gloves = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static Belt belt = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static Amulet amulet = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static Ring ring = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static BodyArmour armour = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static Helmet helmet = new("Test", "", 0, 0, 0, 0, 0, true, false);
        public static Weapon weapon = new(0, "", 0, "", 0, false, 0, false);
        public static Factions factions = new();
        private const string FilePath = "saves";
        private const string WeaponFilePath = "Weapon-Saves";
        private const string AreaFilePath = "Area-Saves";
        private const string ZoneFilePath = "Zone-Saves";
        private const string FactionsFilePath = "Faction-Saves";
        private const string QuestFilePath = "Quest-Saves";
        private const string SpellsFilePath = "Spell-Saves";
        private const string ArmourFilePath = "Armour-Saves";

        static void Main()
        {
            if (!Directory.Exists(FilePath)
                && !Directory.Exists(WeaponFilePath)
                && !Directory.Exists(AreaFilePath)
                && !Directory.Exists(ZoneFilePath)
                && !Directory.Exists(QuestFilePath)
                && !Directory.Exists(FactionsFilePath)
                && !Directory.Exists(SpellsFilePath)
                && !Directory.Exists(ArmourFilePath))
            {
                Directory.CreateDirectory(FilePath);
                Directory.CreateDirectory(WeaponFilePath);
                Directory.CreateDirectory(AreaFilePath);
                Directory.CreateDirectory(ZoneFilePath);
                Directory.CreateDirectory(QuestFilePath);
                Directory.CreateDirectory(FactionsFilePath);
                Directory.CreateDirectory(SpellsFilePath);
                Directory.CreateDirectory(ArmourFilePath);
            }

            currentPlayer = LoadPlayer();
            currentWeapons = LoadWeapons(currentPlayer.name!);
            area = LoadArea(currentPlayer.name!);
            zones = LoadZones(currentPlayer.name!);
            quest = LoadQuest(currentPlayer.name!);
            factions = LoadFaction(currentPlayer.name!);
            currentSpells = LoadSpell(currentPlayer.name!);
            LoadArmour(currentPlayer.name!);
            LoadArmourPieces();
            LoadCurrentWeapon();

            if (area.currentArea != null)
            {
                Area.JoinArea(area.currentArea);
            }
            else
            {
                mainGamePlay = true;
            }

            mainGamePlay = true;

            while (mainGamePlay)
            {
                Encounter.GetRandEncounter();
            }
        }

        public static Player StartNewPlayer()
        {
            while (newPlayer)
            {
                string? name;
                Console.WriteLine("Enter your name: ");
                name = Console.ReadLine();
                currentPlayer.Init();
                currentPlayer.name = name!;
                Console.WriteLine("What class do you want to join?(Mage, Warrior, Ranger)");

                string input;
                input = Console.ReadLine()!.ToLower();
                if (input == "mage")
                {
                    currentPlayer.currentClass = Player.Classes.Mage;
                }
                else if (input == "ranger")
                {
                    currentPlayer.currentClass = Player.Classes.Ranger;
                }
                else
                {
                    currentPlayer.currentClass = Player.Classes.Warrior;
                }

                SavePlayer();
                SaveWeapons();
                SaveArea();
                SaveZone();
                SaveQuest();
                SaveFaction();
                SaveSpell();
                SaveArmour();
                newPlayer = false;
                mainGamePlay = true;
            }

            return currentPlayer;
        }

        public static void SavePlayer()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "saves/" + fileName;
            string json = JsonSerializer.Serialize(currentPlayer, options);
            File.WriteAllText(path, json);
        }

        public static void SaveWeapons()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "Weapon-Saves/" + fileName;
            string json = JsonSerializer.Serialize(currentWeapons, options);
            File.WriteAllText(path, json);
        }

        public static void SaveArea()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "Area-Saves/" + fileName;
            string json = JsonSerializer.Serialize(area, options);
            File.WriteAllText(path, json);
        }

        public static void SaveZone()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "Zone-Saves/" + fileName;
            string json = JsonSerializer.Serialize(zones, options);
            File.WriteAllText(path, json);
        }

        public static void SaveQuest()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "Quest-Saves/" + fileName;
            string json = JsonSerializer.Serialize(quest, options);
            File.WriteAllText(path, json);
        }

        public static void SaveArmour()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string bodyArmourFileName = GetFileName("body armour");
            string bootsFileName = GetFileName("boots");
            string beltFileName = GetFileName("belt");
            string glovesFileName = GetFileName("gloves");
            string amuletFileName = GetFileName("amulet");
            string ringFileName = GetFileName("ring");
            string helmetFileName = GetFileName("helmet");
            string bootPath = ArmourFilePath + "/" + bootsFileName;
            string bootJson = JsonSerializer.Serialize(currentBoots, options);
            string beltPath = ArmourFilePath + "/" + beltFileName;
            string beltJson = JsonSerializer.Serialize(currentBelts, options);
            string glovesPath = ArmourFilePath + "/" + glovesFileName;
            string gloveJson = JsonSerializer.Serialize(currentGloves, options);
            string amuletPath = ArmourFilePath + "/" + amuletFileName;
            string amuletJson = JsonSerializer.Serialize(currentAmulets, options);
            string ringPath = ArmourFilePath + "/" + ringFileName;
            string ringJson = JsonSerializer.Serialize(currentRings, options);
            string armourPath = ArmourFilePath + "/" + bodyArmourFileName;
            string armourJson = JsonSerializer.Serialize(currentArmours, options);
            string helmetPath = ArmourFilePath + "/" + helmetFileName;
            string helmetJson = JsonSerializer.Serialize(currentHelmets, options);
            File.WriteAllText(bootPath, bootJson);
            File.WriteAllText(beltPath, beltJson);
            File.WriteAllText(glovesPath, gloveJson);
            File.WriteAllText(amuletPath, amuletJson);
            File.WriteAllText(ringPath, ringJson);
            File.WriteAllText(armourPath, armourJson);
            File.WriteAllText(helmetPath, helmetJson);
        }

        public static void SaveFaction()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "Faction-Saves/" + fileName;
            string json = JsonSerializer.Serialize(factions, options);
            File.WriteAllText(path, json);
        }

        public static void SaveSpell()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string fileName = currentPlayer.name + ".json";
            string path = "Spell-Saves/" + fileName;
            string json = JsonSerializer.Serialize(currentSpells, options);
            File.WriteAllText(path, json);
        }

        public static Player LoadPlayer()
        {
            string[] paths = Directory.GetFiles("saves");
            List<Player> players = new List<Player>();
            foreach (var p in paths)
            {
                string loadedJson = File.ReadAllText(p);
                Player player = JsonSerializer.Deserialize<Player>(loadedJson)!;
                players.Add(player);
            }

            while (true)
            {
                foreach (var p in players)
                {
                    Console.WriteLine(p.name);
                }

                Console.WriteLine("Please enter the name of the character you want to play as: ");
                Console.WriteLine("Other wise you can start a new character with 'create'");
                string? input;
                input = Console.ReadLine();

                if (input == "create")
                {
                    Player newPlayer = StartNewPlayer();
                    return newPlayer;
                }
                else
                {
                    foreach (var p in players)
                    {
                        if (p.name == input)
                        {
                            return p;
                        }
                    }
                }

                Console.WriteLine("There is no player with that name!!");
                Console.ReadKey();
            }
        }

        public static List<Weapon> LoadWeapons(string name)
        {
            string path = @"Weapon-Saves\" + name + ".json";
            string loadedJson = File.ReadAllText(path);
            List<Weapon> weapons = JsonSerializer.Deserialize<List<Weapon>>(loadedJson)!;
            return weapons;
        }

        public static void LoadCurrentWeapon()
        {
            weapon = currentWeapons.Find(w => w.currentWeapon)!;
        }

        public static Area LoadArea(string name)
        {
            string path = @"Area-Saves\" + name + ".json";
            string loadedJson = File.ReadAllText(path);
            Area area = JsonSerializer.Deserialize<Area>(loadedJson)!;
            return area;
        }

        public static List<Zones> LoadZones(string name)
        {
            string path = @"Zone-Saves\" + name + ".json";
            string loadedJson = File.ReadAllText(path);
            List<Zones> zones = JsonSerializer.Deserialize<List<Zones>>(loadedJson)!;
            return zones;
        }

        public static Quest LoadQuest(string name)
        {
            string path = @"Quest-Saves\" + name + ".json";
            string loadedJson = File.ReadAllText(path);
            Quest quest = JsonSerializer.Deserialize<Quest>(loadedJson)!;
            return quest;
        }

        public static void LoadArmour(string name)
        {
            string bootPath = GetLoadFileName(name, "boots");
            string bootLoadedJson = File.ReadAllText(bootPath);
            currentBoots = JsonSerializer.Deserialize<List<Boots>>(bootLoadedJson)!;
            string helmetPath = GetLoadFileName(name, "helmet");
            string helmetLoadedJson = File.ReadAllText(helmetPath);
            currentHelmets = JsonSerializer.Deserialize<List<Helmet>>(helmetLoadedJson)!;
            string armourPath = GetLoadFileName(name, "body armour");
            string armourLoadedJson = File.ReadAllText(armourPath);
            currentArmours = JsonSerializer.Deserialize<List<BodyArmour>>(armourLoadedJson)!;
            string beltPath = GetLoadFileName(name, "belt");
            string beltLoadedJson = File.ReadAllText(beltPath);
            currentBelts = JsonSerializer.Deserialize<List<Belt>>(beltLoadedJson)!;
            string amuletPath = GetLoadFileName(name, "amulet");
            string amuletLoadedJson = File.ReadAllText(amuletPath);
            currentAmulets = JsonSerializer.Deserialize<List<Amulet>>(amuletLoadedJson)!;
            string glovesPath = GetLoadFileName(name, "gloves");
            string glovesLoadedJson = File.ReadAllText(glovesPath);
            currentGloves = JsonSerializer.Deserialize<List<Gloves>>(glovesLoadedJson)!;
            string ringPath = GetLoadFileName(name, "ring");
            string ringLoadedJson = File.ReadAllText(ringPath);
            currentRings = JsonSerializer.Deserialize<List<Ring>>(ringLoadedJson)!;
        }

        public static Factions LoadFaction(string name)
        {
            string path = @"Faction-Saves\" + name + ".json";
            string loadedJson = File.ReadAllText(path);
            Factions faction = JsonSerializer.Deserialize<Factions>(loadedJson)!;
            return faction;
        }

        public static List<Spells> LoadSpell(string name)
        {
            string path = @"Spell-Saves\" + name + ".json";
            string loadedJson = File.ReadAllText(path);
            List<Spells> spells = JsonSerializer.Deserialize<List<Spells>>(loadedJson)!;
            return spells;
        }

        public static void LoadArmourPieces()
        {
            boots = currentBoots.Find(b => b.currentBoot)!;
            gloves = currentGloves.Find(g => g.currentGlove)!;
            belt = currentBelts.Find(b => b.currentBelt)!;
            amulet = currentAmulets.Find(a => a.currentAmulet)!;
            ring = currentRings.Find(r => r.currentRing)!;
            armour = currentArmours.Find(a => a.currentBodyArmour)!;
            helmet = currentHelmets.Find(h => h.currentHelmet)!;
        }

        public static string GetFileName(string? armourType)
        {
            switch (armourType)
            {
                case "boots":
                    return $"{currentPlayer.name}-Boots.json";
                case "helmet":
                    return $"{currentPlayer.name}-Helmet.json";
                case "amulet":
                    return $"{currentPlayer.name}-Amulet.json";
                case "ring":
                    return $"{currentPlayer.name}-Ring.json";
                case "gloves":
                    return $"{currentPlayer.name}-Gloves.json";
                case "body armour":
                    return $"{currentPlayer.name}-BodyAmour.json";
                case "belt":
                    return $"{currentPlayer.name}-Belt.json";
            }

            return "";
        }

        public static string GetLoadFileName(string name, string armourType)
        {
            switch (armourType)
            {
                case "boots":
                    return $@"Armour-Saves\{name}-Boots.json";
                case "helmet":
                    return $@"Armour-Saves\{name}-Helmet.json";
                case "amulet":
                    return $@"Armour-Saves\{name}-Amulet.json";
                case "ring":
                    return $@"Armour-Saves\{name}-Ring.json";
                case "gloves":
                    return $@"Armour-Saves\{name}-Gloves.json";
                case "body armour":
                    return $@"Armour-Saves\{name}-BodyAmour.json";
                case "belt":
                    return $@"Armour-Saves\{name}-Belt.json";
            }

            return "";
        }

        public static void ResetPlayer()
        {
            currentPlayer.hp = currentPlayer.maxHp;
            SavePlayer();
            SaveWeapons();
            SaveQuest();
            SaveArea();
            SaveZone();
            SaveArmour();
        }

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }

        public static void Print(string text, int speed = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }

            Console.WriteLine();
        }
    }
}