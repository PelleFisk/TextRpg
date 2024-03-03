using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TextRpg
{
    class Encounter
    {
        public static Random rand = new Random();
        public static string? name;

        public static void GetRandEncounter()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and there you see a hulking beast...");
            Console.ReadKey();
            Combat(true);
        }

        public static void Combat(bool random)
        {
            string n = "";
            int h = 0;
            int d = 0;
            if (random)
            {
                n = getNames();
                d = Program.currentPlayer.GetDmg();
                h = Program.currentPlayer.GetHp();
            }

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(d + "/" + h);
                Console.WriteLine("=====================");
                Console.WriteLine("| (A)ttack (D)efend |");
                Console.WriteLine("| (R)un    (H)eal   |");
                Console.WriteLine("=====================");
                Console.WriteLine("  Potions:  " + Program.currentPlayer.potions + "  Health:  " + Program.currentPlayer.hp);
                string? input = Console.ReadLine()!;

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    int attack = rand.Next(Program.currentPlayer.minDmg, Program.currentPlayer.maxDmg);
                    int damage = d - Program.currentPlayer.armour;
                    if (damage < 0 )
                    {
                        damage = 0;
                    }
                    Console.WriteLine("You prepare to strike with a force of a thousand gods. But when you strike you also take damage from " + n + " and you lose " + damage + ". But you dealt " + attack + " damage");
                    Program.currentPlayer.hp -= damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    int attack = rand.Next(Program.currentPlayer.minDmg, Program.currentPlayer.maxDmg);
                    int damage = d - Program.currentPlayer.armour;
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    Console.WriteLine("You take your sword and block the attack. But the attempt was not succesfull so you still took " + damage + ". But in the end you also dealt " + attack + " damage!");
                    Program.currentPlayer.hp -= d;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint way from the " + n + ", it's strikes catches you in the back, sending you sprawling to the ground");
                        int damage = d - Program.currentPlayer.armour;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.hp -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n + " and you successfully escape!");
                        Console.ReadKey();
                        Shop.InitShop(Program.currentPlayer);
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    Console.WriteLine("You reach into your bag and pull out a glowing potion.");
                    Console.WriteLine("You drink from it and gain " + 5 + " health!");
                    
                    Program.currentPlayer.hp += 5;
                    if (Program.currentPlayer.hp > Program.currentPlayer.maxHp)
                        Program.currentPlayer.hp = Program.currentPlayer.maxHp;
                    Program.currentPlayer.potions -= 1;
                    Console.ReadKey();
                }

                if (Program.currentPlayer.hp <= 0)
                {
                    Console.WriteLine("You have been slain by " + n + "!!\n");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            int c = Program.currentPlayer.GetCoins();
            int xp = Program.currentPlayer.GetXp();
            Console.WriteLine("You have slain the mighty " + n + ". And now that the foul creature is dead you gained " + c + " coins as a reward!");
            Console.WriteLine("You also gained " + Program.currentPlayer.exp + " xp!!");
            Program.currentPlayer.exp += xp;
            Program.currentPlayer.money += c;
            if (Program.currentPlayer.CanLevelUp())
                Program.currentPlayer.LevelUp();
            Console.ReadKey();
        }

        public static string getNames()
        {
            int randNum = rand.Next(0, 4);
            switch (randNum)
            {
                case 0:
                    return "Goblin";
                case 1:
                    return "Skeleton";
                case 2:
                    return "Zombie";
                case 3:
                    return "Spider";
            }
            return "";
        }
    }
}
