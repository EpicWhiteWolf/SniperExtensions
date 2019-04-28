using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class GhillieJacket : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Ghillie Jacket");
			Tooltip.SetDefault("10% increased bullet damage");

        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 1, 0);
            item.rare = 1;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
            player.bulletDamage *= 1.1f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 6);
            recipe.AddIngredient(ItemID.Hay, 6);
            recipe.AddIngredient(ItemID.Cobweb, 6);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}