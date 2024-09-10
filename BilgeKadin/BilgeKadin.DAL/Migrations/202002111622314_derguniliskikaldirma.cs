namespace BilgeKadin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class derguniliskikaldirma : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SeansGuns", newName: "GunSeans");
            DropForeignKey("dbo.GunDers", "Gun_Id", "dbo.Guns");
            DropForeignKey("dbo.GunDers", "Ders_Id", "dbo.Ders");
            DropIndex("dbo.GunDers", new[] { "Gun_Id" });
            DropIndex("dbo.GunDers", new[] { "Ders_Id" });
            DropPrimaryKey("dbo.GunSeans");
            AddPrimaryKey("dbo.GunSeans", new[] { "Gun_Id", "Seans_Id" });
            DropTable("dbo.GunDers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GunDers",
                c => new
                    {
                        Gun_Id = c.Int(nullable: false),
                        Ders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gun_Id, t.Ders_Id });
            
            DropPrimaryKey("dbo.GunSeans");
            AddPrimaryKey("dbo.GunSeans", new[] { "Seans_Id", "Gun_Id" });
            CreateIndex("dbo.GunDers", "Ders_Id");
            CreateIndex("dbo.GunDers", "Gun_Id");
            AddForeignKey("dbo.GunDers", "Ders_Id", "dbo.Ders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GunDers", "Gun_Id", "dbo.Guns", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.GunSeans", newName: "SeansGuns");
        }
    }
}
