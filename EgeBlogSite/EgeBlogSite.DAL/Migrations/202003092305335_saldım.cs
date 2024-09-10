namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saldım : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            DropColumn("dbo.Articles", "Category_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Category_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
