namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class budadegilbence : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "UserId", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "UserId" });
            RenameColumn(table: "dbo.Articles", name: "UserId", newName: "User_Id");
            AlterColumn("dbo.Articles", "User_Id", c => c.Int());
            CreateIndex("dbo.Articles", "User_Id");
            AddForeignKey("dbo.Articles", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "User_Id", "dbo.Users");
            DropIndex("dbo.Articles", new[] { "User_Id" });
            AlterColumn("dbo.Articles", "User_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Articles", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.Articles", "UserId");
            AddForeignKey("dbo.Articles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
