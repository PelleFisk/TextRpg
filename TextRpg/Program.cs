using System.Text.Json;

namespace TextRpg
{
    class Program
    {
        public static Random rand = new Random();
        public static bool newPlayer = true;
        public static bool mainGamePlay = false;
        public static Player currentPlayer = new Player();
        public static Area area = new Area();
        public static Zones zone = new Zones(0, "");
        public static Quest quest = new Quest();
        public static List<Zones> zones = new List<Zones>();
        public static List<Weapon> currentWeapons = new List<Weapon>();
        public static string filePath = "saves";
        public static string weaponFilePath = "Weapon-Saves";
        public static string areaFilePath = "Area-Saves";
        public static string zoneFilePath = "Zone-Saves";
        public static string questFilePath = "Quest-Saves";

        static void Main()
        {
            if (!Directory.Exists(filePath) && !Directory.Exists(weaponFilePath) && !Directory.Exists(areaFilePath) && !Directory.Exists(zoneFilePath) && !Directory.Exists(questFilePath))
            {
                Directory.CreateDirectory(filePath);
                Directory.CreateDirectory(weaponFilePath);
                Directory.CreateDirectory(areaFilePath);
                Directory.CreateDirectory(zoneFilePath);
                Directory.CreateDirectory(questFilePath);
            }
            
            currentPlayer = LoadPlayer();
            currentWeapons = LoadWeapons(currentPlayer.name!);
            area = LoadArea(currentPlayer.name!);
            zones = LoadZones(currentPlayer.name!);
            quest = LoadQuest(currentPlayer.name!);

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
                currentPlayer.init();
                currentPlayer.name = name!;
                SavePlayer();
                SaveWeapons();
                SaveArea();
                SaveZone();
                SaveQuest();
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
            string[] paths = Directory.GetFiles("Weapon-Saves");
            string path = @"Weapon-Saves\" + name + ".json";

            foreach (var p in paths)
            {
                if (p == path)
                {
                    string loadedJson = File.ReadAllText(path);
                    List<Weapon> weapons = JsonSerializer.Deserialize<List<Weapon>>(loadedJson)!;
                    return weapons;
                }
            }
            return new List<Weapon>();
        }

        public static Area LoadArea(string name)
        {
            string[] paths = Directory.GetFiles("Area-Saves");
            string path = @"Area-Saves\" + name + ".json";

            foreach (var p in paths)
            {
                if (p == path)
                {
                    string loadedJson = File.ReadAllText(path);
                    Area area = JsonSerializer.Deserialize<Area>(loadedJson)!;
                    return area;
                }
            }
            return new Area();
        }

        public static List<Zones> LoadZones(string name)
        {
            string[] paths = Directory.GetFiles("Zone-Saves");
            string path = @"Zone-Saves\" + name + ".json";


            foreach (var p in paths)
            {
                if (p == path)
                {
                    string loadedJson = File.ReadAllText(path);
                    List<Zones> zones = JsonSerializer.Deserialize<List<Zones>>(loadedJson)!;
                    return zones;
                }
            }
            return new List<Zones>();
        }

        public static Quest LoadQuest(string name)
        {
            string[] paths = Directory.GetFiles("Quest-Saves");
            string path = @"Quest-Saves\" + name + ".json";


            foreach (var p in paths)
            {
                if (p == path)
                {
                    string loadedJson = File.ReadAllText(path);
                    Quest quest = JsonSerializer.Deserialize<Quest>(loadedJson)!;
                    return quest;
                }
            }
            return new Quest();
        }

        public static void ResetPlayer()
        {
            currentPlayer.hp = currentPlayer.maxHp;
            SavePlayer();
            SaveWeapons();
            SaveQuest();
            SaveArea();
            SaveZone();
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
    }
}