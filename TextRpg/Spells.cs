namespace TextRpg
{
    [Serializable]
    class Spells(int id, string name, int damage, int cost, int intReq, string rarity)
    {
        public string? name { get; set; } = name;
        public int damage { get; set; } = damage;
        public int cost { get; set; } = cost;
        public int intReq { get; set; } = intReq;
        public string? rarity { get; set; } = rarity;
        public int id { get; set; } = id;

        public static int GetIntReq(string rarity)
        {
            int intReq = rarity switch
            {
                "common" => 1,
                "uncommon" => 5,
                "rare" => 7,
                "epic" => 10,
                "legendary" => 15,
                _ => 0
            };

            return intReq;
        }

        public static string GetShopRarity()
        {
            var rarity = "";
            int randNum = Program.rand.Next(0, 101);

            rarity = randNum switch
            {
                <= 40 => "common",
                <= 70 => "uncommon",
                <= 80 => "rare",
                <= 90 => "epic",
                <= 100 => "legendary",
                _ => rarity
            };

            return rarity;
        }

        public static int GetCost(string? rarity)
        {
            int cost = rarity switch
            {
                "common" => 100 * (1 + 3),
                "uncommon" => 100 * (2 + 3),
                "rare" => 100 * (3 + 3),
                "epic" => 100 * (4 + 3),
                "legendary" => 100 * (5 + 3),
                _ => 0
            };

            return cost;
        }

        public static int GetDamage(string? rarity)
        {
            int damage = rarity switch
            {
                "common" => 1 * (1 + 3) + ((Program.currentPlayer.currentClass == Player.Classes.Mage) ? 2 : 0),
                "uncommon" => 1 * (2 + 3) + ((Program.currentPlayer.currentClass == Player.Classes.Mage) ? 2 : 0),
                "rare" => 1 * (3 + 3) + ((Program.currentPlayer.currentClass == Player.Classes.Mage) ? 2 : 0),
                "epic" => 1 * (4 + 3) + ((Program.currentPlayer.currentClass == Player.Classes.Mage) ? 2 : 0),
                "legendary" => 1 * (5 + 3) + ((Program.currentPlayer.currentClass == Player.Classes.Mage) ? 2 : 0),
                _ => 0
            };

            return damage;
        }

        public static string GetName()
        {
            string name = "";

            int randNum = Program.rand.Next(0, 3);

            name = Program.currentPlayer.currentZone switch
            {
                "Starter Zone" => randNum switch
                {
                    0 => "Breeze Whisper",
                    1 => "Spark of Beginning",
                    2 => "Shield of Dawn",
                    _ => name
                },
                "Dark Cave" => randNum switch
                {
                    0 => "Echoes of the Abyss",
                    1 => "Banshee's Wail",
                    2 => "Gloom Orb",
                    _ => name
                },
                "Mysticglow Enclave" => randNum switch
                {
                    0 => "Mysticglow Beam",
                    1 => "Celestial Bindings",
                    2 => "Aurora Arcanum",
                    _ => name
                },
                "Ethereal Grove" => randNum switch
                {
                    0 => "Grove-keeper's Wrath",
                    1 => "Spectral Blossom",
                    2 => "Starlight Shield",
                    _ => name
                },
                _ => name
            };

            return name;
        }
    }
}