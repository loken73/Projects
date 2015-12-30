namespace InTheFridge.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Meal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Meal");
        }
    }
}
