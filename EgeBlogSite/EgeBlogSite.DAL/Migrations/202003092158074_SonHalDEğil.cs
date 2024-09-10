namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SonHalDEğil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Articles", name: "CategoryId", newName: "Category_Id");
            AlterColumn("dbo.Articles", "Category_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            AlterColumn("dbo.Articles", "Category_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Articles", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
