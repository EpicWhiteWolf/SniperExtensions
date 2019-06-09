using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    class DeepChillProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icicle Projectile");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 240;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Lighting.AddLight(projectile.Center, 0f, 0.5f, 1f);
            Color glow = new Color(1f, 1f, 1f, 1f);
            GetAlpha(glow);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(mod.BuffType<Buffs.DeepChillDebuff>(), 240);
        }
    }
}

