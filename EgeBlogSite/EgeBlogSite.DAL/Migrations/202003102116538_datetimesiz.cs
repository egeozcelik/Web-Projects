namespace EgeBlogSite.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimesiz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Articles", "Date");
            DropColumn("dbo.Users", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Articles", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
    }
}
