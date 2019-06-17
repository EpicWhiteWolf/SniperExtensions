using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace WolfsAdditions.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings)]
    class SoulTrueFlight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of True Flight");
            Tooltip.SetDefault("Allows FLIGHT!");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 10000;
            item.rare = 4;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.wingTime = 180 * 1000000;
            player.maxFallSpeed *= 2;
            player.noFallDmg = true;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 2f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 2f;
            maxAscentMultiplier = 4f;
            constantAscend = 0.135f;
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            speed = 20f;
            acceleration *= 5f;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 1f);
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(item.Center, 0.25f, 0.25f, 0.25f);
        }
    }
}
