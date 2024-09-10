using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Model
{
   public class Sinif : Entity<int>
    {
        public Sinif()
        {
            Dersler = new HashSet<Ders>();
            Ogrenciler = new HashSet<Ogrenci>();
     
        }
        public string Adi { get; set; }
       public virtual ICollection<Ders> Dersler{ get; set; }
       public virtual ICollection<Ogrenci> Ogrenciler{ get; set; }
        public int Kontenjan { get; set; }
    }
}
