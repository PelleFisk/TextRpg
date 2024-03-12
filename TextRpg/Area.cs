using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    WeaponStore.RunWeaponShop(Program.currentPlayer);
                    break;
                case "skill tree":
                    SkillTree.SkillTrees();
                    break;
                default:
                    break;
            }
        }
    }
}
