namespace BilgeKadin.DAL.Migrations
{
    using BilgeKadin.Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BilgeKadin.DAL.BilgeKadinEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BilgeKadin.DAL.BilgeKadinEntities context)
        {
            List<Gun> gunler = new List<Gun>()
            {
                new Gun {Adi="Pazartesi"},
                new Gun {Adi="Salı"},
                new Gun {Adi="Çarşamba"},
                new Gun {Adi="Periembe"},
                new Gun {Adi="Cuma"},
                new Gun {Adi="Cumartesi"},
                new Gun {Adi="Pazar"}
            };
            context.Gunler.AddRange(gunler);

            List<Gun> ilkdort = context.Gunler.Where(z => z.Id < 5).ToList();
            List<Gun> haftasonu = context.Gunler.Where(z => z.Id > 5).ToList();

            List<Seans> seansLar = new List<Seans>()
            {
                new Seans{Adi = "1.Seans",Gunler=ilkdort},
                new Seans{Adi = "3.Seans",Gunler=ilkdort},
                new Seans{Adi = "4.Seans",Gunler = haftasonu},
                new Seans{Adi = "5.Seans",Gunler = haftasonu},
            };

            context.Seanslar.AddRange(seansLar);

            List<Ders> dersler = new List<Ders>()
            {
                new Ders { Adi = "Yazılım", Aciklama = "Yazar", Saat = 320, Aktif = true },
                new Ders { Adi = "Sistem", Aciklama = "Donatır", Saat = 300, Aktif = true },
                new Ders { Adi = "Grafik", Aciklama = "Çizer", Saat = 200, Aktif = true },
                new Ders { Adi = "Excel", Aciklama = "Ogretir", Saat = 150, Aktif = true }
            };

            context.Dersler.AddRange(dersler);

            List<Sinif> siniflar = new List<Sinif>()
            {
                new Sinif { Adi = "Lab A", Kontenjan =15},
                new Sinif { Adi = "Lab B", Kontenjan =15},
                new Sinif { Adi = "Lab C", Kontenjan =15},
                new Sinif { Adi = "Lab D", Kontenjan =15},
            };

            context.Sinifs.AddRange(siniflar);

            List<Ogretmen> ogretmenler = new List<Ogretmen>()
            {
                new Ogretmen {Adi = "Ahmet",
                             Soyadi = "Taş",
                             Cinsiyet = true,
                             DogumTarihi = new DateTime(1999,1,1)},

                new Ogretmen {Adi = "Mehmet",
                             Soyadi = "Taş",
                             Cinsiyet = true,
                             DogumTarihi = new DateTime(1999,2,2)},

                new Ogretmen {Adi = "Ayşe",
                Soyadi="Candan",
                Cinsiyet = false,
                DogumTarihi = new DateTime(1991,3,5)},

                new Ogretmen { Adi ="Cenk",
                Soyadi="Cengaver",
                Cinsiyet=true,
                DogumTarihi = new DateTime(1993,11,10)
                }

            };

            context.Ogretmens.AddRange(ogretmenler);

            List<Ogrenci> ogreciler = new List<Ogrenci>()
            {
                new Ogrenci {
                    Adi = "Ogrenci1",
                    Soyadi = "Soyad1",
                    Cinsiyet =false,
                    Mail ="ogrenci@mail.com"},
                 new Ogrenci {
                    Adi = "Ogrenci2",
                    Soyadi = "Soyad2",
                    Cinsiyet =false,
                    Mail ="ogrenci2@mail.com"},
                  new Ogrenci {
                    Adi = "Ogrenci3",
                    Soyadi = "Soyad3",
                    Cinsiyet =false,
                    Mail ="ogrenci3@mail.com"},
                   new Ogrenci {
                    Adi = "Ogrenci4",
                    Soyadi = "Soyad4",
                    Cinsiyet =false,
                    Mail ="ogrenci4@mail.com"},
                    new Ogrenci {
                    Adi = "Ogrenci5",
                    Soyadi = "Soyad5",
                    Cinsiyet =false,
                    Mail ="ogrenci5@mail.com"},
                     new Ogrenci {
                    Adi = "Ogrenci6",
                    Soyadi = "Soyad6",
                    Cinsiyet =false,
                    Mail ="ogrenci6@mail.com"},
            };

            context.Ogrencis.AddRange(ogreciler);

            base.Seed(context);
        }
    }
}
