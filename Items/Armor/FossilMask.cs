﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FossilMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetDefaults();
            DisplayName.SetDefault("Fossil Mask");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 1;
            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FossilPlatemail") && legs.type == mod.ItemType("FossilLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "5% increased crit chance";
            player.rangedDamage += 5;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FossilOre, 12);
            recipe.AddIngredient(ItemID.Chain, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
