using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BilgeKoleji.Model
{
    public class Ogrenci : Entity<int>
    {
        public int Numara { get; set; }
        public string  Adi{ get; set; }
        public string Soyadi { get; set; }
        public string Cinsiyet { get; set; }
        public int Yas { get; set; }
        public bool? DevamDurumu{ get; set; }
        public string TCK { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }



        [ForeignKey("Sinif")]
        public Nullable<int> SinifId { get; set; }
        public virtual Sinif Sinif { get; set; }

    }
}
