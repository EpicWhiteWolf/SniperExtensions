using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons.Magic
{
    class IceWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Ice");
            Tooltip.SetDefault("Bad Gunter!");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 7;
            item.magic = true;
            item.mana = 6;
            item.width = 20;
            item.height = 20;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item8;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("IceProjectile");
            item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddRecipeGroup("Wood");
            recipe.AddIngredient(ItemID.IceBlock);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}