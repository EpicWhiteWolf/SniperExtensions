using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace WolfsAdditions.Items.Weapons
{
    class LacerationRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Laceration Rifle");
            Tooltip.SetDefault("Strip the flesh!" + "\nSalt the wound!");
        }

        public override void SetDefaults()
        {
            item.damage = 45;
            item.ranged = true;
            item.width = 74;
            item.height = 20;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item14;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -4);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.Bullet)
            {
                type = mod.ProjectileType("LacerationProjectile");
            }
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            speedX *= 1.2f;
            speedY *= 1.2f;
            muzzleOffset.Y += -6;
            position += muzzleOffset;
            return true;
        }
    }
}
