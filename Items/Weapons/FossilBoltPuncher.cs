using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Weapons
{
    public class FossilBoltPuncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fossil Bolt Puncher");
            Tooltip.SetDefault("Bone Shattering!");
        }

        public override void SetDefaults()
        {
            item.damage = 65;
            item.ranged = true;
            item.width = 96;
            item.height = 20;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 10;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 16f;
            item.useAmmo = mod.ItemType("BoneBolt");
            item.crit = 16;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 5);
            recipe.AddIngredient(ItemID.Glass, 2);
            recipe.AddIngredient(ItemID.FossilOre, 8);
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
            speedX *= 1.5f;
            speedY *= 1.5f;
            muzzleOffset.Y += -5;
            position += muzzleOffset;
            return true;
        }
    }
}
