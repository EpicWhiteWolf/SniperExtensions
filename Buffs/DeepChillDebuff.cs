using Terraria;
using Terraria.ModLoader;
using WolfsAdditions.NPCs;

namespace WolfsAdditions.Buffs
{
    class DeepChillDebuff : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "WolfsAdditions/Buffs/PlaceholderIcon";
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frozen");
            Description.SetDefault("Slowed");
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<WolfsGlobalNPC>(mod).deepChill = true;
        }
    }
}