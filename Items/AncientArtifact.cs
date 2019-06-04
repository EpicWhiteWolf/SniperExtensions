using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions.Items
{
    class AncientArtifact : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Artifact");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sandstone, 10);
            recipe.AddIngredient(ItemID.FossilOre, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
