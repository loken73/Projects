namespace InTheFridge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecipeIngredientChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "Recipe_RecipeId" });
            AddColumn("dbo.Recipes", "RecipeIngredients", c => c.String());
            DropColumn("dbo.Ingredients", "Recipe_RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Recipe_RecipeId", c => c.Int());
            DropColumn("dbo.Recipes", "RecipeIngredients");
            CreateIndex("dbo.Ingredients", "Recipe_RecipeId");
            AddForeignKey("dbo.Ingredients", "Recipe_RecipeId", "dbo.Recipes", "RecipeId");
        }
    }
}
