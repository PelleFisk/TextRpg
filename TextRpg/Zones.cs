using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TextRpg
{
    [System.Serializable]
    class Zones
    {
        public string? currentZone { get; set; } = "";
        public int levelToEnter { get; set; } = 0;

        [JsonConstructor]
        public Zones(int levelToEnter, string currentZone)
        {
            this.currentZone = currentZone;
            this.levelToEnter = levelToEnter;
        }

        public int GetLevelForZone(string zoneToEnter)
        {
            switch (zoneToEnter)
            {
                case "Starter Zone":
                    levelToEnter = 0;
                    break;
                case "Dark Cave":
                    levelToEnter = 5;
                    break;
            }

            return levelToEnter;
        }

        public void JoinZone(string zoneToEnter)
        {
            int levelRequired = GetLevelForZone(zoneToEnter);
            if (levelRequired == Program.currentPlayer.level)
            {
                Program.zones.Add(new Zones(levelRequired, zoneToEnter));
                Console.WriteLine("Do you whish to enter the zone: " + zoneToEnter + "(y/n)");
                string input;
                input = Console.ReadLine()!;
                if (input == "y")
                {
                    currentZone = zoneToEnter;
                }
                else
                {
                    Console.WriteLine("You're still in the zone: " + currentZone);
                }
            }
            else if (levelRequired > Program.currentPlayer.level)
            {
                Console.WriteLine("You're not a high enough level!");
                Console.ReadKey();
            }
        }

        public string CheckForZone(int pLevel)
        {
            if (pLevel < 5)
            {
                return "Starter Zone";
            }
            else if (pLevel >= 5 && pLevel < 10)
            {
                return "Dark Cave";
            }

            return "Starter Zone";
        }

        public int DifZone(string zone)
        {
            int difZone = 0;
            switch (zone)
            {
                case "Starter Zone":
                    difZone = 1;
                    break;
                case "Dark Cave":
                    difZone = 2;
                    break;
            }
            return difZone;
        }
    }
}
