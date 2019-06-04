using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons
{
    public class VortexSniper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Sniper");
            Tooltip.SetDefault("Mark targets with <right>");
        }

        public override void SetDefaults()
        {
            item.damage = 250;
            item.ranged = true;
            item.width = 100;
            item.height = 24;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
            item.crit = 16;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 2);
            recipe.AddIngredient(ItemID.FragmentVortex, 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-11, -7);
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                return Main.rand.NextFloat() >= 1f;
            }
            else
            {
                return Main.rand.NextFloat() >= 0f;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.useTime = 10;
                item.useAnimation = 10;
                item.UseSound = SoundID.Item12;

            }
            else
            {
                item.useTime = 60;
                item.useAnimation = 60;
                item.UseSound = SoundID.Item11;
            }
            return base.CanUseItem(player);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                type = mod.ProjectileType("VortexMarkProj");
                speedX *= 1.2f;
                speedY *= 1.2f;
            }

            else
            {
                type = mod.ProjectileType("VortexSniperProj");
                speedX *= 1.8f;
                speedY *= 1.8f;
            }
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            muzzleOffset.Y += -6;
            position += muzzleOffset;
            return true;
        }
    }
}
