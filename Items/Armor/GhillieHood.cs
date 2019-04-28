using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Armor
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
			item.value = Item.buyPrice(0, 0, 1, 0);
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
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddIngredient(ItemID.Hay, 4);
            recipe.AddIngredient(ItemID.Cobweb, 4);
            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}