using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FossilPlatemail : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetDefaults();
            DisplayName.SetDefault("Fossil Platemail");
            Tooltip.SetDefault("15% increased bullet damage");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.rare = 1;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.bulletDamage *= 1.15f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FossilOre, 18);
            recipe.AddIngredient(ItemID.Chain, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
