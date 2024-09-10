namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeysiz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "Category_Id", c => c.Int());
            CreateIndex("dbo.Articles", "Category_Id");
            AddForeignKey("dbo.Articles", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Articles", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Category", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            DropColumn("dbo.Articles", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
