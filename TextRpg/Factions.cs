namespace TextRpg
{
    [System.Serializable]
    class Factions
    {
        public enum Faction
        {
            MageClan,
            WarriorClan,
        }

        public int dmgBuff { get; set; }
        public int healthBuff { get; set; }
        public int enemiesKilledReq { get; set; }
        public int questCompletedReq { get; set; }
        public int levelReq { get; set; }

        public void GetFactionBuffs()
        {
            switch (Program.currentPlayer.currentFaction)
            {
                case Faction.WarriorClan:
                    dmgBuff = 2;
                    healthBuff = 5;
                    Program.currentPlayer.minDmg += dmgBuff;
                    Program.currentPlayer.maxDmg += dmgBuff;
                    Program.currentPlayer.hp += healthBuff;
                    Program.currentPlayer.maxHp += healthBuff;
                    break;
                case Faction.MageClan:
                    dmgBuff = 40;
                    healthBuff = 100;
                    Program.currentPlayer.minDmg += dmgBuff;
                    Program.currentPlayer.maxDmg += dmgBuff;
                    Program.currentPlayer.hp += healthBuff;
                    Program.currentPlayer.maxHp += healthBuff;
                    break;
            }
        }

        public void GetFactionReq(Faction faction)
        {
            switch (faction)
            {
                case Faction.MageClan:
                    enemiesKilledReq = 1000;
                    questCompletedReq = 200;
                    levelReq = 40;
                    break;
                case Faction.WarriorClan:
                    enemiesKilledReq = 0;
                    questCompletedReq = 0;
                    levelReq = 0;
                    break;
            }
        }

        public void FactionChoice()
        {
            Console.WriteLine(
                "Would you like to switch factions or learn more info about the factions?(S)wicth/(I)nfo");
            string? input;
            input = Console.ReadLine();
            if (input == "s" || input == "switch")
            {
                SwitchFaction();
            }
            else if (input == "i" || input == "info")
            {
                GetInfoOnFactions();
            }
        }

        public void SwitchFaction()
        {
            Console.WriteLine("Do you wish to switch from your faction?(y/n)");
            string? input;
            input = Console.ReadLine();

            if (input == "y")
            {
                Console.WriteLine("What faction do you wish to enter?: ");
                string? input1;
                input1 = Console.ReadLine()!.ToLower();
                Console.WriteLine("The factions you can join: Mage, Warrior");
                if (input1 == "mage")
                {
                    GetFactionReq(Faction.MageClan);
                    if (Program.currentPlayer.enemiesKilled >= enemiesKilledReq &&
                        Program.currentPlayer.questCompleted >= questCompletedReq &&
                        Program.currentPlayer.level >= levelReq)
                    {
                        Program.currentPlayer.currentFaction = Faction.MageClan;
                        GetFactionBuffs();
                    }
                    else
                    {
                        Console.WriteLine("You're to weak to join the faction");
                    }
                }
                else if (input1 == "warrior")
                {
                    Program.currentPlayer.currentFaction = Faction.WarriorClan;
                    GetFactionBuffs();
                }
            }
            else if (input == "n")
            {
                Console.WriteLine("You're still in the faction: " + Program.currentPlayer.currentFaction);
            }
        }

        public void GetInfoOnFactions()
        {
            Console.WriteLine("Please enter in the name of the faction you want to know more about: ");
            Console.WriteLine("The faction you can get more info on: Mage");
            string? input;
            input = Console.ReadLine()!.ToLower();
            if (input == "mage")
            {
                Program.Print("The mage clan was created by The Dark Lord centuries ago.");
                Program.Print("The requirements to join the clan are high!");
                Program.Print("You will need to be level 20");
                Program.Print("To have slaughtered 1000 enemies");
                Program.Print("And to have completed 200 quests!!");
                Program.Print(
                    "The Dark Lord is someone who transends God himeself. The Dark Lord is more powerfull than your brain can imagine!!!");
                Console.ReadKey();
            }
        }
    }
}