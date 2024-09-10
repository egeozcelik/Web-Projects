using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml;

namespace BilgeKoleji.Model
{
    public class Ders : Entity<int>
    {
        public Ders()
        {
            Ogretmenler = new HashSet<Ogretmen>();
        }
        public string Adi { get; set; }
       
        [ForeignKey("Sinif")]
        public int SinifId { get; set; }
        public Sinif Sinif { get; set; }
        public virtual ICollection<Ogretmen> Ogretmenler{ get; set; }
    }
    public enum Kod{
        ANGE1,
        BILG1,
        BILTA1,
        BIY1,
        BIY2,
        BIY3,
        BIYU,
        COG1,
        DEM1,
        DKAB1,
        DKAB2
    }
}
