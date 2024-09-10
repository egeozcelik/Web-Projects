namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salamıyorum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "User_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "User_Id" });
            RenameColumn(table: "dbo.Articles", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "UserId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "UserId" });
            AlterColumn("dbo.Articles", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Articles", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Articles", "User_Id");
            AddForeignKey("dbo.Articles", "User_Id", "dbo.Users", "Id");
        }
    }
}
