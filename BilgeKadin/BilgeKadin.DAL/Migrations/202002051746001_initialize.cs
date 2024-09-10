namespace BilgeKadin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Aciklama = c.String(),
                        Saat = c.Int(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        Telefon = c.String(),
                        Cinsiyet = c.Boolean(nullable: false),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SinifDers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ders_Id = c.Int(),
                        Ogretmen_Id = c.Int(),
                        Seans_Id = c.Int(),
                        Sinif_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ders", t => t.Ders_Id)
                .ForeignKey("dbo.Ogretmen", t => t.Ogretmen_Id)
                .ForeignKey("dbo.Seans", t => t.Seans_Id)
                .ForeignKey("dbo.Sinifs", t => t.Sinif_Id)
                .Index(t => t.Ders_Id)
                .Index(t => t.Ogretmen_Id)
                .Index(t => t.Seans_Id)
                .Index(t => t.Sinif_Id);
            
            CreateTable(
                "dbo.Ogretmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        DogumTarihi = c.DateTime(nullable: false),
                        Cinsiyet = c.Boolean(nullable: false),
                        Mail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Seans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Gunler = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sinifs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Kontenjan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OgrenciDers",
                c => new
                    {
                        Ogrenci_Id = c.Int(nullable: false),
                        Ders_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ogrenci_Id, t.Ders_Id })
                .ForeignKey("dbo.Ogrencis", t => t.Ogrenci_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ders", t => t.Ders_Id, cascadeDelete: true)
                .Index(t => t.Ogrenci_Id)
                .Index(t => t.Ders_Id);
            
            CreateTable(
                "dbo.SinifDersOgrencis",
                c => new
                    {
                        SinifDers_Id = c.Int(nullable: false),
                        Ogrenci_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SinifDers_Id, t.Ogrenci_Id })
                .ForeignKey("dbo.SinifDers", t => t.SinifDers_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ogrencis", t => t.Ogrenci_Id, cascadeDelete: true)
                .Index(t => t.SinifDers_Id)
                .Index(t => t.Ogrenci_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinifDers", "Sinif_Id", "dbo.Sinifs");
            DropForeignKey("dbo.SinifDers", "Seans_Id", "dbo.Seans");
            DropForeignKey("dbo.SinifDers", "Ogretmen_Id", "dbo.Ogretmen");
            DropForeignKey("dbo.SinifDersOgrencis", "Ogrenci_Id", "dbo.Ogrencis");
            DropForeignKey("dbo.SinifDersOgrencis", "SinifDers_Id", "dbo.SinifDers");
            DropForeignKey("dbo.SinifDers", "Ders_Id", "dbo.Ders");
            DropForeignKey("dbo.OgrenciDers", "Ders_Id", "dbo.Ders");
            DropForeignKey("dbo.OgrenciDers", "Ogrenci_Id", "dbo.Ogrencis");
            DropIndex("dbo.SinifDersOgrencis", new[] { "Ogrenci_Id" });
            DropIndex("dbo.SinifDersOgrencis", new[] { "SinifDers_Id" });
            DropIndex("dbo.OgrenciDers", new[] { "Ders_Id" });
            DropIndex("dbo.OgrenciDers", new[] { "Ogrenci_Id" });
            DropIndex("dbo.SinifDers", new[] { "Sinif_Id" });
            DropIndex("dbo.SinifDers", new[] { "Seans_Id" });
            DropIndex("dbo.SinifDers", new[] { "Ogretmen_Id" });
            DropIndex("dbo.SinifDers", new[] { "Ders_Id" });
            DropTable("dbo.SinifDersOgrencis");
            DropTable("dbo.OgrenciDers");
            DropTable("dbo.Sinifs");
            DropTable("dbo.Seans");
            DropTable("dbo.Ogretmen");
            DropTable("dbo.SinifDers");
            DropTable("dbo.Ogrencis");
            DropTable("dbo.Ders");
        }
    }
}
