namespace TextRpg
{
    [Serializable]
    class Player
    {
        public enum Classes
        {
            Mage,
            Warrior,
            Ranger
        }

        public string? name { get; set; }
        public int strength { get; set; }
        public int hp { get; set; }
        public int maxHp { get; set; }
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
        public string? currentZone { get; set; }
        public int levelReqZone { get; set; }
        public int difZone { get; set; }
        public int questCompleted { get; set; }
        public int enemiesKilled { get; set; }
        public bool emptyBodyArmourSlot { get; set; }
        public bool emptyBootsSlot { get; set; }
        public bool emptyGlovesSlot { get; set; }
        public bool emptyRingSlot { get; set; }
        public bool emptyAmuletSlot { get; set; }
        public bool emptyBeltSlot { get; set; }
        public bool emptyHelmetSlot { get; set; }
        public bool emptyWeaponSlot { get; set; }
        public Classes currentClass { get; set; }
        public Factions.Faction currentFaction { get; set; }

        public void Init()
        {
            name = "";
            strength = 5;
            intelligence = 5;
            dexterity = 5;
            hp = 10;
            maxHp = 10;
            minDmg = 2;
            maxDmg = 4;
            money = 0;
            exp = 0;
            level = 0;
            potions = 5;
            mods = 1;
            currentZone = "Starter Zone";
            levelReqZone = 0;
            difZone = Program.zone.DifZone(currentZone);
            questCompleted = 0;
            enemiesKilled = 0;
            emptyBodyArmourSlot = true;
            emptyAmuletSlot = true;
            emptyBeltSlot = true;
            emptyBootsSlot = true;
            emptyGlovesSlot = true;
            emptyHelmetSlot = true;
            emptyRingSlot = true;
            emptyWeaponSlot = true;
            currentFaction = Factions.Faction.WarriorClan;
            currentClass = Classes.Warrior;
            Program.zones.Add(new Zones(levelReqZone, currentZone));
            Program.currentWeapons.Add(new Weapon(0, "", 0, "",
                0, false, 0, true));
            Program.factions.GetFactionBuffs();
        }

        public int GetCoins()
        {
            int upper = (10 * mods + 50 * difZone);
            int lower = (10 * mods + 10 * difZone);
            return Program.rand.Next(lower, upper);
        }

        public int GetDmg()
        {
            int upper = (2 * mods + 4 * difZone);
            int lower = (mods + 4 * difZone);
            return Program.rand.Next(lower, upper);
        }

        public int GetHp()
        {
            int upper = (1 * mods + 8 * difZone);
            int lower = (1 * mods + 5 * difZone);
            return Program.rand.Next(lower, upper);
        }

        public int GetXp()
        {
            int upper = (20 * mods + 100 * difZone);
            int lower = (10 * mods + 20 * difZone);
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
                minDmg += 2;
                maxDmg += 2;
                level++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congrats! You are now level " + level + "!!!");
            Console.ResetColor();
        }
    }
}