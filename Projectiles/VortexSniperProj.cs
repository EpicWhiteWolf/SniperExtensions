using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace WolfsAdditions.Projectiles
{
    class VortexSniperProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Sniper Shot");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 240;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.aiStyle = 0;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(0.1f, 0.8f, 0.6f, 1f);
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (target.HasBuff(mod.BuffType<Buffs.MarkedDebuff>()))
            {
                damage *= 2;
            }
        }
    }
}
