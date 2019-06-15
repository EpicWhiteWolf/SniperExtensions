using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Accessories
{
    [AutoloadEquip(EquipType.Back)]
	public class ArchitectsMiningGear : ModItem
    {
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Architect's Mining Gear");
			Tooltip.SetDefault("Tile and wall placement speed greatly increased" 
                + "\nMining speed greatly increased"
                + "\nAutomatically paints placed objects"
                + "\nProvides light when worn"
                + "\n+1 range");
		}
		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
            item.value = Item.sellPrice(0, 5, 0, 0);
			item.rare = 6;
            item.accessory = true;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.tileSpeed *= 4;
            player.pickSpeed -= 10;
            player.wallSpeed += 10;
            player.autoPaint = true;

            if (player.whoAmI == Main.myPlayer)
            {
                Player.tileRangeX += 3;
                Player.tileRangeY += 2;
                Lighting.AddLight(player.Center, 1f, 1f, 1f);
            }

            WolfsPlayer p = player.GetModPlayer<WolfsPlayer>();
            p.amgAccessory = true;

            if (hideVisual)
            {
                p.amgHideVanity = true;
            }
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ArchitectGizmoPack);
            recipe.AddIngredient(ItemID.MiningHelmet);
            recipe.AddIngredient(ItemID.MiningShirt);
            recipe.AddIngredient(ItemID.MiningPants);
            recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }

    public class AMGHead : EquipTexture
    {
        public override bool DrawHead()
        {
            return true;
        }
    }

    public class AMGBody : EquipTexture
    {
        public override bool DrawBody()
        {
            return true;
        }
    }

    public class AMGLegs : EquipTexture
    {
        public override bool DrawLegs()
        {
            return true;
        }
    }
}
