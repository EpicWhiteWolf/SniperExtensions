using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SniperExtensions.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MoltenLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Molten Leggings");
            Tooltip.SetDefault("20% increased movement speed");
        }

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 3;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.2f;
		}

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}