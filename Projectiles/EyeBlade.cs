using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    class EyeBlade : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eye Blade");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.scale = 1.3f;
            projectile.alpha = 0;
            drawOffsetX = -6;
            drawOriginOffsetY = -6;
            
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
        }

        public bool spawned;
        
        public override void AI()
        {
            Vector2 between = projectile.Center - Main.player[projectile.owner].Center;
            Vector2 between2 = Main.player[projectile.owner].Center - projectile.Center;
            projectile.rotation = (float)Math.Atan2(between.Y, between.X) + MathHelper.ToRadians(135f);

            Vector2 dustCenter = (projectile.Center - between.SafeNormalize(Vector2.UnitX) * 16f) - new Vector2(4, 4);
            Vector2 dustSpread = new Vector2(Main.rand.Next(-2, 2), Main.rand.Next(-2, 2));
            for (int d = 0; d < 2; d++)
            {
                Dust.NewDust(dustCenter + dustSpread, 0, 0, mod.DustType("BloodDust"), 0, 10);
            }

            if (!spawned)
            {
                Main.PlaySound(SoundID.Item1, projectile.position);
                spawned = true;
            }

            if (Main.myPlayer == projectile.owner && projectile.ai[0] == 0f)
            {
                Player player = Main.player[projectile.owner];
                Vector2 vectorToPlayer = player.Center - projectile.Center;
                float distanceToPlayer = vectorToPlayer.Length();

                if (player.channel)
                {
                    projectile.tileCollide = true;
                    float maxDistance = 18f;
                    Vector2 vectorToCursor = Main.MouseWorld - projectile.Center;
                    float distanceToCursor = vectorToCursor.Length();

                    if (distanceToPlayer >= 1500)
                    {
                        projectile.Kill();
                    }

                    if (distanceToCursor > maxDistance)
                    {
                        distanceToCursor = maxDistance / distanceToCursor;
                        vectorToCursor *= distanceToCursor;
                    }

                    int velocityXBy1000 = (int)(vectorToCursor.X * 1000f);
                    int oldVelocityXBy1000 = (int)(projectile.velocity.X * 1000f);
                    int velocityYBy1000 = (int)(vectorToCursor.Y * 1000f);
                    int oldVelocityYBy1000 = (int)(projectile.velocity.Y * 1000f);
                    
                    if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                    {
                        projectile.netUpdate = true;
                    }

                    projectile.velocity = vectorToCursor;
                }

                else
                {
                    projectile.tileCollide = false;
                    float maxDistance = 18f;

                    if (distanceToPlayer <= 25 || distanceToPlayer >= 1500)
                    {
                        projectile.Kill();
                    }

                    distanceToPlayer = maxDistance / distanceToPlayer;
                    vectorToPlayer *= distanceToPlayer;

                    int velocityXBy1000 = (int)(vectorToPlayer.X * 1000f);
                    int oldVelocityXBy1000 = (int)(projectile.velocity.X * 1000f);
                    int velocityYBy1000 = (int)(vectorToPlayer.Y * 1000f);
                    int oldVelocityYBy1000 = (int)(projectile.velocity.Y * 1000f);

                    if (velocityXBy1000 != oldVelocityXBy1000 || velocityYBy1000 != oldVelocityYBy1000)
                    {
                        projectile.netUpdate = true;
                    }

                    projectile.velocity = vectorToPlayer;
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
