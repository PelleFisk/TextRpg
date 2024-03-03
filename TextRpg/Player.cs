using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;


namespace TextRpg
{
    [System.Serializable]
    class Player
    {
        public string? name { get; set; }
        public int strength { get; set; }
        public int hp { get; set; }
        public int maxHp { get; set; }
        public int armour { get; set; }
        public int minDmg { get; set; }
        public int maxDmg { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int money { get; set; }
        public int exp { get; set; }
        public int potions { get; set; }
        public int mods { get; set; }
        public int level { get; set; }
        public int skillPoints { get; set; }

        public void init()
        {
            name = "";
            strength = 5;
            hp = 10;
            maxHp = 10;
            armour = 1;
            minDmg = 2;
            maxDmg = 4;
            intelligence = 5;
            dexterity = 5;
            money = 0;
            exp = 0;
            potions = 5;
            mods = 1;
        }

        public int GetCoins()
        {
            int upper = (10 * mods + 50);
            int lower = (10 * mods + 10);
            return Program.rand.Next(lower, upper);
        }

        public int GetDmg()
        {
            int upper = (2 * mods + 2);
            int lower = (mods + 1);
            return Program.rand.Next(lower, upper);
        }
        public int GetHp()
        {
            int upper = (1 * mods + 5);
            int lower = (1 * mods + 3);
            return Program.rand.Next(lower, upper);
        }

        public int GetXp()
        {
            int upper = (20 * mods + 50);
            int lower = (10 * mods + 10);
            return Program.rand.Next(lower, upper);
        }

        public int GetLevelValue()
        {
            return 100 * level + 400;
        }

        public bool CanLevelUp()
        {
            if (exp >= GetLevelValue())
                return true;
            else
                return false;
        }

        public void LevelUp()
        {
            while (CanLevelUp())
            {
                exp -= GetLevelValue();
                skillPoints++;
                maxHp += 5;
                level++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congrats! You are now level " + level + "!!!");
            Console.ResetColor();
        }
    }
}
