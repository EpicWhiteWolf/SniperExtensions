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
