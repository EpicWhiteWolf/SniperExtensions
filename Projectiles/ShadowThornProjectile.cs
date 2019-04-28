using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SniperExtensions.Items.Ammo;

namespace SniperExtensions.Projectiles
{
    class ShadowThornProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.Name = "Shadow Thorn";
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 900;
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
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(1f, 1f, 1f, 1f);
        }
    }
}
