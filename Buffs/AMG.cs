using Terraria;
using Terraria.ModLoader;

namespace WolfsAdditions.Buffs
{
    public class AMG : ModBuff
    {
        public override bool Autoload(ref string name, ref string texture)
        {
            texture = "WolfsAdditions/Buffs/AMG";
            
            return base.Autoload(ref name, ref texture);
        }

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Architects Mining Gear");
            Description.SetDefault("Mining and Tile placement speed is increased");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            canBeCleared = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {

            WolfsPlayer p = player.GetModPlayer<WolfsPlayer>();
            if (p.amgAccessoryPrevious)
            {
                p.amgVisual = true;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}