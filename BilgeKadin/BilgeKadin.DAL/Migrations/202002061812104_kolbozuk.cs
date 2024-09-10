namespace BilgeKadin.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kolbozuk : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ogrencis", "DogumTarihi", c => c.DateTime());
            AlterColumn("dbo.Ogretmen", "DogumTarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ogretmen", "DogumTarihi", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Ogrencis", "DogumTarihi", c => c.DateTime(nullable: false));
        }
    }
}
