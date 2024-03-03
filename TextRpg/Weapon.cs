using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Weapon
    {
        public static string? name = "";
        public static string? rarity = "";
        public static int cost;
        public static int sellValue;

        public static int GetCost()
        {
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

        public static int GetSellValue()
        {
            sellValue = GetCost() / 2;
            return sellValue;
        }
    }
}
