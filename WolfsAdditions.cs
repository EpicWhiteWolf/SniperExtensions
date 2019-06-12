using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WolfsAdditions
{
	class WolfsAdditions : Mod
	{
        internal static WolfsAdditions instance;

        public WolfsAdditions()
		{

		}

        public override void Load()
        {
            if (!Main.dedServ)
            {
                AddEquipTexture(new Items.Accessories.AMGHead(), null, EquipType.Head, "AMGHead", "WolfsAdditions/Items/Accessories/ArchitectsMiningGear_Head");
                AddEquipTexture(new Items.Accessories.AMGBody(), null, EquipType.Body, "AMGBody", "WolfsAdditions/Items/Accessories/ArchitectsMiningGear_Body", "WolfsAdditions/Items/Accessories/ArchitectsMiningGear_Arms", "WolfsAdditions/Items/Accessories/ArchitectsMiningGear_FemaleBody");
                AddEquipTexture(new Items.Accessories.AMGLegs(), null, EquipType.Legs, "AMGLegs", "WolfsAdditions/Items/Accessories/ArchitectsMiningGear_Legs");
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(this, "AncientArtifact");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.SandstorminaBottle);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.EnchantedSword);
            recipe.AddIngredient(ItemID.FeralClaws);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Arkhalis);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Silk, 15);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.MiningShirt);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Silk, 12);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(ItemID.MiningPants);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.GoldBar, 2);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.FlyingCarpet);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(ItemID.FrozenTurtleShell);
            recipe.AddRecipe();

            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SlimeBlock);
            recipe.AddRecipeGroup("Wood", 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.SlimeStaff);
            recipe.AddRecipe();
        }
    }
}
