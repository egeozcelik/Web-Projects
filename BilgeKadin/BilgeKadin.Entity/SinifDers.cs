using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.Entity
{
    public class SinifDers
    {
        public SinifDers()
        {
            Ogrencis = new HashSet<Ogrenci>();
        }
        public int Id { get; set; }

        [ForeignKey("Ders")]
        public int DersId { get; set; }
        public virtual Ders Ders { get; set; }

      
        [ForeignKey("Ogretmen")]
        public int OgretmenId { get; set; }
        public virtual Ogretmen Ogretmen { get; set; }
        public virtual Seans Seans { get; set; }
        public virtual Sinif Sinif { get; set; }
        public virtual ICollection<Ogrenci> Ogrencis { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }


    }

    
}
