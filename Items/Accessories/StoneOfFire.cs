using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    public class StoneOfFire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of Fire");
            Tooltip.SetDefault("Provides immunity to lava" 
                + "\nIgnites nearby enemies" 
                + "\nReduces damage from cold sources");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 30;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PhilosophersStone);
            recipe.AddIngredient(ItemID.ObsidianSkinPotion);
            recipe.AddIngredient(ItemID.InfernoPotion);
            recipe.AddIngredient(ItemID.WarmthPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.ObsidianSkin, 2);
            player.AddBuff(BuffID.Inferno, 2);
            player.AddBuff(BuffID.Warmth, 2);
        }
    }
}
