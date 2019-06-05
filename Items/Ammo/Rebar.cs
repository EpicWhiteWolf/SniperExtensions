using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Ammo
{
    class Rebar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rebar");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 14;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 5f;
            item.value = Item.sellPrice(0, 0, 0, 10);
            item.rare = 1;
            item.shoot = mod.ProjectileType("RebarProjectile");
            item.shootSpeed = 7f;
            item.ammo = mod.ItemType("Rebar");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 25);
            recipe.AddRecipe();
        }
    }
}
