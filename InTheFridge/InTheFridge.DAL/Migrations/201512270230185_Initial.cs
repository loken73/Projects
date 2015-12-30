namespace InTheFridge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        IngredientId = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        IngredientDescription = c.String(),
                        IngredientCalories = c.Int(nullable: false),
                        IngredientImage = c.String(),
                        IngredientType = c.String(),
                        Recipe_RecipeId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientId)
                .ForeignKey("dbo.Recipes", t => t.Recipe_RecipeId)
                .Index(t => t.Recipe_RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        RecipeId = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        RecipeDescription = c.String(),
                        Directions = c.String(),
                        RecipeImage = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "Recipe_RecipeId" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
