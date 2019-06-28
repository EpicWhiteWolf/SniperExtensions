using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons.Magic
{
    class FireWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Fire");
            Tooltip.SetDefault("Flameo Hotman!");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 3;
            item.magic = true;
            item.mana = 6;
            item.width = 20;
            item.height = 20;
            item.useAnimation = 29;
            item.useTime = 7;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 0;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 34);
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("FireProjectile");
            item.shootSpeed = 6f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddRecipeGroup("Wood");
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
