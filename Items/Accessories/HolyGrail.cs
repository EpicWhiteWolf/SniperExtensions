using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    class HolyGrail : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Grail");
            Tooltip.SetDefault("Defence greatly increased"
                + "\nwhen at critical health"
                + "\nProvides light when equipped"
                + "\nTis but a scratch!");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 0, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(item.Center, 1f, 1f, 0.75f);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Lighting.AddLight(player.Center, 1f, 1f, 0.75f);
            }

            player.endurance += 0.71f * (1 - (player.statLife / ((float)player.statLifeMax2)));
        }
    }
}
