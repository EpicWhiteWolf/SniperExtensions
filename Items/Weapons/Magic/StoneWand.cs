using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons.Magic
{
    class StoneWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wand of Stone");
            Tooltip.SetDefault("Rock on!");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 5;
            item.magic = true;
            item.mana = 3;
            item.width = 20;
            item.height = 20;
            item.useTime = 7;
            item.useAnimation = 7;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item32;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StoneProjectile");
            item.shootSpeed = 12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar);
            recipe.AddRecipeGroup("Wood");
            recipe.AddIngredient(ItemID.StoneBlock);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(3));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
    }
}
