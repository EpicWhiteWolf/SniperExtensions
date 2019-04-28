using Terraria;
using Terraria.ModLoader;
using SniperExtensions.NPCs;

namespace SniperExtensions.Buffs
{
    class BoneBoltDebuff : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "SniperExtensions/Buffs/BoneBoltDebuff";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bone Bolt");
            Description.SetDefault("Bleeding");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<WolfsGlobalNPC>().boneBolt = true;
        }
    }
}
