using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    public class StoneOfOcean : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of the Ocean");
            Tooltip.SetDefault("Breath water instead of air" 
                + "\nAllows the ability to walk on water" 
                + "\nLets you move swiftly in liquids");
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
            recipe.AddIngredient(ItemID.GillsPotion);
            recipe.AddIngredient(ItemID.WaterWalkingPotion);
            recipe.AddIngredient(ItemID.FlipperPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Gills, 2);
            player.AddBuff(BuffID.WaterWalking, 2);
            player.AddBuff(BuffID.Flipper, 2);
        }
    }
}
