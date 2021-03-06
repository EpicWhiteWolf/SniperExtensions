using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GhillieJacket : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ghillie Jacket");
			Tooltip.SetDefault("5% increased ranged damage");

        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 0, 18, 0);
            item.rare = 1;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
            player.rangedDamage *= 1.05f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 9);
            recipe.AddIngredient(ItemID.LivingLeafWall, 8);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}