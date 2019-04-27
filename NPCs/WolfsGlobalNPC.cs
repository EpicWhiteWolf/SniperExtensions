﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.NPCs
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

        public override void ResetEffects(NPC npc)
        {
            boneBolt = false;
        }

        public override void SetDefaults(NPC npc)
        {
            npc.buffImmune[mod.BuffType<Buffs.BoneBolt>()] = npc.buffImmune[BuffID.BoneJavelin];
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
        }
    }
}