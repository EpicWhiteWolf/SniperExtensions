using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons
{
    class DaedelusGunbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daedelus Gunbow");
            Tooltip.SetDefault("Talk about bullet hell!");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DaedalusStormbow);
            item.useAmmo = AmmoID.Bullet;
            item.UseSound = SoundID.Item11;
            item.useAnimation = 10;
            item.useTime = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.DaedalusStormbow);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2(((float)Main.mouseX + Main.rand.Next(-100, 100)), (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 3; i++)
            {
                position = player.Center + new Vector2(((float)Main.rand.Next(-200, 200) + (Main.mouseX - 960)), -600f - (i * 100));
                position.Y -= (100 * i);
                Vector2 heading = target - position;
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                speedX = heading.X;
                speedY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, ceilingLimit);
            }
            return false;
        }
    }
}
