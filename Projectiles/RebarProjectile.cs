using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    class RebarProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rebar");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 240;
            projectile.penetrate = -1;
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
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f);
            Color glow = new Color(1f, 1f, 1f, 1f);
            GetAlpha(glow);
        }
    }
}