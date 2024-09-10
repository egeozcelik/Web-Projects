using BilgeKoleji.Model;
using LinqToDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace BilgeKoleji.DAL
{
    public class BilgeKolejiDbContext : DbContext
    {

        //      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //      {
        //          optionsBuilder.UseSqlServer("Server=.;Database=BilgeKoleji;Trusted_Connection=true");
        // 
        //          base.OnConfiguring(optionsBuilder);
        //       }

    public BilgeKolejiDbContext(DbContextOptions<BilgeKolejiDbContext> options)
                 : base(options)
             {
           
             }
        public DbSet<Ders> Ders { get; set; }
        public DbSet<Sinif> Sinifs { get; set; }
        public DbSet<Ogretmen> Ogretmens { get; set; }
        public DbSet<Ogrenci> Ogrencis { get; set; }
        public DbSet<GenelTablo> GenelTablos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
