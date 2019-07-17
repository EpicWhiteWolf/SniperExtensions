using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WolfsAdditions.Projectiles;

namespace WolfsAdditions.Items.Weapons.Melee
{
    public class BladeOfCthulhu : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blade Of Cthulhu");
            Tooltip.SetDefault("Yea i dont know either");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.useStyle = 5;
            item.width = 24;
            item.height = 24;
            item.useAnimation = 10;
            item.useTime = 10;
            item.shootSpeed = 16f;
            item.knockBack = 2.5f;
            item.damage = 9;
            item.rare = 0;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.autoReuse = true;

            item.shoot = mod.ProjectileType<EyeBlade>();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return player.ownedProjectileCounts[item.shoot] < 1;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D texture = mod.GetTexture("Items/Weapons/Melee/BladeOfCthulhuItem");
            spriteBatch.Draw(texture, position, null, drawColor, 0, origin, scale, SpriteEffects.None, 0f);
            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Vector2 offsetPositon = new Vector2(16, 16);
            Texture2D texture = mod.GetTexture("Items/Weapons/Melee/BladeOfCthulhuItem");
            Vector2 position = item.position - Main.screenPosition + new Vector2(item.width / 2, item.height - texture.Height * 0.5f + 2f);
            spriteBatch.Draw(texture, position + offsetPositon, null, alphaColor, rotation, texture.Size(), scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}