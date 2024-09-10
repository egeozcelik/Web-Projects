using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BilgeKoleji.Model
{
    public class Ogretmen : Entity<int>
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Yas { get; set; }
        public string Cinsiyet { get; set; }
        public string TCK { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        [ForeignKey("Ders")]
        public Nullable<int> DersId { get; set; }
        public virtual Ders Ders { get; set; }
    }
}
