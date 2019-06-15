using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions
{
    class WolfsPlayer : ModPlayer
    {
        public bool amgAccessoryPrevious;
        public bool amgAccessory;
        public bool amgHideVanity;
        public bool amgForceVanity;
        public bool amgVisual;
        public bool accHolyGrail;

        public override void ResetEffects()
        {
            accHolyGrail = false;
            amgAccessoryPrevious = amgAccessory;
            amgAccessory = amgHideVanity = amgForceVanity = amgVisual = false;
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (amgAccessory)
            {
                player.AddBuff(mod.BuffType<Buffs.AMG>(), 60, true);
            }
        }

        public override void FrameEffects()
        {
            if ((amgVisual || amgForceVanity) && !amgHideVanity)
            {
                player.legs = mod.GetEquipSlot("AMGLegs", EquipType.Legs);
                player.body = mod.GetEquipSlot("AMGBody", EquipType.Body);
                player.head = mod.GetEquipSlot("AMGHead", EquipType.Head);
            }
        }
    }
}
