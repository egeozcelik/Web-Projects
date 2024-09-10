using EgeBlogSite.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.DAL
{
    public  class BlogSiteEntities : DbContext
    {
        public BlogSiteEntities() : base("name=BlogSiteConnection")
        {

        }
        public virtual DbSet<User> Users{ get; set; }
        public virtual DbSet<Article> Articles{ get; set; }
        public virtual DbSet<Category> Categories{ get; set; }

    }
    
}
