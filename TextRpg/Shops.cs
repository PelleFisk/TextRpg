namespace TextRpg
{
    class Shops
    {
        public static void RunShop(Player p)
        {
            Program.area.currentArea = "universal shop";
            Program.SaveArea();
            Console.WriteLine(
                "Welcome to the universal shop, please enter in the name of the shop you want to enter. (S)pells/(W)eapon/(A)rmour");
            string input;
            input = Console.ReadLine()!.ToLower();

            switch (input)
            {
                case "s":
                case "spells":
                    RunSpellShop(p);
                    break;
                case "w":
                case "weapon":
                    RunWeaponShop(p);
                    break;
                case "a":
                case "armour":
                    RunArmourShop(p);
                    break;
            }
        }

        public static void RunSpellShop(Player p)
        {
            Program.area.currentArea = "spell shop";
            Program.SaveArea();
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Welcome to the spell shop");
            Console.WriteLine("Here you can buy spells for gold you have accumulated from your travels");
            Console.WriteLine("Would you like to buy a new spell?(B)uy/(E)xit");
            Console.WriteLine("===============");

            string? input;
            input = Console.ReadLine()!.ToLower();
            if (input == "b" || input == "buy")
            {
                BuySpells(p);
            }
            else if (input == "e" || input == "exit")
            {
                Shop.InitShop(p);
            }
        }

        public static void BuySpells(Player p)
        {
            string rarity1 = Spells.GetShopRarity();
            string rarity2 = Spells.GetShopRarity();
            string rarity3 = Spells.GetShopRarity();
            string name1 = Spells.GetName();
            string name2 = Spells.GetName();
            string name3 = Spells.GetName();
            int spell1Cost = Spells.GetCost(rarity1);
            int spell2Cost = Spells.GetCost(rarity2);
            int spell3Cost = Spells.GetCost(rarity3);

            Console.WriteLine("===============");
            Console.WriteLine("First Spell Name: " + name1);
            Console.WriteLine("First Spell Cost: " + spell1Cost);
            Console.WriteLine("First Spell Rarity: " + rarity1);
            Console.WriteLine("===============");
            Console.WriteLine("Second Spell Name: " + name2);
            Console.WriteLine("Second Spell Cost: " + spell2Cost);
            Console.WriteLine("Second Spell Rarity: " + rarity2);
            Console.WriteLine("===============");
            Console.WriteLine("Third Spell Name: " + name3);
            Console.WriteLine("Third Spell Cost: " + spell3Cost);
            Console.WriteLine("Third Spell Rarity: " + rarity3);
            Console.WriteLine("===============");

            Console.WriteLine("What spell would you like to buy?(one/second/third)");
            string? input = "";
            input = Console.ReadLine();
            if (input == "one")
            {
                BuySpell(name1, rarity1, spell1Cost, p);
            }
            else if (input == "second")
            {
                BuySpell(name2, rarity2, spell2Cost, p);
            }
            else if (input == "third")
            {
                BuySpell(name3, rarity3, spell3Cost, p);
            }
        }

        public static void BuySpell(string? name, string? rarity, int cost, Player p)
        {
            if (p.money >= cost)
            {
                int spellId = 0;
                int damage = Spells.GetDamage(rarity);
                int intReq = Spells.GetIntReq(rarity!);
                Console.WriteLine("Do you wish to store the spell in your inventory or equip it(S(tore)/(E)quip)");
                string? input;
                input = Console.ReadLine()!.ToLower();
                if (input == "s" || input == "store")
                {
                    Program.currentSpells.Add(new Spells(spellId, name!, damage, cost, intReq, rarity!));
                    p.money -= cost;
                }
                else if (input == "e" || input == "equip")
                {
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

        public static void RunWeaponShop(Player p)
        {
            Program.area.currentArea = "weapon shop";
            Program.SaveArea();
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Welcome to the weapon store");
            Console.WriteLine(
                "Here you can buy weapons for gold you have accumulated from your travels or sell your swords");
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
                                      + weapon.rarity + "\n" + "Strength Req: " + "\n"
                                      + weapon.strReq + "===============\n");
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
                var weaponId = 0;
                var damage = Weapon.GetDamage(rarity);
                var sellValue = Weapon.GetSellValue(rarity);
                var strReq = Weapon.GetStrReq(rarity!);
                weaponId = Program.currentWeapons.Count()!;
                Console.WriteLine("Do you wish to store the weapon in your inventory or equip it(S(tore)/(E)quip)");
                string? input;
                input = Console.ReadLine()!.ToLower();
                if (input == "s" || input == "store")
                {
                    Program.currentWeapons.Add(new Weapon(weaponId, name!, sellValue, rarity!, damage, false, strReq,
                        false));
                    p.money -= cost;
                }
                else if (input == "e" || input == "equip")
                {
                    Program.currentWeapons.Add(new Weapon(weaponId, name!, sellValue, rarity!, damage, false, strReq,
                        true));
                    Program.weapon.name = name;
                    Program.weapon.damage = damage;
                    Program.weapon.sellValue = sellValue;
                    Program.weapon.strReq = strReq;
                    Program.weapon.currentWeapon = true;
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

        public static void RunArmourShop(Player p)
        {
            Program.area.currentArea = "armour shop";
            Program.SaveArea();
            Console.Clear();
            Console.WriteLine("===============");
            Console.WriteLine("Welcome to the armour shop");
            Console.WriteLine("Here you can buy armour for gold you have accumulated from your travels");
            Console.WriteLine("Would you like to buy a new armour piece?(B)uy/(E)xit");
            Console.WriteLine("===============");

            string? input;
            input = Console.ReadLine()!.ToLower();
            if (input == "b" || input == "buy")
            {
                BuyArmours(p);
            }
            else if (input == "e" || input == "exit")
            {
                Shop.InitShop(p);
            }
        }

        public static void BuyArmours(Player p)
        {
            Console.WriteLine("What armour piece do you wish to buy?");
            Console.WriteLine("b for boots");
            Console.WriteLine("r for ring");
            Console.WriteLine("ba for body armour");
            Console.WriteLine("a for amulet");
            Console.WriteLine("h for helmet");
            Console.WriteLine("g for gloves");
            Console.WriteLine("be for belt");
            Console.WriteLine("e for exit");
            Console.Write("> ");
            string input;
            input = Console.ReadLine()!.ToLower();

            switch (input)
            {
                case "b":
                    BuyBoots();
                    break;
                case "r":
                    BuyRings();
                    break;
                case "ba":
                    BuyBodyArmour();
                    break;
                case "a":
                    BuyAmulets();
                    break;
                case "h":
                    BuyHelmets();
                    break;
                case "g":
                    BuyGloves();
                    break;
                case "be":
                    BuyBelts();
                    break;
                case "e":
                    RunShop(p);
                    break;
                default:
                    Console.WriteLine("You need to enter a legitamete input");
                    break;
            }
        }

        public static void BuyBoots()
        {
            Boots boots = new Boots("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = boots!.GetName();
            string name2 = boots!.GetName();
            string name3 = boots!.GetName();

            BuyArmourInterface(name1, name2, name3, "boots");
        }

        public static void BuyBelts()
        {
            Belt belt = new Belt("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = belt!.GetName();
            string name2 = belt!.GetName();
            string name3 = belt!.GetName();

            BuyArmourInterface(name1, name2, name3, "belts");
        }

        public static void BuyRings()
        {
            Ring ring = new Ring("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = ring!.GetName();
            string name2 = ring!.GetName();
            string name3 = ring!.GetName();

            BuyArmourInterface(name1, name2, name3, "rings");
        }

        public static void BuyBodyArmour()
        {
            BodyArmour armour = new BodyArmour("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = armour!.GetName();
            string name2 = armour!.GetName();
            string name3 = armour!.GetName();

            BuyArmourInterface(name1, name2, name3, "body armours");
        }

        public static void BuyHelmets()
        {
            Helmet helmet = new Helmet("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = helmet!.GetName();
            string name2 = helmet!.GetName();
            string name3 = helmet!.GetName();

            BuyArmourInterface(name1, name2, name3, "helmets");
        }

        public static void BuyGloves()
        {
            Gloves gloves = new Gloves("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = gloves!.GetName();
            string name2 = gloves!.GetName();
            string name3 = gloves!.GetName();

            BuyArmourInterface(name1, name2, name3, "gloves");
        }

        public static void BuyAmulets()
        {
            Amulet amulet = new Amulet("", "", 0, 0, 0, 0, 0, false, false);
            string name1 = amulet!.GetName();
            string name2 = amulet!.GetName();
            string name3 = amulet!.GetName();

            BuyArmourInterface(name1, name2, name3, "amulet");
        }

        public static void BuyArmourInterface(string name1, string name2, string name3, string armourType)
        {
            var (rar1, rar2, rar3) = Armour.GetShopRarity();
            var (dexAtr1, dexAtr2, dexAtr3) = Armour.GetShopDexAtr(rar1, rar2, rar3);
            var (intAtr1, intAtr2, intAtr3) = Armour.GetShopIntAtr(rar1, rar2, rar3);
            var (strAtr1, strAtr2, strAtr3) = Armour.GetShopStrAtr(rar1, rar2, rar3);
            var (armour1Cost, armour2Cost, armour3Cost) = Armour.GetShopCost(rar1, rar2, rar3);
            var (armour1, armour2, armour3) = Armour.GetShopArmour(rar1, rar2, rar3);

            Console.WriteLine("===============");
            Console.WriteLine("First Armour Name: " + name1);
            Console.WriteLine("First Armour Cost: " + armour1Cost);
            Console.WriteLine("First Armour Rarity: " + rar1);
            Console.WriteLine("First Armour Str Atr: " + strAtr1);
            Console.WriteLine("First Armour Int Atr: " + intAtr1);
            Console.WriteLine("First Armour Dex Atr: " + dexAtr1);
            Console.WriteLine("First Armour Defense: " + armour1);
            Console.WriteLine("===============");
            Console.WriteLine("Second Armour Name: " + name2);
            Console.WriteLine("Second Armour Cost: " + armour2Cost);
            Console.WriteLine("Second Armour Rarity: " + rar2);
            Console.WriteLine("Second Armour Str Atr: " + strAtr2);
            Console.WriteLine("Second Armour Int Atr: " + intAtr2);
            Console.WriteLine("Second Armour Dex Atr: " + dexAtr2);
            Console.WriteLine("Second Armour Defense: " + armour2);
            Console.WriteLine("===============");
            Console.WriteLine("Third Armour Name: " + name3);
            Console.WriteLine("Third Armour Cost: " + armour3Cost);
            Console.WriteLine("Third Armour Rarity: " + rar3);
            Console.WriteLine("Third Armour Str Atr: " + strAtr3);
            Console.WriteLine("Third Armour Int Atr: " + intAtr3);
            Console.WriteLine("Third Armour Dex Atr: " + dexAtr3);
            Console.WriteLine("Third Armour Defense: " + armour3);
            Console.WriteLine("===============");

            Console.WriteLine("Please enter in the number of the armour you want to buy");
            Console.WriteLine("1 for first");
            Console.WriteLine("2 for second");
            Console.WriteLine("3 for third");
            Console.Write("> ");

            string input;
            input = Console.ReadLine()!;

            switch (input)
            {
                case "1":
                    Armour.BuyArmour(name1, rar1, armour1Cost, Program.currentPlayer, strAtr1, dexAtr1, intAtr1,
                        armour1, armourType);
                    Program.SaveArmour();
                    break;
                case "2":
                    Armour.BuyArmour(name2, rar2, armour2Cost, Program.currentPlayer, strAtr2, dexAtr2, intAtr2,
                        armour2, armourType);
                    Program.SaveArmour();
                    break;
                case "3":
                    Armour.BuyArmour(name3, rar3, armour3Cost, Program.currentPlayer, strAtr3, dexAtr3, intAtr3,
                        armour3, armourType);
                    Program.SaveArmour();
                    break;
            }
        }
    }
}