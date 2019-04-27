using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Ammo
{
    public class BoneBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Bolt");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 14;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 5f;
            item.value = Item.sellPrice(0, 0, 0, 10);
            item.rare = 1;
            item.shoot = mod.ProjectileType("BoneBoltProjectile");
            item.shootSpeed = 7f;
            item.ammo = mod.ItemType("BoneBolt");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FossilOre);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
