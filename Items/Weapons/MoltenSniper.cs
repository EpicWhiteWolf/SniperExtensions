using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Weapons
{
    public class MoltenSniper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Molten Sniper");
            Tooltip.SetDefault("Too hot to hold!");
        }

        public override void SetDefaults()
        {
            item.damage = 75;
            item.ranged = true;
            item.width = 74;
            item.height = 20;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 0;
            item.UseSound = SoundID.Item14;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
            item.crit = 21;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(null, "ScopedRifle");
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -4);
        }

        public override bool Shoot(Player player, ref Vector2 position,
            ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            speedX *= 1.5f;
            speedY *= 1.5f;
            muzzleOffset.Y += -4;
            position += muzzleOffset;
            return true;
        }
    }
}