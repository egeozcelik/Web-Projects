namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SonHal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Articles", "Author_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "Author_Id" });
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Articles", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Articles", name: "Author_Id", newName: "UserId");
            AlterColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "UserId");
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Articles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            AlterColumn("dbo.Articles", "CategoryId", c => c.Int());
            AlterColumn("dbo.Articles", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Articles", name: "UserId", newName: "Author_Id");
            RenameColumn(table: "dbo.Articles", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Articles", "Category_Id");
            CreateIndex("dbo.Articles", "Author_Id");
            AddForeignKey("dbo.Articles", "Author_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
