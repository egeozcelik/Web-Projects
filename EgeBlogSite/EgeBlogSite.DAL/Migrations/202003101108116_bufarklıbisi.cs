namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bufarklıbisi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropColumn("dbo.Articles", "CategoryId");
        }
    }
}
