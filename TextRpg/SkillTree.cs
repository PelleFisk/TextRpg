using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class SkillTree
    {
        public static void SkillTrees()
        {
            Console.WriteLine("Welcome to the skilltree");
            Console.WriteLine("Your skillpoints: " + Program.currentPlayer.skillPoints);
            Console.WriteLine("You can upgrade both your max health and damage");
            Console.WriteLine("Write 'hp' for hp upgrade and 'dmg' for damage upgrade");
            string? input;
            input = Console.ReadLine()!.ToLower();

            if (input == "hp")
            {
                UpgradeHp();
            }
        }

        public static void UpgradeHp()
        {
            if (Program.currentPlayer.skillPoints >= 1)
            {
                Program.currentPlayer.maxHp += 5;
                Program.currentPlayer.skillPoints--;
                Console.WriteLine("Upgrade max hp to " + Program.currentPlayer.maxHp);
            }
            else
            {
                Console.WriteLine("You dont have enoguh skill points");
            }
        }

        public static void UpgradeDmg()
        {
            if (Program.currentPlayer.skillPoints >= 1)
            {
                Program.currentPlayer.minDmg += 2;
                Program.currentPlayer.maxDmg += 2;
                Program.currentPlayer.skillPoints--;
                Console.WriteLine("Your max damage is now: " + Program.currentPlayer.maxDmg + ".");
                Console.WriteLine("Your min damage is now: " + Program.currentPlayer.minDmg + ".");
            }
            else
            {
                Console.WriteLine("You dont have enoguh skill points");
            }
        }
    }
}
