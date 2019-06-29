using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    class FireProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.timeLeft = 80;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.ranged = true;
            projectile.aiStyle = 0;
            projectile.hide = true;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            Vector2 randVect = new Vector2(Main.rand.Next(-7, 7), Main.rand.Next(-7, 7));
            int dustnumber = Dust.NewDust(projectile.position + randVect, projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 2f);
            Main.dust[dustnumber].noGravity = true;
            Main.dust[dustnumber].velocity = projectile.velocity * 0.25f;
            if (Main.rand.Next(100) == 0)
            {
                int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X,
                    5, mod.ProjectileType("EmberProjectile"), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 240);
        }
    }
}
