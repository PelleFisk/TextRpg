namespace TextRpg
{
    class SkillTree
    {
        public static void SkillTrees()
        {
            Program.area.currentArea = "skill tree";
            Program.SaveArea();

            Console.WriteLine("Welcome to the skill-tree");
            Console.WriteLine("Your skill-points: " + Program.currentPlayer.skillPoints);
            Console.WriteLine("You can upgrade both your int, dexterity and strength");
            Console.WriteLine(
                "Write 'int' for int upgrade and 'dex' for dexterity and 'str' for strength upgrade and you can type 'e' to exit");
            string? input;
            input = Console.ReadLine()!.ToLower();

            if (input == "int")
            {
                UpgradeInt();
            }
            else if (input == "dmg")
            {
                UpgradeDex();
            }
            else if (input == "str")
            {
                UpgradeStr();
            }
            else if (input == "e")
            {
                Shop.InitShop(Program.currentPlayer);
            }
        }

        public static void UpgradeInt()
        {
            if (Program.currentPlayer.skillPoints >= 1)
            {
                Program.currentPlayer.intelligence += 5;
                Program.currentPlayer.skillPoints--;
                Console.WriteLine("Upgrade intelligence to " + Program.currentPlayer.intelligence);
                Program.SavePlayer();
            }
            else
            {
                Console.WriteLine("You dont have enough skill points");
            }
        }

        public static void UpgradeDex()
        {
            if (Program.currentPlayer.skillPoints >= 1)
            {
                Program.currentPlayer.dexterity += 5;
                Program.currentPlayer.skillPoints--;
                Console.WriteLine("Your dexterity is now: " + Program.currentPlayer.dexterity);
                Program.SavePlayer();
            }
            else
            {
                Console.WriteLine("You dont have enough skill points");
            }
        }

        public static void UpgradeStr()
        {
            if (Program.currentPlayer.skillPoints >= 1)
            {
                Program.currentPlayer.strength += 5;
                Program.currentPlayer.skillPoints--;
                Console.WriteLine("Your strength is now: " + Program.currentPlayer.strength);
                Program.SavePlayer();
            }
            else
            {
                Console.WriteLine("You dont have enough skill points");
            }
        }
    }
}