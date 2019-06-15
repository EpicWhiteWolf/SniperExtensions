using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    class HolyCrossNecklace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Cross Necklace");
            Tooltip.SetDefault("Defence greatly increased"
                + "\nwhen at critical health"
                + "\nIncreases length of invincibility" 
                + "\nafter taking damage"
                + "\nProvides light when equipped"
                + "\nTis but a scratch!");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = 10000;
            item.rare = 6;
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrossNecklace);
            recipe.AddIngredient(null, "HolyGrail");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Lighting.AddLight(item.Center, 1f, 1f, 0.75f);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.immuneTime = 60;

            if (player.whoAmI == Main.myPlayer)
            {
                Lighting.AddLight(player.Center, 1f, 1f, 0.75f);
            }

            if (player.statLife <= (float)player.statLifeMax * 0.25f)
            {
                player.endurance = 0.95f * (1 - (player.statLife / ((float)player.statLifeMax * 0.25f)));
            }
        }
    }
}
