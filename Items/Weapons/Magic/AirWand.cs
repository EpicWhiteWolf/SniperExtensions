using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons.Magic
{
    class AirWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Air");
            Tooltip.SetDefault("r/woooooooosh");
        }

        public override void SetDefaults()
        {
            item.damage = 3;
            item.magic = true;
            item.mana = 2;
            item.width = 32;
            item.height = 10;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AirProjectile");
            item.shootSpeed = 4f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddRecipeGroup("Wood");
            recipe.AddIngredient(ItemID.Bottle);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
