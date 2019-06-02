using Terraria;
using Terraria.ModLoader;
using WolfsAdditions.NPCs;

namespace WolfsAdditions.Buffs
{
    class BoneBoltDebuff : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "WolfsAdditions/Buffs/PlaceholderIcon";
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
