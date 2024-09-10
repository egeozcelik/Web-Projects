namespace BilgeKadin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SinifDersOgrencis", newName: "OgrenciSinifDers");
            DropForeignKey("dbo.OgrenciDers", "Ogrenci_Id", "dbo.Ogrencis");
            DropForeignKey("dbo.OgrenciDers", "Ders_Id", "dbo.Ders");
            DropIndex("dbo.OgrenciDers", new[] { "Ogrenci_Id" });
            DropIndex("dbo.OgrenciDers", new[] { "Ders_Id" });
            DropPrimaryKey("dbo.OgrenciSinifDers");
            AddPrimaryKey("dbo.OgrenciSinifDers", new[] { "Ogrenci_Id", "SinifDers_Id" });
            DropTable("dbo.OgrenciDers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OgrenciDers",
                c => new
                    {
                        Ogrenci_Id = c.Int(nullable: false),
                        Ders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ogrenci_Id, t.Ders_Id });
            
            DropPrimaryKey("dbo.OgrenciSinifDers");
            AddPrimaryKey("dbo.OgrenciSinifDers", new[] { "SinifDers_Id", "Ogrenci_Id" });
            CreateIndex("dbo.OgrenciDers", "Ders_Id");
            CreateIndex("dbo.OgrenciDers", "Ogrenci_Id");
            AddForeignKey("dbo.OgrenciDers", "Ders_Id", "dbo.Ders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OgrenciDers", "Ogrenci_Id", "dbo.Ogrencis", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.OgrenciSinifDers", newName: "SinifDersOgrencis");
        }
    }
}
