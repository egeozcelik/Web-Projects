using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.Entity
{
    public class Ders
    {
        public Ders()
        {
            SinifDers = new HashSet<SinifDers>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int Saat { get; set; }
        public bool Aktif { get; set; }
        public virtual ICollection<SinifDers> SinifDers { get; set; }
        public override string ToString()
        {
            return Adi;
        }
    }
}
