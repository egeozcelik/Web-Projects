using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.Entity
{
    public class Ogretmen
    {
        public Ogretmen()
        {
            SinifDers = new HashSet<SinifDers>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public bool Cinsiyet { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<SinifDers> SinifDers { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
