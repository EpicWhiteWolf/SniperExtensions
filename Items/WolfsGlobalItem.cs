using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items
{
    class WolfsGlobalItem : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.EyeOfCthulhuBossBag)
            {
                player.QuickSpawnItem(mod.ItemType("BladeOfCthulhu"));
            }
        }
    }
}