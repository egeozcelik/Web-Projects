namespace BilgeKadin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeansandDers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SeansGuns",
                c => new
                    {
                        Seans_Id = c.Int(nullable: false),
                        Gun_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seans_Id, t.Gun_Id })
                .ForeignKey("dbo.Seans", t => t.Seans_Id, cascadeDelete: true)
                .ForeignKey("dbo.Guns", t => t.Gun_Id, cascadeDelete: true)
                .Index(t => t.Seans_Id)
                .Index(t => t.Gun_Id);
            
            DropColumn("dbo.Seans", "Gunler");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seans", "Gunler", c => c.String());
            DropForeignKey("dbo.SeansGuns", "Gun_Id", "dbo.Guns");
            DropForeignKey("dbo.SeansGuns", "Seans_Id", "dbo.Seans");
            DropIndex("dbo.SeansGuns", new[] { "Gun_Id" });
            DropIndex("dbo.SeansGuns", new[] { "Seans_Id" });
            DropTable("dbo.SeansGuns");
        }
    }
}
