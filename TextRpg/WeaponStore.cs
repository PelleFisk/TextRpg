using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg
{
    class WeaponStore
    {
        public static void RunWeaponShop(Player p)
        {
            Program.area.currentArea = "weapon shop";
            Program.SaveArea();
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Welcome to the weapon store");
            Console.WriteLine("Here you can buy weapons for gold you have accumilated from your travels or sell your swords");
            Console.WriteLine("Would you like to sell your swords or buy a new sword?(S)ell/(B)uy/(E)xit");
            Console.WriteLine("===============");

            string? input;
            input = Console.ReadLine()!.ToLower();

            if (input == "s" || input == "sell")
            {
                SellWeapons(p);
            }
            else if (input == "b" || input == "buy")
            {
                BuyWeapons(p);
            }
            else if (input == "e" || input == "exit")
            {
                Shop.InitShop(p);
            }
        }

        public static void SellWeapons(Player p)
        {
            Console.WriteLine("Would you like to see your inventory?(y/n)");
            string? input;
            input = Console.ReadLine()!.ToLower();
            if (input == "y")
            {
                foreach (var weapon in Program.currentWeapons)
                {
                    Console.WriteLine("===============\n" 
                        + "Weapon Id: "
                        + weapon.id + "\n" + "Weapon Name: " 
                        + weapon.name + "\n" + "Weapon Sell Value: " 
                        + weapon.sellValue + "\n" + "Weapon Damage: " 
                        + weapon.damage + "\n" + "Weapon Rarity: " 
                        + weapon.rarity + "\n" + "===============\n");
                }

                Console.WriteLine("Please enter in the id of what sword you want to sell");
                int idOfSword;
                if (int.TryParse(Console.ReadLine(), out idOfSword))
                {
                    var weaponToSell = Program.currentWeapons.Find(w => w.id == idOfSword);
                    if (weaponToSell != null && !weaponToSell.specialItem)
                    {
                        Program.currentWeapons.Remove(weaponToSell);
                        p.money += weaponToSell.sellValue;
                    }
                    else
                    {
                        Console.WriteLine("Cannot sell the item as it is special");
                    }
                }
            }
        }

        public static void BuyWeapons(Player p)
        {
            string rarity1 = Weapon.GetShopRarity();
            string rarity2 = Weapon.GetShopRarity();
            string rarity3 = Weapon.GetShopRarity();
            string name1 = Weapon.GetName();
            string name2 = Weapon.GetName();
            string name3 = Weapon.GetName();
            int weapon1Cost = Weapon.GetCost(rarity1);
            int weapon2Cost = Weapon.GetCost(rarity2);
            int weapon3Cost = Weapon.GetCost(rarity3);

            Console.WriteLine("===============");
            Console.WriteLine("First Weapon Name: " + name1);
            Console.WriteLine("First Weapon Cost: " + weapon1Cost);
            Console.WriteLine("First Weapon Rarity: " + rarity1);
            Console.WriteLine("===============");
            Console.WriteLine("Second Weapon Name: " + name2);
            Console.WriteLine("Second Weapon Cost: " + weapon2Cost);
            Console.WriteLine("Second Weapon Rarity: " + rarity2);
            Console.WriteLine("===============");
            Console.WriteLine("Third Weapon Name: " + name3);
            Console.WriteLine("Third Weapon Cost: " + weapon3Cost);
            Console.WriteLine("Third Weapon Rarity: " + rarity3);
            Console.WriteLine("===============");

            Console.WriteLine("What weapon would you like to buy?(one/second/third)");
            string? input = "";
            input = Console.ReadLine();
            if (input == "one")
            {
                BuyWeapon(name1, rarity1, weapon1Cost, p);
            }
            else if (input == "second")
            {
                BuyWeapon(name2, rarity2, weapon2Cost, p);
            }
            else if (input == "third")
            {
                BuyWeapon(name3, rarity3, weapon3Cost, p);
            }
        }

        public static void BuyWeapon(string? name, string? rarity, int cost, Player p)
        {
            if (p.money >= cost)
            {
                int weaponId = 0;
                int damage = Weapon.GetDamage(rarity);
                int sellValue = Weapon.GetDamage(rarity);
                Console.WriteLine("Do you whish to store the weapon in your inventory or equip it(S(tore)/(E)quip)");
                string? input;
                input = Console.ReadLine()!.ToLower();
                if (input == "s" || input == "store")
                {
                    Program.currentWeapons.Add(new Weapon(weaponId, name!, sellValue, rarity!, damage, false));
                    p.money -= cost;
                }
                else if (input == "e" || input == "equip")
                {
                    p.currentWeaponName = name;
                    p.weaponDamage = Weapon.GetDamage(rarity);
                    p.weaponSellValue = Weapon.GetSellValue(rarity);
                    p.money -= cost;
                }

                Console.WriteLine("You have now bought the sword: " + name + "!!");
            }
            else
            {
                Console.WriteLine("You dont have enough money!");
                Console.ReadKey();
            }
        }
    }
}
