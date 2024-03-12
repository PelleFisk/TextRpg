using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class Shop
    {
        public static void InitShop(Player p)
        {
            RunShop(p);
        }

        public static void RunShop(Player p)
        {
            int potionP;
            int armourP;
            int weaponP;
            int difP;

            while (true)
            {
                potionP = 20 + 10 * 2;
                armourP = 100 * (p.armour + 1);
                weaponP = 100 * p.minDmg;
                difP = 300 + 100 * p.mods;

                Console.Clear();

                Program.area.currentArea = "shop";
                Program.SaveArea();

                Console.WriteLine("        Shop        ");
                Console.WriteLine("====================");
                Console.WriteLine("(W)eapon :         $" + weaponP);
                Console.WriteLine("(A)rmor :          $" + armourP);
                Console.WriteLine("(P)otions :        $" + potionP);
                Console.WriteLine("(D)ifficulty       $" + difP);
                Console.WriteLine("====================");
                Console.WriteLine("(E)xit:   // Exits the Shop");
                Console.WriteLine("(Q)uit:   // Quits the Game and Saves");
                Console.WriteLine("(S)ave:  // Saves the game without quitting");
                Console.WriteLine("(Skill)tree:  // Goes to the skilltree");
                Console.WriteLine("(Shop) of weapons:   // Goes to the Weapon Shop");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(p.name + "'s  Stats  ");
                Console.WriteLine("====================");
                Console.WriteLine("Current Health: " + p.hp);
                Console.WriteLine("Max Health: " + p.maxHp);
                Console.WriteLine("Coins: " + p.money);
                Console.WriteLine("Min Dmg: " + p.minDmg);
                Console.WriteLine("Max Dmg: " + p.maxDmg);
                Console.WriteLine("Armour: " + p.armour);
                Console.WriteLine("Potions: " + p.potions);
                Console.WriteLine("Difficulty Mod: " + p.mods);
                Console.WriteLine("Skill Points: " + p.skillPoints);
                Console.WriteLine("Current Zone: " + p.currentZone);


                Console.WriteLine("Xp: ");
                Console.Write("[");
                Program.ProgressBar("+", " ", ((decimal)p.exp / (decimal)p.GetLevelValue()), 25);
                Console.WriteLine("]");

                Console.WriteLine("Level: " + p.level);
                Console.WriteLine("====================");

                string input = Console.ReadLine()!.ToLower();
                if (input == "w" || input == "weapon")
                {
                    TryBuy("weapon", weaponP, p);
                }
                else if (input == "a" || input == "armor")
                {
                    TryBuy("armour", armourP, p);
                }
                else if (input == "p" || input == "potion")
                {
                    TryBuy("potion", potionP, p);
                }
                else if (input == "d" || input == "difficulty")
                {
                    TryBuy("difficulty", difP, p);
                }
                else if (input == "s" || input == "save")
                {
                    Program.SavePlayer();
                    Program.SaveWeapons();
                    Program.SaveArea();
                    Program.SaveZone();
                    Program.SaveQuest();
                }
                else if (input == "skill" || input == "skilltree")
                {
                    SkillTree.SkillTrees();
                }
                else if (input == "q" || input == "quit")
                {
                    Program.SavePlayer();
                    Program.SaveWeapons();
                    Program.SaveArea();
                    Program.SaveZone();
                    Program.SaveQuest();
                    Environment.Exit(0);
                }
                else if (input == "shop")
                {
                    WeaponStore.RunWeaponShop(p);
                }
                else if (input == "e" || input == "exit")
                {
                    Program.area.currentArea = "";
                    Program.SaveArea();
                    break;
                }
            }
        }

        public static void TryBuy(string item, int cost, Player p)
        {
            if (p.money >= cost)
            {
                if (item == "potion")
                    p.potions++;
                else if (item == "armour")
                    p.armour++;
                else if (item == "difficulty")
                    p.mods++;
                else if (item == "weapon")
                {
                    p.minDmg++;
                    p.maxDmg++;
                }
                p.money -= cost;
            }
            else
            {
                Console.WriteLine("You dont have enough money");
                Console.ReadKey();
            }
        }
    }
}
