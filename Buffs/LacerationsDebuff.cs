using Terraria;
using Terraria.ModLoader;
using WolfsAdditions.NPCs;

namespace WolfsAdditions.Buffs
{
    class LacerationsDebuff : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "WolfsAdditions/Buffs/PlaceholderIcon";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lacerations");
            Description.SetDefault("Profusely Bleeding");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<WolfsGlobalNPC>(mod).lacerations = true;
        }
    }
}