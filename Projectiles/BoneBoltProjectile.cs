using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace WolfsAdditions.Projectiles
{
    public class BoneBoltProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bone Bolt");
        }

        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 18;
            projectile.timeLeft = 960;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.ranged = true;
            projectile.aiStyle = 0;
            projectile.hide = true;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Lighting.GetColor((int)projectile.Center.X / 16, (int)projectile.Center.Y / 16);
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            if (isStickingToTarget)
            {
                int npcIndex = (int)projectile.ai[1];
                if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
                {
                    if (Main.npc[npcIndex].behindTiles)
                        drawCacheProjsBehindNPCsAndTiles.Add(index);
                    else
                        drawCacheProjsBehindNPCs.Add(index);
                    return;
                }
            }
            drawCacheProjsBehindProjectiles.Add(index);
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = height = 10;
            return true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
            {
                targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
            }
            return projHitbox.Intersects(targetHitbox);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
            Vector2 usePos = projectile.position;
            Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
            usePos += rotVector * 16f;
        }

        public bool isStickingToTarget
        {
            get { return projectile.ai[0] == 1f; }
            set { projectile.ai[0] = value ? 1f : 0f; }
        }
        
        public float targetWhoAmI
        {
            get { return projectile.ai[1]; }
            set { projectile.ai[1] = value; }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            isStickingToTarget = true;
            targetWhoAmI = (float)target.whoAmI;
            projectile.velocity = (target.Center - projectile.Center) * 0.75f;
            projectile.netUpdate = true;
            target.AddBuff(mod.BuffType<Buffs.BoneBoltDebuff>(), 960);
            projectile.damage = 0;
            int maxStickingBolts = 15;
            Point[] stickingBolts = new Point[maxStickingBolts];
            int boltIndex = 0;
            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile currentProjectile = Main.projectile[i];
                if (i != projectile.whoAmI
                    && currentProjectile.active
                    && currentProjectile.owner == Main.myPlayer
                    && currentProjectile.type == projectile.type
                    && currentProjectile.ai[0] == 1f
                    && currentProjectile.ai[1] == (float)target.whoAmI)
                {
                    stickingBolts[boltIndex++] = new Point(i, currentProjectile.timeLeft);
                    if (boltIndex >= stickingBolts.Length)
                    {
                        break;
                    }
                }
            }
            if (boltIndex >= stickingBolts.Length)
            {
                int oldBoltIndex = 0;
                for (int i = 1; i < stickingBolts.Length; i++)
                {
                    if (stickingBolts[i].Y < stickingBolts[oldBoltIndex].Y)
                    {
                        oldBoltIndex = i;
                    }
                }
                Main.projectile[stickingBolts[oldBoltIndex].X].Kill();
            }
        }

        private const float maxTicks = 45f;

        public override void AI()
        {
            if (!isStickingToTarget)
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
            }
            if (isStickingToTarget)
            {
                projectile.ignoreWater = true;
                projectile.tileCollide = false;
                int aiFactor = 15;
                bool killProj = false;
                bool hitEffect = false;
                projectile.localAI[0] += 1f;
                hitEffect = projectile.localAI[0] % 30f == 0f;
                int projTargetIndex = (int)targetWhoAmI;
                if (projectile.localAI[0] >= (float)(60 * aiFactor) || (projTargetIndex < 0 || projTargetIndex >= 200))
                {
                    killProj = true;
                }
                else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage)
                {
                    projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
                    projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
                    if (hitEffect)
                    {
                        Main.npc[projTargetIndex].HitEffect(0, 1.0);
                    }
                }
                else
                {
                    killProj = true;
                }
                if (killProj)
                {
                    projectile.Kill();
                }
            }
        }
    }
}
