using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons
{
    public class ScopedRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scoped Rifle");
            Tooltip.SetDefault("Not Scilenced!");
        }

        public override void SetDefaults()
        {
            item.damage = 20;
            item.ranged = true;
            item.width = 74;
            item.height = 20;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = Item.sellPrice(0, 0, 1, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item14;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
            item.crit = 16;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddIngredient(ItemID.Glass, 2);
            recipe.AddRecipeGroup("Wood", 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -4);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            muzzleOffset.Y += -6;
            speedX *= 1.2f;
            speedY *= 1.2f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}
