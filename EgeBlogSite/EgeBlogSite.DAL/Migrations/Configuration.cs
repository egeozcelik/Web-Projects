namespace EgeBlogSite.DAL.Migrations
{
    using EgeBlogSite.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EgeBlogSite.DAL.BlogSiteEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EgeBlogSite.DAL.BlogSiteEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            BlogSiteEntities db = new BlogSiteEntities();
            var categories = new List<Category>()
            {
                new Category{Name="Sağlık" },
                new Category{Name="Eğlence" },
                new Category{Name="Spor" },
                new Category{Name="Teknoloji" },
                new Category{Name="Magazin" },
                new Category{Name="Gündem" },
                new Category{Name="Siyaset" },
                new Category{Name="Tarih" },
            };


            context.Categories.AddRange(categories);

            
        }
    }
}
