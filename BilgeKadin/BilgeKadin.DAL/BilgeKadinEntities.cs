using BilgeKadin.DAL.Migrations;
using BilgeKadin.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.DAL
{
    public class BilgeKadinEntities : DbContext
    {
        public BilgeKadinEntities() : base("name=BilgeKadinEntitiesConnection")
        {
            //Database.SetInitializer<BilgeKadinEntities>
            //    (new DropCreateDatabaseAlways<BilgeKadinEntities>());
            //Database.SetInitializer(
            //    new MigrateDatabaseToLatestVersion<BilgeKadinEntities, Configuration>());
        }

        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
        public DbSet<Seans> Seanslar { get; set; }
        public DbSet<Sinif> Sinifs { get; set; }
        public DbSet<Gun> Gunler { get; set; }
        public DbSet<SinifDers> SinifDersler { get; set; }
    }
}
