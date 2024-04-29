namespace TextRpg;

public abstract class BaseArmour
{
    public static string GetShopRarity()
    {
        string? rarity = "";
        int randNum = Program.rand.Next(0, 101);

        rarity = randNum switch
        {
            <= 40 => "common",
            <= 70 => "uncommon",
            <= 80 => "rare",
            <= 90 => "epic",
            <= 100 => "legendary",
            _ => rarity
        };

        return rarity;
    }

    public static int GetStrAtr(string? rarity)
    {
        if (Program.rand.Next(0, 3) == 0)
        {
            switch (rarity)
            {
                case "common":
                    return Program.rand.Next(1, 5);
                case "uncommon":
                    return Program.rand.Next(3, 5);
                case "rare":
                    return Program.rand.Next(3, 8);
                case "epic":
                    return Program.rand.Next(5, 10);
                case "legendary":
                    return Program.rand.Next(10, 15);
            }
        }

        return 0;
    }

    public static int GetDexAtr(string? rarity)
    {
        if (Program.rand.Next(0, 3) == 0)
        {
            switch (rarity)
            {
                case "common":
                    return Program.rand.Next(1, 5);
                case "uncommon":
                    return Program.rand.Next(3, 5);
                case "rare":
                    return Program.rand.Next(3, 8);
                case "epic":
                    return Program.rand.Next(5, 10);
                case "legendary":
                    return Program.rand.Next(10, 15);
            }
        }

        return 0;
    }

    public static int GetIntAtr(string? rarity)
    {
        if (Program.rand.Next(0, 3) == 0)
        {
            switch (rarity)
            {
                case "common":
                    return Program.rand.Next(1, 5);
                case "uncommon":
                    return Program.rand.Next(3, 5);
                case "rare":
                    return Program.rand.Next(3, 8);
                case "epic":
                    return Program.rand.Next(5, 10);
                case "legendary":
                    return Program.rand.Next(10, 15);
            }
        }

        return 0;
    }

    public static int GetArmour(string? rarity)
    {
        int armour = 0;
        switch (rarity)
        {
            case "common":
                armour = 1 * (1 + 1);
                break;
            case "uncommon":
                armour = 1 * (2 + 1);
                break;
            case "rare":
                armour = 1 * (2 + 3);
                break;
            case "epic":
                armour = 1 * (3 + 3);
                break;
            case "legendary":
                armour = 1 * (5 + 3);
                break;
        }

        return armour;
    }

    public static int GetCost(string? rarity)
    {
        int cost = 0;
        switch (rarity)
        {
            case "common":
                cost = 100 * (1 + 3);
                break;
            case "uncommon":
                cost = 100 * (2 + 3);
                break;
            case "rare":
                cost = 100 * (3 + 3);
                break;
            case "epic":
                cost = 100 * (4 + 3);
                break;
            case "legendary":
                cost = 100 * (5 + 3);
                break;
        }

        return cost;
    }

    public abstract string GetName();
}

public class Boots : BaseArmour
{
    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentBoot { get; set; }

    public Boots(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentBoot)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentBoot = currentBoot;
    }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Prospect Paces";
            case 1:
                return "Neophyte Striders";
            case 2:
                return "Shadowstep Boots";
            case 3:
                return "Umbral March";
            case 4:
                return "Luminary Striders";
            case 5:
                return "Etheric Boots";
            case 6:
                return "Faewoven Boots";
            case 7:
                return "Whispering Leaveshoes";
        }

        return "";
    }
}

class Gloves : BaseArmour
{
    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentGlove { get; set; }

    public Gloves(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentGlove)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentGlove = currentGlove;
    }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Apprentice Grips";
            case 1:
                return "Trailblazer Gloves";
            case 2:
                return "Shadowclasp Gauntlets";
            case 3:
                return "Duskbringer Mitts";
            case 4:
                return "Luminous Handwraps";
            case 5:
                return "Enchanted Gauntlets";
            case 6:
                return "Verdant Touch Gloves";
            case 7:
                return "Sylvan Whisper Gloves";
        }

        return "";
    }
}

public class Belt : BaseArmour
{
    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentBelt { get; set; }

    public Belt(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentBelt)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentBelt = currentBelt;
    }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Novice Belt";
            case 1:
                return "Wanderer's Strap";
            case 2:
                return "Shadowbind Belt";
            case 3:
                return "Murkweave Sash";
            case 4:
                return "Luminescent Girdle";
            case 5:
                return "Arcane Cinch";
            case 6:
                return "Grovekeeper's Belt";
            case 7:
                return "Ethereal Vine Wrap";
        }

        return "";
    }
}

public class Amulet : BaseArmour
{
    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentAmulet { get; set; }

    public Amulet(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentAmulet)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentAmulet = currentAmulet;
    }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Novice Talisman";
            case 1:
                return "Wanderer's Pendant";
            case 2:
                return "Shadowcloak Amulet";
            case 3:
                return "Duskbound Medallion";
            case 4:
                return "Luminous Amulet";
            case 5:
                return "Arcane Talisman";
            case 6:
                return "Verdant Charm";
            case 7:
                return "Sylvan Pendant";
        }

        return "";
    }
}

public class Ring : BaseArmour
{
    public Ring(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentRing)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentRing = currentRing;
    }

    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentRing { get; set; }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Novice's Ring";
            case 1:
                return "Initiate's Circlet";
            case 2:
                return "Abyssal Loop";
            case 3:
                return "Umbral Ring";
            case 4:
                return "Radiant Band";
            case 5:
                return "Luminary Ring";
            case 6:
                return "Faewarden's Loop";
            case 7:
                return "Grove Ring";
        }

        return "";
    }
}

public class BodyArmour : BaseArmour
{
    public BodyArmour(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentBodyArmour)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentBodyArmour = currentBodyArmour;
    }

    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentBodyArmour { get; set; }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Initiate's Embrace";
            case 1:
                return "Trainee's Hauberk";
            case 2:
                return "Abyssal Robes";
            case 3:
                return "Shadowcloak";
            case 4:
                return "Ethereal Robes";
            case 5:
                return "Mysticglow Shroud";
            case 6:
                return "Ethereal Vestments";
            case 7:
                return "Faewarden's Raiment";
        }

        return "";
    }
}

class Helmet : BaseArmour
{
    public Helmet(string? name, string? rarity, int id, int dexAtr, int strAtr, int intAtr, int armour,
        bool isSlotEmpty, bool currentHelmet)
    {
        this.name = name;
        this.rarity = rarity;
        this.id = id;
        this.dexAtr = dexAtr;
        this.strAtr = strAtr;
        this.intAtr = intAtr;
        this.armour = armour;
        this.isSlotEmpty = isSlotEmpty;
        this.currentHelmet = currentHelmet;
    }

    public string? name { get; set; }
    public string? rarity { get; set; }
    public int id { get; set; }
    public int dexAtr { get; set; }
    public int strAtr { get; set; }
    public int intAtr { get; set; }
    public int armour { get; set; }
    public bool isSlotEmpty { get; set; }
    public bool currentHelmet { get; set; }

    public override string GetName()
    {
        int randNum = Program.rand.Next(0, 8);

        switch (randNum)
        {
            case 0:
                return "Novice's Visage";
            case 1:
                return "Beginner's Cowl";
            case 2:
                return "Shadow's Veil";
            case 3:
                return "Umbral Helm";
            case 4:
                return "Luminary Crown";
            case 5:
                return "Arcane Hood";
            case 6:
                return "Spiritbloom Helm";
            case 7:
                return "Grove Warden's Helm";
        }

        return "";
    }
}

class Armour
{
    public static void BuyArmour(string? name, string? rarity, int cost, Player p, int strAtr,
        int dexAtr, int intAtr, int armour, string? armourType)
    {
        if (p.money >= cost)
        {
            int armourId = 0;
            Console.WriteLine(
                $"Do you wish to store the {name} in your inventory or equip it(S(tore)/(E)quip)");
            string? input;
            input = Console.ReadLine()!.ToLower();
            if (input == "s" || input == "store")
            {
                EquipArmour(name, rarity, strAtr, dexAtr, intAtr, armour, armourType);

                p.money -= cost;
            }
            else if (input == "e" || input == "equip")
            {
                if (GetEmpty(armourType))
                {
                    EquipArmour(name, rarity, strAtr, dexAtr, intAtr, armour, armourType);
                }
                else
                {
                    Console.WriteLine(
                        $"Do you wish to equip the armour and un-equip your last {armourType}?(y/n): ");
                    string input1 = Console.ReadLine()!.ToLower();
                    if (input1 == "y")
                    {
                        switch (armourType)
                        {
                            case "helmet":
                                var currentHelmet = Program.currentHelmets.Find(h => h.currentHelmet);
                                currentHelmet!.currentHelmet = false;
                                break;
                            case "boots":
                                var currentBoots = Program.currentBoots.Find(b => b.currentBoot);
                                currentBoots!.currentBoot = false;
                                break;
                            case "belt":
                                var currentBelt = Program.currentBelts.Find(b => b.currentBelt);
                                currentBelt!.currentBelt = false;
                                break;
                            case "amulet":
                                var currentAmulet = Program.currentAmulets.Find(a => a.currentAmulet);
                                currentAmulet!.currentAmulet = false;
                                break;
                            case "body armour":
                                var currentArmour = Program.currentArmours.Find(a => a.currentBodyArmour);
                                currentArmour!.currentBodyArmour = false;
                                break;
                            case "gloves":
                                var currentGloves = Program.currentGloves.Find(g => g.currentGlove);
                                currentGloves!.currentGlove = false;
                                break;
                            case "ring":
                                var currentRing = Program.currentRings.Find(r => r.currentRing);
                                currentRing!.currentRing = false;
                                break;
                        }

                        EquipArmour(name, rarity, strAtr, dexAtr, intAtr, armour, armourType);
                        StoreArmour(name, rarity, strAtr, dexAtr, intAtr, armour, armourType);
                    }
                    else
                    {
                        Console.WriteLine($"You still have your {armourType} equipped");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("You dont have enough money!");
            Console.ReadKey();
        }
    }

    public static bool GetEmpty(string? armourType)
    {
        switch (armourType)
        {
            case "helmet":
                return Program.currentPlayer.emptyHelmetSlot;
            case "boots":
                return Program.currentPlayer.emptyBootsSlot;
            case "belt":
                return Program.currentPlayer.emptyBeltSlot;
            case "amulet":
                return Program.currentPlayer.emptyAmuletSlot;
            case "body armour":
                return Program.currentPlayer.emptyBodyArmourSlot;
            case "gloves":
                return Program.currentPlayer.emptyGlovesSlot;
            case "ring":
                return Program.currentPlayer.emptyRingSlot;
        }

        return true;
    }

    public static void EquipArmour(string? name, string? rarity, int strAtr,
        int dexAtr, int intAtr, int armour, string? armourType)
    {
        int armourId;

        switch (armourType)
        {
            case "helmet":
                armourId = Program.currentBoots!.Count();
                Program.helmet = new Helmet(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentHelmets.Add(new Helmet(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyHelmetSlot = false;
                break;
            case "boots":
                armourId = Program.currentBoots!.Count();
                Program.boots = new Boots(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentBoots.Add(new Boots(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyBootsSlot = false;
                break;
            case "belt":
                armourId = Program.currentBelts!.Count();
                Program.belt = new Belt(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentBelts.Add(new Belt(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyBeltSlot = false;
                break;
            case "amulet":
                armourId = Program.currentAmulets!.Count();
                Program.amulet = new Amulet(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentAmulets.Add(new Amulet(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyAmuletSlot = false;
                break;
            case "body armour":
                armourId = Program.currentArmours!.Count();
                Program.armour = new BodyArmour(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentArmours.Add(new BodyArmour(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyBodyArmourSlot = false;
                break;
            case "gloves":
                armourId = Program.currentGloves!.Count();
                Program.gloves = new Gloves(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentGloves.Add(new Gloves(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyGlovesSlot = false;
                break;
            case "ring":
                armourId = Program.currentRings!.Count();
                Program.ring = new Ring(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true);
                Program.currentRings.Add(new Ring(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, false, true));
                Program.currentPlayer.emptyRingSlot = false;
                break;
        }
    }

    public static void StoreArmour(string? name, string? rarity, int strAtr,
        int dexAtr, int intAtr, int armour, string? armourType)
    {
        int armourId;

        switch (armourType)
        {
            case "helmet":
                armourId = Program.currentBoots!.Count();
                Program.currentHelmets.Add(new Helmet(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
            case "boots":
                armourId = Program.currentBoots!.Count();
                Program.currentBoots.Add(new Boots(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
            case "belt":
                armourId = Program.currentBelts!.Count();
                Program.currentBelts.Add(new Belt(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
            case "amulet":
                armourId = Program.currentAmulets!.Count();
                Program.currentAmulets.Add(new Amulet(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
            case "body armour":
                armourId = Program.currentArmours!.Count();
                Program.currentArmours.Add(new BodyArmour(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
            case "gloves":
                armourId = Program.currentGloves!.Count();
                Program.currentGloves.Add(new Gloves(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
            case "ring":
                armourId = Program.currentRings!.Count();
                Program.currentRings.Add(new Ring(name, rarity, armourId, dexAtr, strAtr, intAtr,
                    armour, GetEmpty(armourType), false));
                break;
        }
    }

    public static void EquipBoots()
    {
        foreach (var boot in Program.currentBoots)
        {
            Console.WriteLine("===============\n"
                              + "Boot Id: "
                              + boot.id + "\n" + "Boot Name: "
                              + boot.name + "\n" + "Boot Int: "
                              + boot.intAtr + "\n" + "Boot Str: "
                              + boot.strAtr + "\n" + "Boot Dex: "
                              + boot.dexAtr + "\n" + "Boot Armour: "
                              + boot.armour + "\n" + "Boot Rarity: "
                              + boot.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfBoot;
        if (int.TryParse(Console.ReadLine(), out idOfBoot))
        {
            var bootToEquip = Program.currentBoots.Find(b => b.id == idOfBoot);

            if (bootToEquip != null)
            {
                Program.boots.currentBoot = false;
                bootToEquip.currentBoot = true;
                Program.boots = bootToEquip;
            }
        }
    }

    public static void EquipBelt()
    {
        foreach (var belt in Program.currentBelts)
        {
            Console.WriteLine("===============\n"
                              + "Belt Id: "
                              + belt.id + "\n" + "Belt Name: "
                              + belt.name + "\n" + "Belt Int: "
                              + belt.intAtr + "\n" + "Belt Str: "
                              + belt.strAtr + "\n" + "Belt Dex: "
                              + belt.dexAtr + "\n" + "Belt Armour: "
                              + belt.armour + "\n" + "Belt Rarity: "
                              + belt.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfBelt;
        if (int.TryParse(Console.ReadLine(), out idOfBelt))
        {
            var beltToEquip = Program.currentBelts.Find(b => b.id == idOfBelt);

            if (beltToEquip != null)
            {
                Program.belt.currentBelt = false;
                beltToEquip.currentBelt = true;
                Program.belt = beltToEquip;
            }
        }
    }

    public static void EquipGloves()
    {
        foreach (var gloves in Program.currentGloves)
        {
            Console.WriteLine("===============\n"
                              + "Gloves Id: "
                              + gloves.id + "\n" + "Gloves Name: "
                              + gloves.name + "\n" + "Gloves Int: "
                              + gloves.intAtr + "\n" + "Gloves Str: "
                              + gloves.strAtr + "\n" + "Gloves Dex: "
                              + gloves.dexAtr + "\n" + "Gloves Armour: "
                              + gloves.armour + "\n" + "Gloves Rarity: "
                              + gloves.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfGlove;
        if (int.TryParse(Console.ReadLine(), out idOfGlove))
        {
            var gloveToEquip = Program.currentGloves.Find(b => b.id == idOfGlove);

            if (gloveToEquip != null)
            {
                Program.gloves.currentGlove = false;
                gloveToEquip.currentGlove = true;
                Program.gloves = gloveToEquip;
            }
        }
    }

    public static void EquipArmor()
    {
        foreach (var armour in Program.currentArmours)
        {
            Console.WriteLine("===============\n"
                              + "Armour Id: "
                              + armour.id + "\n" + "Armour Name: "
                              + armour.name + "\n" + "Armour Int: "
                              + armour.intAtr + "\n" + "Armour Str: "
                              + armour.strAtr + "\n" + "Armour Dex: "
                              + armour.dexAtr + "\n" + "Armour Armour: "
                              + armour.armour + "\n" + "Armour Rarity: "
                              + armour.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfArmor;
        if (int.TryParse(Console.ReadLine(), out idOfArmor))
        {
            var armorToEquip = Program.currentArmours.Find(b => b.id == idOfArmor);

            if (armorToEquip != null)
            {
                Program.armour.currentBodyArmour = false;
                armorToEquip.currentBodyArmour = true;
                Program.armour = armorToEquip;
            }
        }
    }

    public static void EquipHelmet()
    {
        foreach (var helmet in Program.currentHelmets)
        {
            Console.WriteLine("===============\n"
                              + "Helmet Id: "
                              + helmet.id + "\n" + "Helmet Name: "
                              + helmet.name + "\n" + "Helmet Int: "
                              + helmet.intAtr + "\n" + "Helmet Str: "
                              + helmet.strAtr + "\n" + "Helmet Dex: "
                              + helmet.dexAtr + "\n" + "Helmet Armour: "
                              + helmet.armour + "\n" + "Helmet Rarity: "
                              + helmet.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfHelmet;
        if (int.TryParse(Console.ReadLine(), out idOfHelmet))
        {
            var helmetToEquip = Program.currentHelmets.Find(b => b.id == idOfHelmet);

            if (helmetToEquip != null)
            {
                Program.helmet.currentHelmet = false;
                helmetToEquip.currentHelmet = true;
                Program.helmet = helmetToEquip;
            }
        }
    }

    public static void EquipAmulet()
    {
        foreach (var amulet in Program.currentAmulets)
        {
            Console.WriteLine("===============\n"
                              + "Amulet Id: "
                              + amulet.id + "\n" + "Amulet Name: "
                              + amulet.name + "\n" + "Amulet Int: "
                              + amulet.intAtr + "\n" + "Amulet Str: "
                              + amulet.strAtr + "\n" + "Amulet Dex: "
                              + amulet.dexAtr + "\n" + "Amulet Armour: "
                              + amulet.armour + "\n" + "Amulet Rarity: "
                              + amulet.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfAmulet;
        if (int.TryParse(Console.ReadLine(), out idOfAmulet))
        {
            var amuletToEquip = Program.currentAmulets.Find(b => b.id == idOfAmulet);

            if (amuletToEquip != null)
            {
                Program.amulet.currentAmulet = false;
                amuletToEquip.currentAmulet = true;
                Program.amulet = amuletToEquip;
            }
        }
    }

    public static void EquipRing()
    {
        foreach (var ring in Program.currentRings)
        {
            Console.WriteLine("===============\n"
                              + "Ring Id: "
                              + ring.id + "\n" + "Ring Name: "
                              + ring.name + "\n" + "Ring Int: "
                              + ring.intAtr + "\n" + "Ring Str: "
                              + ring.strAtr + "\n" + "Ring Dex: "
                              + ring.dexAtr + "\n" + "Ring Armour: "
                              + ring.armour + "\n" + "Ring Rarity: "
                              + ring.rarity + "\n" + "===============\n");
        }

        Console.WriteLine("Please enter in the id of the boot you want to equip");
        Console.Write("> ");

        int idOfRing;
        if (int.TryParse(Console.ReadLine(), out idOfRing))
        {
            var ringToEqup = Program.currentRings.Find(b => b.id == idOfRing);

            if (ringToEqup != null)
            {
                Program.ring.currentRing = false;
                ringToEqup.currentRing = true;
                Program.ring = ringToEqup;
            }
        }
    }

    public static (int, int, int) GetShopDexAtr(string rar1, string rar2, string rar3)
    {
        int dexAtr1 = BaseArmour.GetStrAtr(rar1);
        int dexAtr2 = BaseArmour.GetStrAtr(rar2);
        int dexAtr3 = BaseArmour.GetStrAtr(rar3);
        return (dexAtr1, dexAtr2, dexAtr3);
    }

    public static (int, int, int) GetShopIntAtr(string rar1, string rar2, string rar3)
    {
        int intAtr1 = BaseArmour.GetStrAtr(rar1);
        int intAtr2 = BaseArmour.GetStrAtr(rar2);
        int intAtr3 = BaseArmour.GetStrAtr(rar3);
        return (intAtr1, intAtr2, intAtr3);
    }

    public static (int, int, int) GetShopStrAtr(string rar1, string rar2, string rar3)
    {
        int strAtr1 = BaseArmour.GetStrAtr(rar1);
        int strAtr2 = BaseArmour.GetStrAtr(rar2);
        int strAtr3 = BaseArmour.GetStrAtr(rar3);
        return (strAtr1, strAtr2, strAtr3);
    }

    public static (string, string, string) GetShopRarity()
    {
        string rar1 = BaseArmour.GetShopRarity();
        string rar2 = BaseArmour.GetShopRarity();
        string rar3 = BaseArmour.GetShopRarity();
        return (rar1, rar2, rar3);
    }

    public static (int, int, int) GetShopCost(string rar1, string rar2, string rar3)
    {
        int cost1 = BaseArmour.GetCost(rar1);
        int cost2 = BaseArmour.GetCost(rar2);
        int cost3 = BaseArmour.GetCost(rar3);

        return (cost1, cost2, cost3);
    }

    public static (int, int, int) GetShopArmour(string rar1, string rar2, string rar3)
    {
        int armour1 = BaseArmour.GetArmour(rar1);
        int armour2 = BaseArmour.GetArmour(rar2);
        int armour3 = BaseArmour.GetArmour(rar3);

        return (armour1, armour2, armour3);
    }
}