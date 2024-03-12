using TextRpg;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TextRpg
{
    [System.Serializable]
    class Weapon
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? rarity { get; set; }
        public int cost { get; set; }
        public int sellValue { get; set; }
        public int damage { get; set; }
        public bool specialItem { get; set; }

        [JsonConstructor]
        public Weapon(int id, string name, int sellValue, string rarity, int damage, bool specialItem)
        {
            this.name = name;
            this.id = id;
            this.rarity = rarity;
            this.sellValue = sellValue;
            this.damage = damage;
            this.specialItem = specialItem;
        }

        public static int GetCost(string? rarity)
        {
            int cost = 0;
            switch (rarity)
            {
                case "common":
                    cost = 100 * (1 + 3);
                    break;
                case "uncommon":
                    cost = 100 * (2 + 3);
                    break;
                case "rare":
                    cost = 100 * (3 + 3);
                    break;
                case "epic":
                    cost = 100 * (4 + 3);
                    break;
                case "legendary":
                    cost = 100 * (5 + 3);
                    break;
            }

            return cost;
        }

        public static int GetSellValue(string? rarity)
        {
            int sellValue = 0;
            sellValue = GetCost(rarity) / 2;
            return sellValue;
        }

        public static int GetDamage(string? rarity)
        {
            int damage = 0;
            switch (rarity)
            {
                case "common":
                    damage = 1 * (1 + 3);
                    break;
                case "uncommon":
                    damage = 1 * (2 + 3);
                    break;
                case "rare":
                    damage = 1 * (3 + 3);
                    break;
                case "epic":
                    damage = 1 * (4 + 3);
                    break;
                case "legendary":
                    damage = 1 * (5 + 3);
                    break;
            }

            return damage;
        }

        public static string GetShopRarity()
        {
            string? rarity = "";

            int randNum = Program.rand.Next(0, 101);
            if (randNum <= 40)
            {
                rarity = "common";
            }
            else if (randNum > 40 && randNum <= 60)
            {
                rarity = "uncommon";
            }
            else if (randNum > 60 && randNum <= 70)
            {
                rarity = "rare";
            }
            else if(randNum > 80 && randNum <= 90)
            {
                rarity = "epic";
            }
            else if (randNum > 90 && randNum <= 100)
            {
                rarity = "legendary";
            }

            return rarity;
        }

        public static string GetRarity()
        {
            string? rarity = "";

            int randNum = Program.rand.Next(0, 101);
            if (randNum <= 60)
            {
                rarity = "common";
            }
            else if (randNum > 60 && randNum <= 85)
            {
                rarity = "uncommon";
            }
            else if (randNum > 85 && randNum <= 95)
            {
                rarity = "rare";
            }
            else if (randNum > 95 && randNum <= 99)
            {
                rarity = "epic";
            }
            else if (randNum == 100)
            {
                rarity = "legendary";
            }

            return rarity;
        }

        public static string GetName()
        {
            string? name = "";

            int randNum = Program.rand.Next(0, 3);

            switch (Program.currentPlayer.currentZone)
            {
                case "Starter Zone":
                    switch (randNum)
                    {
                        case 0:
                            name = "Long Sword";
                            break;
                        case 1:
                            name = "Short Sword";
                            break;
                        case 2:
                            name = "Dagger";
                            break;
                    }
                    break;
                case "Dark Cave":
                    switch (randNum)
                    {
                        case 0:
                            name = "Dark Blade";
                            break;
                        case 1:
                            name = "Dark Cane";
                            break;
                        case 2:
                            name = "Dark Dagger";
                            break;
                    }
                    break;
            }

            return name;
        }
    }
}
