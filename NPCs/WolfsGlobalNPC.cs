using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.NPCs
{
    public class WolfsGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool boneBolt = false;
        public bool lacerations = false;
        public bool marked = false;
        public bool deepChill = false;

        public override void ResetEffects(NPC npc)
        {
            boneBolt = false;
            lacerations = false;
            marked = false;
            deepChill = false;
        }

        public override void SetDefaults(NPC npc)
        {
            npc.buffImmune[mod.BuffType<Buffs.BoneBoltDebuff>()] = npc.buffImmune[BuffID.BoneJavelin];
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (boneBolt)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int boneBoltCount = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Projectile p = Main.projectile[i];
                    if (p.active && p.type == mod.ProjectileType<Projectiles.BoneBoltProjectile>() && p.ai[0] == 1f && p.ai[1] == npc.whoAmI)
                    {
                        boneBoltCount++;
                    }
                }
                npc.lifeRegen -= boneBoltCount * 2 * 3;
                if (damage < boneBoltCount * 3)
                {
                    damage = boneBoltCount * 3;
                }
            }
            if (lacerations)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 100;
                if (damage < 5)
                {
                    damage = 5;
                }
            }
        }

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.Mimic)
            {
                if (Main.rand.Next(6) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HolyGrail"));
                }
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (marked)
            {
                drawColor = new Color(1f, 0.3f, 0.3f, 1f);
            }

            if (deepChill)
            {
                drawColor = new Color(0.33f, 0.66f, 1f, 1f);
            }
        }

        public override void AI(NPC npc)
        {
            if (deepChill)
            {
                if (npc.aiStyle == 1 || npc.aiStyle == 3 || npc.aiStyle == 15 || npc.aiStyle == 19 || npc.aiStyle == 25 || npc.aiStyle == 26 || npc.aiStyle == 38)
                {
                    npc.velocity.X *= 0.9f;
                }
                else
                {
                    npc.velocity *= 0.9f;
                }
            }
        }
    }
}
