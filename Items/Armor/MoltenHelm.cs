using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MoltenHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.SetStaticDefaults();
            DisplayName.SetDefault("Molten Helm");
            Tooltip.SetDefault("15% increased ranged crit chance");
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
            player.rangedCrit += 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("MoltenJacket") && legs.type == mod.ItemType("MoltenLeggings");
		}

		public override void UpdateArmorSet(Player player)
		{
            player.setBonus = "25% increased ranged damage" + "\nImmunity to fire";
            player.rangedDamage *= 1.25f;
            player.buffImmune[BuffID.OnFire] = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}