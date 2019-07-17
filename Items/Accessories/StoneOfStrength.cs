using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    public class StoneOfStrength : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone of Strength");
            Tooltip.SetDefault("Increases damage by 10%" 
                + "\nIncreases critical chance by 10%" 
                + "\nAttackers also take damage");
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
            recipe.AddIngredient(ItemID.WrathPotion);
            recipe.AddIngredient(ItemID.RagePotion);
            recipe.AddIngredient(ItemID.ThornsPotion);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.Wrath, 2);
            player.AddBuff(BuffID.Rage, 2);
            player.AddBuff(BuffID.Thorns, 2);
        }
    }
}
