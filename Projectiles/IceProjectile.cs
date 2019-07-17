using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    class IceProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icicle");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.timeLeft = 30;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.aiStyle = 0;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0f, 0.25f, 1f);
            Color glow = new Color(1f, 1f, 1f, 1f);
            GetAlpha(glow);
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[dustnumber].noGravity = true;
        }

        public override void Kill(int timeLeft)
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 67, 0f, 0f, 100, default(Color), 1.2f);
            Main.PlaySound(SoundID.Item27, projectile.position);
        }

        public override bool PreKill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 projSpread = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.ToRadians((10 * i) - 10));
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y - 4, projSpread.X, projSpread.Y, mod.ProjectileType("IceShardProj"), projectile.damage, projectile.knockBack, projectile.owner);
            }
            return true;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            target.AddBuff(mod.BuffType<Buffs.FrostedDebuff>(), 480);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            return true;
        }
    }
}
