﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    class ShadowThornProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shadow Thorn");
        }

        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 240;
            projectile.penetrate = 5;
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
            Lighting.AddLight(projectile.Center, 0.49f, 0.23f, 1f);
            Color glow = new Color(1f, 1f, 1f, 1f);
            GetAlpha(glow);
        }
    }
}
