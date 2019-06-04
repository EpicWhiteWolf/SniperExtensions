using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items
{
    [AutoloadEquip(EquipType.HandsOn)]
	public class ServoAssists : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Servo Assists");
			Tooltip.SetDefault("Precision.");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = 10000;
			item.rare = 2;
            item.accessory = true;
		}

        public override void UpdateEquip(Player player)
        {
            player.tileSpeed *= 4;
            player.pickSpeed -= 10;
            player.wallSpeed += 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Player.tileRangeX += 5;
                Player.tileRangeY += 5;
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wire, 10);
            recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
