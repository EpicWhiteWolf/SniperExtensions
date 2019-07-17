using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    public class StoneOfFishing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of Fishing");
            Tooltip.SetDefault("Increases fishing skill" 
                + "\nDetects hooked fish" 
                + "\nIncreases chance to get a crate");
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
            recipe.AddIngredient(ItemID.FishingPotion);
            recipe.AddIngredient(ItemID.SonarPotion);
            recipe.AddIngredient(ItemID.CratePotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Fishing, 2);
            player.AddBuff(BuffID.Sonar, 2);
            player.AddBuff(BuffID.Crate, 2);
        }
    }
}
