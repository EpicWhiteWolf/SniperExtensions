using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    public class StoneOfSight : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of Sight");
            Tooltip.SetDefault("-Emits an aura of light" 
                + "\nIncreases night vision" 
                + "\nShows the location of enemies" 
                + "\nAllows you to see nearby danger sources");
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
            recipe.AddIngredient(ItemID.ShinePotion);
            recipe.AddIngredient(ItemID.NightOwlPotion);
            recipe.AddIngredient(ItemID.HunterPotion);
            recipe.AddIngredient(ItemID.TrapsightPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Shine, 2);
            player.AddBuff(BuffID.NightOwl, 2);
            player.AddBuff(BuffID.Hunter, 2);
            player.AddBuff(BuffID.Dangersense, 2);
        }
    }
}
