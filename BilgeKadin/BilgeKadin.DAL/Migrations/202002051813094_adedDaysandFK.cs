namespace BilgeKadin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adedDaysandFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SinifDers", "Ders_Id", "dbo.Ders");
            DropForeignKey("dbo.SinifDers", "Ogretmen_Id", "dbo.Ogretmen");
            DropIndex("dbo.SinifDers", new[] { "Ders_Id" });
            DropIndex("dbo.SinifDers", new[] { "Ogretmen_Id" });
            RenameColumn(table: "dbo.SinifDers", name: "Ders_Id", newName: "DersId");
            RenameColumn(table: "dbo.SinifDers", name: "Ogretmen_Id", newName: "OgretmenId");
            CreateTable(
                "dbo.Guns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GunDers",
                c => new
                    {
                        Gun_Id = c.Int(nullable: false),
                        Ders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gun_Id, t.Ders_Id })
                .ForeignKey("dbo.Guns", t => t.Gun_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_Id, cascadeDelete: true)
                .Index(t => t.Gun_Id)
                .Index(t => t.Ders_Id);
            
            AlterColumn("dbo.SinifDers", "DersId", c => c.Int(nullable: false));
            AlterColumn("dbo.SinifDers", "OgretmenId", c => c.Int(nullable: false));
            CreateIndex("dbo.SinifDers", "DersId");
            CreateIndex("dbo.SinifDers", "OgretmenId");
            AddForeignKey("dbo.SinifDers", "DersId", "dbo.Ders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SinifDers", "OgretmenId", "dbo.Ogretmen", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinifDers", "OgretmenId", "dbo.Ogretmen");
            DropForeignKey("dbo.SinifDers", "DersId", "dbo.Ders");
            DropForeignKey("dbo.GunDers", "Ders_Id", "dbo.Ders");
            DropForeignKey("dbo.GunDers", "Gun_Id", "dbo.Guns");
            DropIndex("dbo.GunDers", new[] { "Ders_Id" });
            DropIndex("dbo.GunDers", new[] { "Gun_Id" });
            DropIndex("dbo.SinifDers", new[] { "OgretmenId" });
            DropIndex("dbo.SinifDers", new[] { "DersId" });
            AlterColumn("dbo.SinifDers", "OgretmenId", c => c.Int());
            AlterColumn("dbo.SinifDers", "DersId", c => c.Int());
            DropTable("dbo.GunDers");
            DropTable("dbo.Guns");
            RenameColumn(table: "dbo.SinifDers", name: "OgretmenId", newName: "Ogretmen_Id");
            RenameColumn(table: "dbo.SinifDers", name: "DersId", newName: "Ders_Id");
            CreateIndex("dbo.SinifDers", "Ogretmen_Id");
            CreateIndex("dbo.SinifDers", "Ders_Id");
            AddForeignKey("dbo.SinifDers", "Ogretmen_Id", "dbo.Ogretmen", "Id");
            AddForeignKey("dbo.SinifDers", "Ders_Id", "dbo.Ders", "Id");
        }
    }
}
