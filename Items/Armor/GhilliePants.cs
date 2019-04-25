using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class GhilliePants : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Ghillie Pants");
            Tooltip.SetDefault("10% increased movement speed");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 0, 1, 0);
            item.rare = 0;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
            player.moveSpeed *= 1.1f;
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