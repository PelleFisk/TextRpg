using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TextRpg
{
    [System.Serializable]
    class Quest
    {
        public string? currentQuest {  get; set; }
        public int enemiesKilled { get; set; }
        public int enemiesLeft { get; set; }
        public bool isQuestCompleted { get; set; }
        public bool isQuestActive { get; set; }

        public void StartQuest()
        {
            currentQuest = "Kill Enemies";
            enemiesKilled = 0;
            enemiesLeft = GetEnemiesToKill(Program.currentPlayer.currentZone!);
            isQuestCompleted = false;
        }

        public int GetEnemiesToKill(string zone)
        {
            switch (zone)
            {
                case "Starter Zone":
                    return enemiesLeft = 5;
                case "Dark Cave":
                    return enemiesKilled = 8;
            }
            return 0;
        }

        public bool IsQuestCompleted()
        {
            if (enemiesLeft == enemiesKilled)
            {
                isQuestCompleted = true;
            }
            else
            {
                isQuestCompleted = false;
            }

            return isQuestCompleted;
        }

        public void GetRewards()
        {
            int enemiesLeft = GetEnemiesToKill(Program.currentPlayer.currentZone!);
            int exp = 0;
            int coins = 0;

            if (enemiesLeft == 5)
            {
                exp = 100;
                coins = 400;
            }
            else if(enemiesLeft == 8)
            {
                exp = 200;
                coins = 600;
            }

            if (IsQuestCompleted())
            {
                Console.WriteLine("You got: " + exp + " exp!!");
                Console.WriteLine("You got: " + coins + " coins!!");
                Program.currentPlayer.exp += exp;
                Program.currentPlayer.money += coins;
            }
        }

        public void GetSpecialItem()
        {
            if (Program.currentPlayer.questCompleted == 10)
            {
                string? rarity = "legendary";
                string? name = "Purple Yama";
                int damage = Weapon.GetDamage(rarity);
                int sellValue = Weapon.GetSellValue(rarity);

                Console.WriteLine("You have unlocked a special sword!!");
                Console.WriteLine("It has a rarity of legendary!");
                Console.WriteLine("The name of the sword is: ");
                Console.WriteLine("Do you whish to equip it or store it(e)/(s)");
                string? input;
                input = Console.ReadLine()!;
                if (input == "e")
                {
                    int weaponId = 0;
                    weaponId = Program.currentWeapons!.Count();
                    Program.currentPlayer.currentWeaponName = name;
                    Program.currentPlayer.currentWeaponRarity = rarity;
                    Program.currentPlayer.weaponDamage = damage;
                    Program.currentPlayer.weaponSellValue = sellValue;
                    Program.currentWeapons!.Add(new Weapon(weaponId, name, sellValue, rarity, damage, true));
                }
                else if (input == "s")
                {
                    int weaponId = 0;
                    weaponId = Program.currentWeapons!.Count();
                    Program.currentWeapons!.Add(new Weapon(weaponId, name, sellValue, rarity, damage, true));
                }
                else
                {
                    int weaponId = 0;
                    weaponId = Program.currentWeapons!.Count();
                    Program.currentWeapons!.Add(new Weapon(weaponId, name, sellValue, rarity, damage, true));
                }
            }
        }
    }
}
