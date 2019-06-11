using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class GhillieHood : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.SetDefaults();
            DisplayName.SetDefault("Ghillie Hood");
			Tooltip.SetDefault("10% increased ranged crit chance");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 14, 0);
            item.rare = 1;
			item.defense = 1;
		}

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 10;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("GhillieJacket") && legs.type == mod.ItemType("GhilliePants");
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "15% increased ranged damage";
            player.rangedDamage *= 1.15f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 7);
            recipe.AddIngredient(ItemID.LivingLeafWall, 8);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}