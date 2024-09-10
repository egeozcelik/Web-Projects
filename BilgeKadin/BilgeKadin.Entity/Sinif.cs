using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.Entity
{
    public class Sinif
    {
        public Sinif()
        {
            SinifDers = new HashSet<SinifDers>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public int Kontenjan { get; set; }

        public virtual ICollection<SinifDers> SinifDers { get; set; }

        public override string ToString()
        {
            return Adi;
        }
    }
}
