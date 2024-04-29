namespace TextRpg
{
    class Encounter
    {
        public static Random rand = new Random();
        public static string? name;

        public static int playerDefence = Program.boots.armour + Program.helmet.armour + Program.armour.armour +
                                          Program.belt.armour + Program.ring.armour + Program.amulet.armour +
                                          Program.gloves.armour;

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
                n = GetNames();
                d = Program.currentPlayer.GetDmg();
                h = Program.currentPlayer.GetHp();
            }

            if (!Program.quest.isQuestActive)
            {
                Program.quest.StartQuest();
                Program.quest.isQuestActive = true;
            }

            while (h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("Monster Damage: " + d + "/" + "Monster Hp: " + h);
                Console.WriteLine("========================");
                Console.WriteLine("| (A)ttack (D)efend    |");
                Console.WriteLine("| (R)un    (H)eal      |");
                Console.WriteLine("| (I)nventory          |");
                Console.WriteLine("| (Z)one               |");
                Console.WriteLine("| (Ar)mour  (S)pells   |");
                Console.WriteLine("| Quest Progress:      |");
                Console.WriteLine($"| Enemies Killed:   {Program.quest.enemiesKilled}  |");
                Console.WriteLine($"| Enemies To Kill:  {Program.quest.enemiesLeft}  |");
                Console.WriteLine("========================");
                Console.WriteLine("  Potions:  " + Program.currentPlayer.potions + "  Health:  " +
                                  Program.currentPlayer.hp);
                string? input = Console.ReadLine()!;

                if (input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    int attack = rand.Next((Program.currentPlayer.minDmg + Program.weapon.damage),
                        (Program.currentPlayer.maxDmg + Program.weapon.damage));
                    int damage = d - playerDefence;
                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    Console.WriteLine(
                        "You prepare to strike with a force of a thousand gods. But when you strike you also take damage from " +
                        n + " and you lose " + damage + ". But you dealt " + attack + " damage");
                    Program.currentPlayer.hp -= damage;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    int attack = rand.Next((Program.currentPlayer.minDmg + Program.weapon.damage),
                        (Program.currentPlayer.maxDmg + Program.weapon.damage));
                    int damage = d - playerDefence;
                    if (damage < 0)
                    {
                        damage = 0;
                    }

                    Console.WriteLine(
                        "You take your sword and block the attack. But the attempt was not successful so you still took " +
                        damage + ". But in the end you also dealt " + attack + " damage!");
                    Program.currentPlayer.hp -= d;
                    h -= attack;
                    Console.ReadKey();
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint way from the " + n +
                                          ", it strikes catches you in the back, sending you sprawling to the ground");
                        int damage = d - playerDefence;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose " + damage + " health and are unable to escape.");
                        Program.currentPlayer.hp -= damage;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You use your crazy ninja moves to evade the " + n +
                                          " and you successfully escape!");
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

                else if (input.ToLower() == "i" || input.ToLower() == "inventory")
                {
                    foreach (var weapon in Program.currentWeapons)
                    {
                        Console.WriteLine("===============\n"
                                          + "Weapon Id: "
                                          + weapon.id + "\n" + "Weapon Name: "
                                          + weapon.name + "\n" + "Weapon Sell Value: "
                                          + weapon.sellValue + "\n" + "Weapon Damage: "
                                          + weapon.damage + "\n" + "Weapon Rarity: "
                                          + weapon.rarity + "\n" + "Weapon Str Req: "
                                          + weapon.strReq + "\n" + "===============\n");
                    }

                    Console.WriteLine("Please enter in the id of what sword you want to use");
                    if (int.TryParse(Console.ReadLine(), out var idOfsword))
                    {
                        var weaponToEquip = Program.currentWeapons.Find(w => w.id == idOfsword);
                        if (weaponToEquip != null && weaponToEquip.strReq <= Program.currentPlayer.strength)
                        {
                            Program.weapon.name = weaponToEquip.name;
                            Program.weapon.rarity = weaponToEquip.rarity;
                            Program.weapon.damage = weaponToEquip.damage;
                            Program.weapon.sellValue = weaponToEquip.sellValue;
                            Program.weapon.strReq = weaponToEquip.strReq;
                            Program.weapon.currentWeapon = true;
                            Console.WriteLine("Sword with the damage of: " +
                                              Program.weapon.damage);
                        }
                        else
                        {
                            Console.WriteLine("You are not strong enough to wield this sword yet!!");
                        }
                    }

                    Console.ReadKey();
                }

                else if (input.ToLower() == "z" || input.ToLower() == "zone")
                {
                    foreach (var zone in Program.zones)
                    {
                        Console.WriteLine("===============\n"
                                          + zone.levelToEnter + "\n"
                                          + zone.currentZone + "\n"
                                          + "===============\n");
                    }

                    Console.WriteLine("What zone do you want to go to?: ");
                    string zoneName;
                    zoneName = Console.ReadLine()!.ToLower();
                    var zoneToJoin = Program.zones.Find(z => z.currentZone == zoneName);
                    if (zoneToJoin != null)
                    {
                        Program.currentPlayer.currentZone = zoneToJoin.currentZone;
                    }

                    Console.WriteLine("You entered the zone: " + Program.currentPlayer.currentZone);
                    Console.ReadKey();
                }
                else if (input.ToLower() == "ar" || input.ToLower() == "armour")
                {
                    Console.WriteLine("What do you choose to equip?");
                    Console.WriteLine("0: Boots");
                    Console.WriteLine("1: Amulets");
                    Console.WriteLine("2: Gloves");
                    Console.WriteLine("3: Belts");
                    Console.WriteLine("4: Rings");
                    Console.WriteLine("5: Body Armour");
                    Console.WriteLine("6: Helmets");
                    Console.WriteLine("Enter in the number");
                    Console.Write("> ");

                    var arInput = Console.ReadLine();

                    switch (arInput)
                    {
                        case "0":
                            Armour.EquipBoots();
                            break;
                        case "1":
                            Armour.EquipAmulet();
                            break;
                        case "2":
                            Armour.EquipGloves();
                            break;
                        case "3":
                            Armour.EquipBelt();
                            break;
                        case "4":
                            Armour.EquipRing();
                            break;
                        case "5":
                            Armour.EquipArmor();
                            break;
                        case "6":
                            Armour.EquipHelmet();
                            break;
                    }
                }
                else if (input.ToLower() == "s" || input.ToLower() == "spells")
                {
                    foreach (var spells in Program.currentSpells)
                    {
                        Console.WriteLine("===============\n"
                                          + "Spell Id: "
                                          + spells.id + "\n" + "Spell Name: "
                                          + spells.name + "\n" + "Spell Damage: "
                                          + spells.damage + "\n" + "Spell Rarity: "
                                          + spells.rarity + "\n" + "===============\n");
                    }

                    Console.WriteLine("Please enter in the id of what spell you want to cast");
                    int idOfSpell;
                    if (int.TryParse(Console.ReadLine(), out idOfSpell))
                    {
                        var spellToCast = Program.currentSpells.Find(s => s.id == idOfSpell);
                        if (spellToCast != null && spellToCast.intReq <= Program.currentPlayer.intelligence)
                        {
                            int attack = spellToCast.damage;
                            int damage = d;
                            if (damage < 0)
                            {
                                damage = 0;
                            }

                            Console.WriteLine(
                                "You prepare to cast your spell. But when you cast the spell you also take damage from " +
                                n + " and you lose " + damage + ". But you dealt " + attack + " damage");
                            Program.currentPlayer.hp -= damage;
                            h -= attack;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You dont have enough int to cast the spell!!");
                        }
                    }
                }

                if (Program.currentPlayer.hp <= 0)
                {
                    Console.WriteLine("You have been slain by " + n + "!!\n");
                    Program.ResetPlayer();
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }

            int c = Program.currentPlayer.GetCoins();
            int xp = Program.currentPlayer.GetXp();
            Program.quest.enemiesKilled += 1;
            bool isQuestCompleted = Program.quest.IsQuestCompleted();
            Console.WriteLine("You have slain the mighty " + n +
                              ". And now that the foul creature is dead you gained " + c + " coins as a reward!");
            Console.WriteLine("You also gained " + xp + " xp!!");
            Program.currentPlayer.exp += xp;
            Program.currentPlayer.money += c;
            if (Program.currentPlayer.CanLevelUp())
            {
                Program.currentPlayer.LevelUp();
                string zoneName = Program.zone.CheckForZone(Program.currentPlayer.level);
                Program.zone.JoinZone(zoneName);
                Program.SaveZone();
            }

            if (isQuestCompleted)
            {
                Console.WriteLine("You have completed your quest!!!");
                Program.quest.GetRewards();
                Program.currentPlayer.questCompleted += 1;
                Program.quest.isQuestActive = false;
                Program.quest.GetSpecialItem();
            }

            if (Program.rand.Next(0, 2) == 0)
            {
                GetWeapon();
            }
        }

        public static void GetWeapon()
        {
            string? rarity = Weapon.GetRarity();
            string? name = Weapon.GetName();
            int damage = Weapon.GetDamage(rarity);
            int sellValue = Weapon.GetSellValue(rarity);
            int strReq = Weapon.GetStrReq(rarity!);

            Console.WriteLine("You got the sword: " + name);
            Console.WriteLine("With the rarity of: " + rarity);
            Console.WriteLine("With the damage of: " + damage);
            Console.WriteLine("With the sell value of: " + sellValue);

            Console.WriteLine("Do you wish to equip the sword or put it into your inventory?(y/n)");
            string? input = "";
            input = Console.ReadLine()!.ToLower();
            if (input == "y")
            {
                int weaponId = 0;
                if (Program.currentPlayer.strength >= strReq)
                {
                    weaponId = Program.currentWeapons!.Count();
                    Program.weapon.name = name;
                    Program.weapon.rarity = rarity;
                    Program.weapon.damage = damage;
                    Program.weapon.sellValue = sellValue;
                    Program.weapon.strReq = strReq;
                    Program.weapon.currentWeapon = true;
                }
                else
                {
                    Console.WriteLine("You are not strong enough to equip the sword!!");
                    Program.currentWeapons!.Add(new Weapon(weaponId, name, sellValue, rarity, damage, false, strReq,
                        false));
                }
            }
            else if (input == "n")
            {
                int weaponId = 0;
                weaponId = Program.currentWeapons!.Count();
                Program.currentWeapons!.Add(new Weapon(weaponId, name, sellValue, rarity, damage, false, strReq,
                    false));
            }
            else
            {
                int weaponId = 0;
                weaponId = Program.currentWeapons!.Count();
                Program.currentWeapons!.Add(new Weapon(weaponId, name, sellValue, rarity, damage, false, strReq,
                    false));
            }
        }

        public static string GetNames()
        {
            int randNum = rand.Next(0, 4);
            if (Program.currentPlayer.currentZone == "Starter Zone")
            {
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
            }
            else if (Program.currentPlayer.currentZone == "Dark Cave")
            {
                switch (randNum)
                {
                    case 0:
                        return "Dark Mage";
                    case 1:
                        return "Dark Wizard";
                    case 2:
                        return "Wicked Goblin";
                    case 3:
                        return "Shadow Zombie";
                }
            }
            else if (Program.currentPlayer.currentZone == "Mysticglow Enclave")
            {
                switch (randNum)
                {
                    case 0:
                        return "Eclipse Stalkers";
                    case 1:
                        return "Glimmershade Wraiths";
                    case 2:
                        return "Eldritch Sentinels";
                    case 3:
                        return "Crystal Golems";
                }
            }
            else if (Program.currentPlayer.currentZone == "Ethereal Grove")
            {
                switch (randNum)
                {
                    case 0:
                        return "Duskpetal Predators";
                    case 1:
                        return "Moonlace Banshees";
                    case 2:
                        return "Veilshift Shadows";
                    case 3:
                        return "Veilshift Shadows";
                }
            }

            return "";
        }
    }
}