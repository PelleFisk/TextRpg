namespace TextRpg
{
    class Area
    {
        public string? currentArea { get; set; }

        public static void JoinArea(string? currentArea)
        {
            switch (currentArea)
            {
                case "shop":
                    Shop.RunShop(Program.currentPlayer);
                    break;
                case "weapon shop":
                    Shops.RunWeaponShop(Program.currentPlayer);
                    break;
                case "skill tree":
                    SkillTree.SkillTrees();
                    break;
                case "spell shop":
                    Shops.RunSpellShop(Program.currentPlayer);
                    break;
                case "universal shop":
                    Shops.RunShop(Program.currentPlayer);
                    break;
                case "armour shop":
                    Shops.RunArmourShop(Program.currentPlayer);
                    break;
            }
        }
    }
}