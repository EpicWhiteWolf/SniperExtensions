using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Weapons.Ranged
{
    class Dawnbreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dawnbreaker");
            Tooltip.SetDefault("Uses Rebar as ammo"
                + "\nSplit the horizon!");
        }

        public override void SetDefaults()
        {
            item.damage = 126;
            item.ranged = true;
            item.width = 92;
            item.height = 26;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 7;
            item.value = Item.sellPrice(0, 6, 0, 0);
            item.rare = 4;
            item.UseSound = SoundID.Item12;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = mod.ItemType("Rebar");
            item.crit = 16;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 16);
            recipe.AddIngredient(ItemID.LightShard, 2);
            recipe.AddIngredient(mod, "ScopedRifle");
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 3);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
            muzzleOffset.Y += 0;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }
    }
}
