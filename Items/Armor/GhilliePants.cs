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
			item.value = Item.sellPrice(0, 0, 16, 0);
            item.rare = 1;
			item.defense = 1;
		}

		public override void UpdateEquip(Player player)
		{
            player.moveSpeed *= 1.1f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 8);
            recipe.AddIngredient(ItemID.GrassWall, 8);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}